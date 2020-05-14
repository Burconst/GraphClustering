#include <stdlib.h>
#include <stdio.h>
#include <iostream>
#include <iomanip>
#include <fstream>
#include <vector>
#include <map>
#include <algorithm>
#include <random>

#include "include/GraphClustering.h"
#include "include/Output.h"


namespace GraphClustering 
{
    using namespace std;

    vector<int> mixNodeOrder(Partition* partition);
    double MoveNodesFast(Partition* partition);
    bool findImprovement(Partition* partition, vector<int> order);
    Partition refinePartition(Partition* p);
    // void refinePartition(Partition* p, Partition* refp);
    void maintain_partition(Partition* partition, Partition* ref_partition);
    pair<int, int> findBestNeighCommFor(int node, Partition* partition);
    void MergeNodesSubset(Partition* p, vector<int> subset);
    pair<int, int> ChooseRandomComm(Partition* partition, vector<int> commNums, int node);
    bool isInSingletonCommunity(Partition* p, int node, vector<int> subset);
    bool isValidPartition(Graph* g, Partition* p);
    vector<int> getMarkedNodes(Partition* partition);
    vector<int> getWellConnectedCommunities(Partition* partition, vector<int> subset);
    vector<int> getWellConnectedNodes(Partition* partition, vector<int> subset);

    // Change, debug
    double GetLeidenPartitionOf(Partition* partition, double precision)
    {
        double res_mod = -1.;
        bool done = false;
        // ??
        Graph new_g = *(partition->g);
        Partition new_partition = *partition;
        do
        {
            res_mod = MoveNodesFast(&new_partition);
            done = new_partition.GetSize() == new_g.GetNodesCount() ? true : false;
            Partition ref_partition = refinePartition(&new_partition);
            new_g = ref_partition.AggregatePartition();
            new_partition = Partition(&new_g);
            maintain_partition(&new_partition, &ref_partition);

            // Нужно обновить partition
        } while (!done);
        return res_mod;
    }

    // TODO
    void maintain_partition(Partition* partition, Partition* ref_partition) 
    {

    }

    // Debug
    double MoveNodesFast(Partition* partition)
    {
        bool wasImprovement = false;
        double new_mod = partition->Modularity();
        vector<int> considered_nodes = mixNodeOrder(partition);
        do
        {
            wasImprovement = findImprovement(partition, considered_nodes);
            new_mod = partition->Modularity();
            considered_nodes = getMarkedNodes(partition);
        } while (wasImprovement);
        
        return new_mod;
    }

    // Debug
    bool findImprovement(Partition* partition, vector<int> nodes) 
    {
        bool wasImprovement = false;

        for(auto node_tmp = nodes.begin(); node_tmp!=nodes.end(); ++node_tmp) 
        {
            int node = *node_tmp;
            int node_comm = partition->GetCommunityNumber(node);
            
            partition->Remove(node, node_comm, partition->neighComm(node).find(node_comm)->second);
            pair<int, int> newCommunity = findBestNeighCommFor(node, partition);
            partition->Insert(node, newCommunity.first, newCommunity.second);
            if (newCommunity.first!=node_comm)
            {
                wasImprovement = true;
            }
        }

        return wasImprovement;
    }

    // Change, debug
    pair<int, int> findBestNeighCommFor(int node, Partition* partition) 
    {
        pair<int, int> res;
        res.first = partition->GetCommunityNumber(node);
        res.second = 0;
        double best_increase = 0.;
        map<int,int> neighcomm = partition->neighComm(node);
        for (map<int,int>::iterator it=neighcomm.begin(); it!=neighcomm.end(); it++)
        {
            double increase = partition->ModularityGain(node, it->first, it->second);
            if (increase>best_increase)
            {
                res.first = it->first;
                res.second = it->second;
                best_increase = increase;
            }
        }
        return res;
    }
    
    // Debug
    Partition refinePartition(Partition* p)// Partition* refp) 
    {
        Partition refPartition(p->g);
        vector<int> communities = p->GetCommunities();
        for(int i = 0; i < communities.size(); ++i) 
        {
            vector<int> subset = p->GetNodesInCommunity(communities[i]);
            MergeNodesSubset(&refPartition, subset);
        }
        return refPartition;
    }

    // Debug
    void MergeNodesSubset(Partition* p, vector<int> subset)
    {
        vector<int> wellConnNodes = getWellConnectedNodes(p, subset);
        for(int i = 0; i < wellConnNodes.size(); i++)
        {  
            int node = wellConnNodes[i];
            if (isInSingletonCommunity(p, node, subset)) 
            {
                pair<int, int> commNum = ChooseRandomComm(p, getWellConnectedCommunities(p, subset), node);
                if (commNum.first != -1 && commNum.second != -1) 
                {
                    int community_num = p->GetCommunityNumber(node);
                    p->Remove(node, community_num, p->neighComm(node).find(community_num)->second);
                    p->Insert(node, commNum.first, commNum.second);
                }
            }
        }
    }
    
    vector<int> getMarkedNodes(Partition* partition) 
    {
        vector<int> res;
        int nodesCount = partition->g->GetNodesCount();
        for (int node = 0; node < nodesCount; node++) 
        {
            map<int, int> neigh = partition->neighComm(node);
            if (neigh.size() > 1) 
            {
                res.push_back(node);
            }
        }
        return res;
    }

    bool isInSingletonCommunity(Partition* p, int node, vector<int> subset) 
    {
        int size = subset.size();
        int nodeComm = p->GetCommunityNumber(node);
        for (int i = 0; i < size; i++) 
        {
            if (node != subset[i] && nodeComm == p->GetCommunityNumber(subset[i])) 
            {
                return false;
            }
        }
        return true;
    }

    pair<int, int> ChooseRandomComm(Partition* partition, vector<int> commNums, int node)
    {
        assert(commNums.size() > 0);
        random_device gen;
        vector<pair<int,double>> commMod;
        map<int,int> neighcomm = partition->neighComm(node);
        for (int i = 0; i < commNums.size(); i++) 
        {
            double mod = partition->ModularityGain(node, commNums[i], neighcomm[commNums[i]]);
            if (mod >= 0) 
            {
                if (commMod.size() > 0) 
                {
                    commMod.push_back(make_pair(i,commMod[i-1].second+mod)); 
                }
                else 
                {
                    commMod.push_back(make_pair(i,mod));
                }
            }
        }
        if (commMod.size() > 0) 
        {
            uniform_real_distribution<> distr(0., commMod[commMod.size() - 1].second);
            double genval = distr(gen);
            int ind = 0;
            while(genval >= commMod[ind].second && ind < commMod.size()) 
            {
                ind++;
            }
            return make_pair(commNums[commMod[ind].first],neighcomm[commNums[commMod[ind].first]]);
        }
        return make_pair(-1,-1);
    }

    // Opt
    vector<int> getWellConnectedNodes(Partition* partition, vector<int> subset) 
    {
        vector<int> res;
        int size = subset.size();
        int subsetNorm = partition->GetSubsetNorm(subset);
        int nodeNorm = 0;
        int E = 0;
        for (int i = 0; i < size; i++) 
        {
            nodeNorm = partition->g->GetNodeNorm(subset[i]);
            auto neigh = partition->g->Neighbors(subset[i]);
            int deg = partition->g->GetDergeeOf(subset[i]);
            for (int j = 0; j < deg; j++) 
            {
                auto iter = find(subset.begin(), subset.end(), neigh.first[j]);
                if (iter != subset.end()) 
                {
                    E++;
                }
            }
            if (E >= nodeNorm*(subsetNorm - nodeNorm)) 
            {
                res.push_back(subset[i]);
            }
            E = 0;
        }
        return res;
    }

    // Mb problems, Opt
    vector<int> getWellConnectedCommunities(Partition* partition, vector<int> subset) 
    {
        vector<int> res;
        vector<int> comms;
        if (subset.size() == 0) 
        {
            return res;
        }
        vector<int> tmp = subset;
        sort(tmp.begin(), tmp.end());
        comms.push_back(tmp[0]);
        for (int i = 1; i < tmp.size(); i++) 
        {
            if(tmp[i] != tmp[i-1]) 
            {
                comms.push_back(tmp[i]);            
            }
        }
        int size = comms.size();
        int subsetNorm = partition->GetSubsetNorm(subset);
        int commNorm = 0;
        int E = 0;
        for (int i = 0; i < size; i++) 
        {
            commNorm = partition->GetCommunityNorm(comms[i]);
            
            // needs change
            vector<int> allnodes = partition->GetNodesInCommunity(comms[i], subset);
            vector<int> neednodes;
            for (int k = 0; k < allnodes.size(); k++) 
            {
                map<int, int> neigh = partition->neighComm(allnodes[k]);
                if (neigh.size() > 1) 
                {
                    neednodes.push_back(allnodes[k]);
                }
            }

            int inSameCommCount = 0;
            for (int node = 0; node < neednodes.size(); node++)
            {
                auto neigh = partition->g->Neighbors(neednodes[node]);
                int deg = partition->g->GetDergeeOf(neednodes[node]);
                for (int j = 0; j < deg; j++) 
                {
                    auto iter = find(subset.begin(), subset.end(), neigh.first[j]);
                    if (iter != subset.end() && partition->GetCommunityNumber(neigh.first[j]) == comms[i]) 
                    {
                        inSameCommCount++;
                    }
                }
                E +=(deg - inSameCommCount);
                inSameCommCount = 0;
            }
            if (E >= commNorm*(subsetNorm - commNorm)) 
            {
                res.push_back(subset[i]);
            }
            E = 0;
        }

        return res;
    }
    
    vector<int> mixNodeOrder(Partition* partition)
    {
        vector<int> randomOrder(partition->GetSize());
        for (int i=0 ; i<partition->GetSize() ; i++)
        {
            randomOrder[i]=i;
        }
        for (int i=0 ; i<partition->GetSize()-1 ; i++)
        {
            int rand_pos = rand()%(partition->GetSize()-i)+i;
            int tmp = randomOrder[i];
            randomOrder[i] = randomOrder[rand_pos];
            randomOrder[rand_pos] = tmp;
        }
        return randomOrder;
    }

}

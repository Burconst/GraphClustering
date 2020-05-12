#include <stdlib.h>
#include <stdio.h>
#include <iostream>
#include <iomanip>
#include <fstream>
#include <vector>
#include <map>

#include "include/GraphClustering.h"
#include "include/Output.h"


namespace GraphClustering 
{
    using namespace std;

    vector<int> mixNodeOrder(Partition* partition);
    double MoveNodesFast(Partition* partition);
    bool isValidPartition(Graph* g, Partition* p);
    bool findImprovement(Partition* partition, vector<int> order);
    Partition refinePartition(Partition* p);
    void maintain_partition(Partition* partition, Partition* ref_partition);
    pair<int, int> findBestNeighCommFor(int node, Partition* partition);
    void MergeNodesSubset(Partition* p, int community_num);
    vector<int> getWellConnectedCommunities();
    vector<int> getMarkedNodes(Partition* partition);

    // DEBUG
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
            maintain_partition(&new_partition, &ref_partition);

            // Нужно обновить partition
        } while (!done);

        return res_mod;
    }

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

    bool findImprovement(Partition* partition, vector<int> nodes) 
    {
        bool wasImprovement = false;

        for(auto node_tmp = nodes.begin(); node_tmp!=nodes.end(); ++node_tmp) 
        {
            int node = nodes[*node_tmp];
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
    
    Partition refinePartition(Partition* p) 
    {

        Partition refPartition(p->g);
        vector<int> communities = p->GetCommunities();
        for(int i = 0; i < communities.size(); ++i) 
        {
            MergeNodesSubset(p, communities[i]);
        }
        return refPartition;
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

    // TODO
    void MergeNodesSubset(Partition* p, int community_num)
    {
        // vector<int> wellConnNodes = getWellConnectedNodes(p, community_num);
        // for(int node = 0; node < wellConnNodes.size(); node++)
        // {  
        //     // ??
        //     if (1) 
        //     {
        //         int commNum = ChooseRandomComm(getWellConnectedCommunities(p));
        //         p->Remove(node, community_num, p->neighComm(node).find(community_num)->second);
        //         p->Insert(node, commNum, newCommunity.second);
        //     }
        // }
    }

    // TODO
    int ChooseRandomComm(vector<int> wellConnNodes)
    {
        int res = 0;

        return res;
    }

    // TODO
    void maintain_partition(Partition* partition, Partition* ref_partition) 
    {

    }

    // TODO
    vector<int> getWellConnectedNodes(Partition* partition, int community_num) 
    {
        vector<int> res;

        return res;
    }

    // TODO
    vector<int> getWellConnectedCommunities(Partition* partition) 
    {
        vector<int> res;

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

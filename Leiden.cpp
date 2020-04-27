#include <stdlib.h>
#include <stdio.h>
#include <iostream>
#include <iomanip>
#include <fstream>
#include <vector>
#include <map>

#include "GraphClustering.h"
#include "Output.h"


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
    void MergeNodesSubset(Partition* p, Community community_num);
    vector<Community> getWellConnectedCommunities();

    // FIX
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
            done = new_partition.size == new_g.NodesCount ? true : false;
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
            int node_comm = partition->n2c[node];

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
        res.first = partition->n2c[node];
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
        vector<Community> communities = p->GetCommunities();
        for(int i = 0; i < communities.size; ++i) 
        {
            MergeNodesSubset(p, communities[i]);
        }
        return refPartition;
    }

    // TODO
    vector<int> getMarkedNodes(Partition* partition) 
    {
    }

    // TODO
    void MergeNodesSubset(Partition* p, Community community_num)
    {
    }

    // TODO
    void maintain_partition(Partition* partition, Partition* ref_partition) 
    {
    }

    // TODO
    vector<int> getWellConnectedNodes() 
    {
    }

    // TODO
    vector<Community> getWellConnectedCommunities() 
    {
    }
    
    vector<int> mixNodeOrder(Partition* partition)
    {
        vector<int> randomOrder(partition->size);
        for (int i=0 ; i<partition->size ; i++)
        {
            randomOrder[i]=i;
        }
        for (int i=0 ; i<partition->size-1 ; i++)
        {
            int rand_pos = rand()%(partition->size-i)+i;
            int tmp = randomOrder[i];
            randomOrder[i] = randomOrder[rand_pos];
            randomOrder[rand_pos] = tmp;
        }
        return randomOrder;
    }

}

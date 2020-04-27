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
    double MoveNodes(Partition* partition);
    bool isValidPartition(Partition* p);
    bool findImprovement(Partition* partition, vector<int> order);

    double GetLouvainPartitionOf(Partition* partition, double precision)
    {
        double mod = partition->Modularity();
        double new_mod = MoveNodes(partition);
        Graph new_g = partition->AggregatePartition();
        while(new_mod-mod>precision)
        {
            mod=new_mod;            
            Partition new_partition(&new_g);
            new_mod = MoveNodes(&new_partition);
            new_g = new_partition.AggregatePartition();
        }
        return new_mod;
        // Нужно как-то вывести
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

    double MoveNodes(Partition* partition)
    {
        bool wasImprovement = false;
        int nb_pass_done = 0;
        double new_mod = partition->Modularity();
        double cur_mod = new_mod;

        vector<int> random_order = mixNodeOrder(partition);
        do
        {
            cur_mod = new_mod;
            nb_pass_done++;
            wasImprovement = findImprovement(partition, random_order);
            new_mod = partition->Modularity();
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

}

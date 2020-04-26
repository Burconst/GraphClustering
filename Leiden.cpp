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

    // TODO
    double GetLeidenPartitionOf(Partition* partition, double precision)
    {
        double mod = partition->Modularity();
        double new_mod = MoveNodesFast(partition);
        Graph new_g = partition->AggregatePartition();
        while(new_mod-mod>precision)
        {
            mod=new_mod;      
            Partition new_partition(&new_g);
            new_mod = MoveNodesFast(&new_partition);
            new_g = new_partition.AggregatePartition();
        }

        return new_mod;
        // Нужно как-то вывести
    }

    // TODO
    double MoveNodesFast(Partition* partition)
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

    // TODO
    bool findImprovement(Partition* partition, vector<int> order) 
    {
        bool wasImprovement = false;

        for (int node_tmp = 0 ; node_tmp<partition->size ; node_tmp++)
        {
            int node = order[node_tmp];
            int node_comm = partition->n2c[node];

            map<int,int> neighcomm = partition->neighComm(node);
            partition->Remove(node, node_comm, neighcomm.find(node_comm)->second);

            int best_comm = node_comm;
            int best_nblinks = 0;
            double best_increase = 0.;
            for (map<int,int>::iterator it=neighcomm.begin(); it!=neighcomm.end(); it++)
            {
                double increase = partition->ModularityGain(node, it->first, it->second);
                if (increase>best_increase)
                {
                    best_comm = it->first;
                    best_nblinks = it->second;
                    best_increase = increase;
                }
            }

            partition->Insert(node, best_comm, best_nblinks);
                
            if (best_comm!=node_comm)
            {
                wasImprovement = true;
            }
        }

        return wasImprovement;
    }

    // TODO
    Partition refinePartition(Partition* p) 
    {
        Partition refPartition(p->g);


        return refPartition;
    }

    // TODO
    void MergeNodesSubset(Partition* p, int community_num) 
    {
        
    }

    // TODO
    vector<int> getWellConnectedNodes() 
    {

    }

 // 

    bool isValidPartition(Graph* g, Partition* p)
    {
        if (p->g == g) 
        {
            return true;
        }
        return false;
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

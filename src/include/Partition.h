#ifndef PARTITION_H
#define PARTITION_H

#include <stdlib.h>
#include <stdio.h>
#include <iostream>
#include <iomanip>
#include <fstream>
#include <vector>
#include <map>

#include "GraphBinary.h"
// #include "Community.h"
// #include "Node.h"

struct Partition
{   
    private: 
        // std::vector<Community> communities;
        int size;               // number of nodes in the network and size of all vectors
        std::vector<int> n2c;   // community to which each node belongs
        std::vector<int> in,tot;// used to compute the modularity participation of each community
    public:
        Graph* g;
        Partition (Graph* g);

        Graph MakeGraph(std::vector<std::vector<int> > comm_nodes, std::vector<int> renumber);
        // remove the node from its current community with which it has dnodecomm links
        inline void Remove(int node, int comm, int dnodecomm);

        // insert the node in comm with which it shares dnodecomm links
        inline void Insert(int node, int comm, int dnodecomm);
        inline int GetSize();
        inline int GetCommunityNumber(int node); 
        // compute the gain of modularity if node where inserted in comm
        // given that node has dnodecomm links to comm.  The formula is:
        // [(In(comm)+2d(node,comm))/2m - ((tot(comm)+deg(node))/2m)^2]-
        // [In(comm)/2m - (tot(comm)/2m)^2 - (deg(node)/2m)^2]
        // where In(comm)    = number of half-links strictly inside comm
        //       Tot(comm)   = number of half-links inside or outside comm (sum(degrees))
        //       d(node,com) = number of links from node to comm
        //       deg(node)   = node degree
        //       m           = number of links
        inline double ModularityGain(int node, int comm, int dnodecomm);

        // compute the set of neighboring communities of node
        // for each community, gives the number of links from node to comm
        std::map<int,int> neighComm(int node);

        // compute the modularity of the current partition
        double Modularity();

        // displays the graph of communities as computed by one_level
        void Partition2graph();
        // displays the current partition (with communities renumbered from 0 to k-1)
        // void DisplayPartition();
        double OneLevel();
        // generates the binary graph of communities as computed by one_level
        Graph AggregatePartition();
        std::vector<int> GetCommunities();
};

inline void Partition::Remove(int node, int comm, int dnodecomm)
{
    assert(node>=0 && node<size);

    tot[comm] -= g->WeightedDegree(node);
    in[comm] -= 2*dnodecomm + g->GetCountSelfloopsOf(node);
    n2c[node]  = -1;
}

inline void Partition::Insert(int node, int comm, int dnodecomm)
{
    assert(node>=0 && node<size);

    tot[comm] += g->WeightedDegree(node);
    in[comm] += 2*dnodecomm + g->GetCountSelfloopsOf(node);
    n2c[node]=comm;
}

inline double Partition::ModularityGain(int node, int comm, int dnodecomm)
{
    assert(node>=0 && node<size);

    double totc = (double)tot[comm];
    double degc = (double)g->WeightedDegree(node);
    double m2 = (double)g->totalWeight;
    double dnc = (double)dnodecomm;

    return (dnc - totc*degc/m2);
}

inline int Partition::GetSize()
{
    return size;
}

inline int Partition::GetCommunityNumber(int node)
{
    return n2c[node];
}

#endif // PARTITION_H

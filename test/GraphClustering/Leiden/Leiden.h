#ifndef LEIDEN_H
#define LEIDEN_H

#include "../../../src/include/GraphClustering.h"

namespace GraphClustering 
{
    std::vector<int> mixNodeOrder(Partition* partition);
    double MoveNodesFast(Partition* partition);
    bool findImprovement(Partition* partition, std::vector<int> order);
    Partition refinePartition(Partition* p);
    // void refinePartition(Partition* p, Partition* refp);
    void maintain_partition(Partition* partition, Partition* ref_partition);
    std::pair<int, int> findBestNeighCommFor(int node, Partition* partition);
    void MergeNodesSubset(Partition* p, std::vector<int> subset);
    std::pair<int, int> ChooseRandomComm(Partition* partition, std::vector<int> commNums, int node);
    bool isInSingletonCommunity(Partition* p, int node, std::vector<int> subset);
    bool isValidPartition(Graph* g, Partition* p);
    std::vector<int> getMarkedNodes(Partition* partition);
    std::vector<int> getWellConnectedCommunities(Partition* partition, std::vector<int> subset);
    std::vector<int> getWellConnectedNodes(Partition* partition, std::vector<int> subset);
}


#endif // LEIDEN_H
#ifndef GRAPHCLUSTERING_H
#define GRAPHCLUSTERING_H

#include "GraphBinary.h"
#include "Partition.h"

namespace GraphClustering
{
    double GetLouvainPartitionOf(Graph* graph);
    double GetLeidenPartitionOf(Graph* graph);
}

#endif // GRAPHCLUSTERING_H

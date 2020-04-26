#ifndef GRAPHCLUSTERING_H
#define GRAPHCLUSTERING_H

#include "graph_binary.h"
#include "partition.h"

namespace GraphClustering
{
    double GetLouvainPartitionOf(Partition* partition, double precision);
    double GetLeidenPartitionOf(Partition* partition, double precision);
}

#endif // GRAPHCLUSTERING_H

#ifndef GRAPHCLUSTERING_H
#define GRAPHCLUSTERING_H

#include "GraphBinary.h"
#include "Partition.h"

namespace GraphClustering
{
    double GetLouvainPartitionOf(Partition* partition, double precision);
    double GetLeidenPartitionOf(Partition* partition, double precision);
}

#endif // GRAPHCLUSTERING_H

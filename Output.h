#ifndef OUTPUT_H
#define OUTPUT_H

#include "partition.h"
#include "graph_binary.h"

namespace Output 
{
    // Partition
    void DisplayPartitionInfo(Partition* partition);
    void DisplayPartition(Partition* partition);

    // Graph
    void Display(Graph* g);
    void DisplayBinary(Graph* g, char *outfile);
}

#endif // OUTPUT_H
#ifndef OUTPUT_H
#define OUTPUT_H

#include <string>

#include "Partition.h"
#include "GraphBinary.h"

// ??
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
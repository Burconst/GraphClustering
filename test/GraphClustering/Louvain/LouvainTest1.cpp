#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <algorithm>
#include <map>

#include "../../../src/include/GraphBinary.h"
#include "../../../src/include/Partition.h"
#include "../../../src/include/GraphClustering.h"

using namespace std;

int main(const int argc, const char *argv[]) 
{
    // Read Graph 
    string filegr(argv[1]);
    Graph graph(filegr, UNWEIGHTED);

    // Setup Partition
    Partition partition(&graph);
    
    // Testing 
    cout << GraphClustering::GetLouvainPartitionOf(&graph);
    return 0;
}
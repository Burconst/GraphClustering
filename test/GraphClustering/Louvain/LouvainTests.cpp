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

Graph ReadGraph(const char* filename) 
{
    string filegr(filename);
    Graph graph(filegr, UNWEIGHTED);
    return graph;
}

// argv = { TestName, GraphFilename }
// GetLouvainPartitionOf()
void Test1(const int argc, const char *argv[]) 
{
    // Setup
    Graph graph = ReadGraph(argv[2]);

    // Testing
    double res = GraphClustering::GetLouvainPartitionOf(&graph);
    cout << res;
}

int main(const int argc, const char *argv[]) 
{
    string testNumber(argv[1]);

    if (testNumber == "test1") 
    {
        Test1(argc,argv); 
    }

    return 0;
}
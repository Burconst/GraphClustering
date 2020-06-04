#include <iostream>
#include <string>
#include <fstream>

#include "../../src/include/GraphBinary.h"
#include "../../src/include/Partition.h"

using namespace std;

int main(const int argc, const char *argv[]) 
{
    string filegraph1(argv[1]);
    Graph graph1(filegraph1, UNWEIGHTED);

    int n = 3;
    int nodes[] = { atoi(argv[2]), atoi(argv[3]), atoi(argv[4]) };
    for (int i = 0; i < n; i++) 
    {   
        if (i!=0) 
        {
            cout << " ";
        }
        cout << graph1.GetNodeNorm(nodes[i]);
    }
    return 0;
}
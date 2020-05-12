#include <iostream>
#include <string>

#include "../../src/include/GraphBinary.h"

using namespace std;

int main(const int argc, const char *argv[]) 
{
    string filename(argv[1]);
    int n = 3;
    int nodes[] = { atoi(argv[2]), atoi(argv[3]), atoi(argv[4]) };
    Graph graph(filename, UNWEIGHTED);
    for (int i = 0; i < n; i++) 
    {   
        auto neigh = graph.Neighbors(nodes[i]);
        int count = graph.GetDergeeOf(nodes[i]);
        for (int j = 0; j < count; j++) 
        {
            cout << neigh.first[j] << " ";
        }
        cout << ";";
    }
    return 0;
}

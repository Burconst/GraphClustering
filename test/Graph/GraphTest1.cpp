// Test int Graph::GetDegreeOf(int node);

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
        if (i!=0) 
        {
            cout << " ";
        }
        cout << graph.GetDergeeOf(nodes[i]);
    }
    return 0;
}

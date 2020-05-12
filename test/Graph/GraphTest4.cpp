#include <iostream>
#include <string>

#include "../../src/include/GraphBinary.h"

using namespace std;

int main(const int argc, const char *argv[]) 
{
    string filename(argv[1]);
    Graph graph(filename, UNWEIGHTED);
    Graph newgraph = graph;
    for (int i = 0; i < graph.GetNodesCount(); i++) 
    {
        if(graph.degrees[i]!=newgraph.degrees[i]) 
        {
            cout << "Error";
            return 0;
        }
    }

    for (int i = 0; i < graph.GetEdgesCount(); i++) 
    {
        if(graph.links[i]!=newgraph.links[i]) 
        {
            cout << "Error";
            return 0;
        }
    }
    if (graph.weights != NULL) 
    {
        for (int i = 0; i < graph.GetEdgesCount(); i++) 
        {
            if(graph.weights[i]!=newgraph.weights[i]) 
            {
                cout << "Error";
                return 0;
            }
        }
    }

    cout << "Success";
    return 0;
}

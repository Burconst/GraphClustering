#include <iostream>
#include <string>
#include <vector>

#include "../../src/include/GraphBinary.h"

using namespace std;

Graph ReadGraph(const char* filename) 
{
    string filegr(filename);
    Graph graph(filegr, UNWEIGHTED);
    return graph;
}

void Test1(const int argc, const char *argv[]) 
{
    // Setup
    Graph graph = ReadGraph(argv[2]);
    vector<int> nodes;
    for (int i = 3; i < argc; i++) 
    {
        nodes.push_back(atoi(argv[i]));
    }

    // Testing
    for (int i = 0; i < nodes.size(); i++) 
    {   
        if (i!=0) 
        {
            cout << " ";
        }
        cout << graph.GetDergeeOf(nodes[i]);
    }

}

void Test2(const int argc, const char *argv[]) 
{
    // Setup
    Graph graph = ReadGraph(argv[2]);
    vector<int> nodes;
    for (int i = 3; i < argc; i++) 
    {
        nodes.push_back(atoi(argv[i]));
    }

    // Testing
    for (int i = 0; i < nodes.size(); i++) 
    {   
        if (i!=0) 
        {
            cout << " ";
        }
        cout << graph.GetCountSelfloopsOf(nodes[i]);
    }

}

void Test3(const int argc, const char *argv[]) 
{
    // Setup
    Graph graph = ReadGraph(argv[2]);
    vector<int> nodes;
    for (int i = 3; i < argc; i++) 
    {
        nodes.push_back(atoi(argv[i]));
    }

    // Testing
    for (int i = 0; i < nodes.size(); i++) 
    {   
        auto neigh = graph.Neighbors(nodes[i]);
        int count = graph.GetDergeeOf(nodes[i]);
        for (int j = 0; j < count; j++) 
        {
            cout << neigh.first[j] << " ";
        }
        cout << ";";
    }
}

void Test4(const int argc, const char *argv[]) 
{
    // Setup
    Graph graph = ReadGraph(argv[2]);

    // Testing
    Graph newgraph = graph;
    for (int i = 0; i < graph.GetNodesCount(); i++) 
    {
        if(graph.degrees[i]!=newgraph.degrees[i]) 
        {
            cout << "Error";
        }
    }
    for (int i = 0; i < graph.GetEdgesCount(); i++) 
    {
        if(graph.links[i]!=newgraph.links[i]) 
        {
            cout << "Error";
        }
    }
    if (graph.weights != NULL) 
    {
        for (int i = 0; i < graph.GetEdgesCount(); i++) 
        {
            if(graph.weights[i]!=newgraph.weights[i]) 
            {
                cout << "Error";
            }
        }
    }
    cout << "Success";
}

void Test5(const int argc, const char *argv[]) 
{
    // Setup
    Graph graph1 = ReadGraph(argv[2]);
    Graph graph2 = ReadGraph(argv[3]);
    if (graph1 == graph2) 
    {
        cout << "Equal";
    }
    else 
    {
        cout << "Not Equal";
    }
}

void Test6(const int argc, const char *argv[]) 
{
    // Setup
    Graph graph = ReadGraph(argv[2]);
    vector<int> nodes;
    for (int i = 3; i < argc; i++) 
    {
        nodes.push_back(atoi(argv[i]));
    }

    // Testing
    for (int i = 0; i < nodes.size(); i++) 
    {   
        if (i!=0) 
        {
            cout << " ";
        }
        cout << graph.GetNodeNorm(nodes[i]);
    }
}


int main(const int argc, const char *argv[]) 
{
    string testNumber(argv[1]);
    
    if (testNumber == "test1") 
    {
        Test1(argc,argv); 
    }
    if (testNumber == "test2") 
    {
        Test2(argc,argv); 
    }
    if (testNumber == "test3") 
    {
        Test3(argc,argv); 
    }
    if (testNumber == "test4") 
    {
        Test4(argc,argv); 
    }
    if (testNumber == "test5") 
    {
        Test5(argc,argv); 
    }
    if (testNumber == "test6") 
    {
        Test6(argc,argv); 
    }


    return 0;
}
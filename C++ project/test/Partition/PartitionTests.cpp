#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <algorithm>
#include <map>

#include "../../src/include/GraphBinary.h"
#include "../../src/include/Partition.h"

using namespace std;

Graph ReadGraph(const char* filename) 
{
    string filegr(filename);
    Graph graph(filegr, UNWEIGHTED);
    return graph;
}

vector<int> ReadCommunities(const char* filename) 
{
    string filecomm(filename);
    ifstream finput;
    finput.open(filecomm, fstream::in | fstream::binary);
    string str;
    vector<int> commVector;
    while(getline(finput, str)) 
    {
        int i = 0;
        string num;
        while (i < str.length()) 
        {
            num.push_back(str[i]);
            i++;
        }
        commVector.push_back(atoi(num.c_str()));
        num = "";
    }
    return commVector;
}

Partition SetupPartition(Graph* graph, vector<int> commVector) 
{
    Partition partition(graph);
    for (int i = 0; i < commVector.size(); i++) 
    {
        partition.SetCommunityOf(i, commVector[i]);
    }
    return partition;
}

void Test1(const int argc, const char *argv[]) 
{
    // Setup
    Graph graph = ReadGraph(argv[2]);
    vector<int> commVector = ReadCommunities(argv[3]);
    Partition partition = SetupPartition(&graph, commVector);
    vector<int> nodes;
    for (int i = 4; i < argc; i++) 
    {
        nodes.push_back(atoi(argv[i]));
    }

    // Testing 
    for (int i = 0; i < nodes.size(); i++) 
    {
        cout << "{";
        map<int, int> neighComm = partition.neighComm(nodes[i]);
        vector<int> communities;
        for(auto& item : neighComm)
        {   
            auto inter = std::find(communities.begin(), communities.end(), item.first);
            if (inter == communities.end()) 
            {
                communities.push_back(item.first);
            }
        }
        for (int j = 0; j < communities.size(); j++) 
        {
            cout << " " << communities[j] << " ";
        }
        cout << "}";
    }
}

void Test2(const int argc, const char *argv[]) 
{
    // Setup
    Graph graph = ReadGraph(argv[2]);
    vector<int> commVector = ReadCommunities(argv[3]);
    Partition partition = SetupPartition(&graph, commVector);

    // Testing 
    cout << "{";
    vector<int> communities = partition.GetCommunities();
    for (int j = 0; j < communities.size(); j++) 
    {
        cout << " " << communities[j] << " ";
    }
    cout << "}";
}

void Test3(const int argc, const char *argv[]) 
{
    // Setup
    Graph graph1 = ReadGraph(argv[2]);
    vector<int> commVector1 = ReadCommunities(argv[3]);
    Partition partition1 = SetupPartition(&graph1, commVector1);
    Graph graph2 = ReadGraph(argv[4]);
    vector<int> commVector2 = ReadCommunities(argv[5]);
    Partition partition2 = SetupPartition(&graph2, commVector2);

    // Testing 
    if (partition1 == partition2) 
    {
        cout << "Equal";
    }
    else 
    {
        cout << "Not Equal";
    }
}

void Test4(const int argc, const char *argv[]) 
{
    // Setup
    Graph graph = ReadGraph(argv[2]);
    vector<int> commVector = ReadCommunities(argv[3]);
    Partition partition1 = SetupPartition(&graph, commVector);
    Partition partition2 = partition1;
    
    // Testing 
    if (partition1 == partition2) 
    {
        cout << "Equal";
    }
    else 
    {
        cout << "Not Equal";
    }
}

void Test5(const int argc, const char *argv[]) 
{
    // Setup
    Graph graph = ReadGraph(argv[2]);
    vector<int> commVector = ReadCommunities(argv[3]);
    Partition partition1 = SetupPartition(&graph, commVector);
    Graph agrGraph_ex = ReadGraph(argv[4]);
    
    // Testing 
    Graph agrGraph = partition1.AggregatePartition();
    if (agrGraph_ex == agrGraph) 
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
    vector<int> commVector = ReadCommunities(argv[3]);
    Partition partition = SetupPartition(&graph, commVector);
    vector<int> nodes;
    for (int i = 4; i < argc; i++) 
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
        cout << partition.GetCommunityNorm(nodes[i]);
    }
}

void Test7(const int argc, const char *argv[]) 
{
    // Setup
    Graph graph = ReadGraph(argv[2]);
    vector<int> commVector = ReadCommunities(argv[3]);
    Partition partition = SetupPartition(&graph, commVector);
    vector<int> nodes;
    for (int i = 4; i < argc; i++) 
    {
        nodes.push_back(atoi(argv[i]));
    }

    // Testing 
    Graph agrGraph = partition.AggregatePartition();
    for (int i = 0; i < nodes.size(); i++) 
    {   
        if (i!=0) 
        {
            cout << " ";
        }
        cout << agrGraph.GetNodeNorm(nodes[i]);
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
    if (testNumber == "test7") 
    {
        Test7(argc,argv); 
    }

    return 0;
}
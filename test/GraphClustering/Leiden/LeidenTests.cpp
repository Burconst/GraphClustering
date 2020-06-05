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

// argv = { TestName, GraphFilename, CommunitiesFilename }
vector<int> getMarkedNodes(Partition* partition);
void Test1(const int argc, const char *argv[]) 
{
    // Setup
    Graph graph = ReadGraph(argv[2]);
    vector<int> commVector = ReadCommunities(argv[3]);
    Partition partition = SetupPartition(&graph, commVector);
    
    // Testing 
    cout << "{";
    vector<int> markedNodes = ::getMarkedNodes(&partition);
    int size =  markedNodes.size();
    for (int j = 0; j < size; j++) 
    {
        cout << " " << markedNodes[j] << " ";
    }
    cout << "}";
}

// argv = { TestName, GraphFilename, CommunitiesFilename, CommNumb1, CommNumb2, ... }
vector<int> getWellConnectedNodes(Partition* partition, vector<int> subset);
void Test2(const int argc, const char *argv[]) 
{
    // Setup
    Graph graph = ReadGraph(argv[2]);
    vector<int> commVector = ReadCommunities(argv[3]);
    Partition partition = SetupPartition(&graph, commVector);
    
    // Testing 
    vector<int> subset;
    for (int i = 4; i < argc; i++) 
    {
        subset.push_back(atoi(argv[i]));
    }
    cout << "{";
    vector<int> markedNodes = ::getWellConnectedNodes(&partition, subset);
    int size =  markedNodes.size();
    for (int j = 0; j < size; j++) 
    {
        cout << " " << markedNodes[j] << " ";
    }
    cout << "}";
}

// argv = { TestName, GraphFilename, CommunitiesFilename, CommNumb1, CommNumb2, ... }
pair<int, int> chooseRandomComm(Partition* partition, vector<int> commNums, int node);
void Test3(const int argc, const char *argv[]) 
{
    // Setup
    Graph graph = ReadGraph(argv[2]);
    vector<int> commVector = ReadCommunities(argv[3]);
    Partition partition = SetupPartition(&graph, commVector);

    // Testing 
    vector<int> commNums;
    for (int i = 4; i < argc-1;i++) 
    {
        commNums.push_back(atoi(argv[i]));
    }
    pair<int, int> comm = make_pair(-2,-2);
    comm = ::chooseRandomComm(&partition,commNums,atoi(argv[argc-1]));
    if (comm.first == -2 && comm.second == -2) 
    {
        cout << "F";
    }
    else 
    {
        cout << "P";
    } 
}

// argv = { TestName, GraphFilename, CommunitiesFilename, CommNumb1, CommNumb2, ... }
bool isInSingletonCommunity(Partition* p, int node, vector<int> subset);
void Test4(const int argc, const char *argv[]) 
{
    // Setup
    Graph graph = ReadGraph(argv[2]);
    vector<int> commVector = ReadCommunities(argv[3]);
    Partition partition = SetupPartition(&graph, commVector);

    
    // Testing 
    vector<int> allnodes;
    for (int i = 0; i < graph.GetNodesCount(); i++) 
    {
        allnodes.push_back(i);
    }
    vector<int> nodes;
    for (int i = 4; i < argc;i++) 
    {
        nodes.push_back(atoi(argv[i]));
    }
    for (int i = 0; i < nodes.size(); i++) 
    {
        cout << " " << ::isInSingletonCommunity(&partition, nodes[i], allnodes) << " ";
    }
}

// argv = { TestName, GraphFilename, CommunitiesFilename }
vector<int> getWellConnectedCommunities(Partition* partition, vector<int> subset);
void Test5(const int argc, const char *argv[]) 
{
    // Setup
    Graph graph = ReadGraph(argv[2]);
    vector<int> commVector = ReadCommunities(argv[3]);
    Partition partition = SetupPartition(&graph, commVector);

    
    // Testing 
    vector<int> subset;
    for (int i = 0; i < partition.GetCommunities().size(); i++) 
    {
        subset.push_back(i);
    }
    vector<int> wellConnComms = ::getWellConnectedCommunities(&partition, subset);
}

// argv = { TestName, GraphFilename, CommunitiesFilename }
Partition refinePartition(Partition* p);
void Test6(const int argc, const char *argv[]) 
{
    // Setup
    Graph graph = ReadGraph(argv[2]);
    vector<int> commVector = ReadCommunities(argv[3]);
    Partition partition = SetupPartition(&graph, commVector);

    // Testing 
    Partition refpart = ::refinePartition(&partition);
    vector<int> comms =  refpart.GetCommunities();
    for (int j = 0; j < comms.size(); j++) 
    {
        cout << comms[j] << ": ";
        vector<int> nodes = refpart.GetNodesInCommunity(comms[j]);
        for (int i = 0; i < nodes.size(); i++) 
        {
            cout << " " << nodes[i];
        }
        cout << endl;
    }
}

// argv = { TestName, GraphFilename, CommunitiesFilename }
double moveNodesFast(Partition* partition);
void Test7(const int argc, const char *argv[]) 
{
    // Setup
    Graph graph = ReadGraph(argv[2]);
    Partition partition(&graph);

    // Testing 
    double res = ::moveNodesFast(&partition);
    cout << res;
}

// TODO
vector<int> maintain_partition(Partition* partition, Partition* ref_partition); 
void Test8(const int argc, const char *argv[]) 
{
    // // Setup
    // Graph graph = ReadGraph(argv[2]);
    // vector<int> commVectorPart = ReadCommunities(argv[3]);
    // Partition partition = SetupPartition(&graph, commVectorPart);
    // vector<int> commVectorRefPArt = ReadCommunities(argv[3]);
    // Partition partition = SetupPartition(&graph, commVectorRefPArt);

    // // Setup Partition
    // Partition partition(&graph);
    // cout << graph.nbLinks << endl;
    // for (int i = 0; i < commVectorPart.size(); i++) 
    // {
    //     partition.SetCommunityOf(i, commVectorPart[i]);
    // }
    // // Setup RefPartition
    // Partition refPartition = ::refinePartition(&partition);
    // vector<int> newComms = ::maintain_partition(&partition,&refPartition);
    // cout << "Partition" << endl;
    // for (int i = 0; i < partition.n2c.size(); i++) 
    // {
    //     cout << i << ": " << partition.n2c[i]<< "| ";
    // }
    // cout << endl;
    // cout << "RefPartition" << endl;
    // for (int i = 0; i < refPartition.n2c.size(); i++) 
    // {
    //     cout << i << ": " << refPartition.n2c[i]<< "| ";
    // }
    // cout << endl;
    // cout << "newComms" << endl;
    // for (int i = 0; i < newComms.size(); i++) 
    // {
    //     cout << i << ": " << newComms[i]<< "| ";
    // }
    // cout << endl;

    // cout << "links" << endl;
    // for (int i = 0; i < graph.nbLinks*2; i+=2) 
    // {
    //     cout << graph.links[i] << " " << graph.links[i+1]<< "| ";
    // }
    // cout << endl;
}

// argv = { TestName, GraphFilename }
// GetLeidenPartitionOf()
void Test9(const int argc, const char *argv[]) 
{
    // Setup
    Graph graph = ReadGraph(argv[2]);

    // Testing
    double res = GraphClustering::GetLeidenPartitionOf(&graph);
    cout << res;
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
    if (testNumber == "test8") 
    {
        Test8(argc,argv); 
    } 
    if (testNumber == "test9") 
    {
        Test9(argc,argv); 
    } 

    return 0;
}
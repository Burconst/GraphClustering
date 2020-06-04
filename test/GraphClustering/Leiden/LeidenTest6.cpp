#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <algorithm>
#include <map>

#include "../../../src/include/GraphBinary.h"
#include "../../../src/include/Partition.h"
#include "../../../src/Leiden.cpp"

using namespace std;

int main(const int argc, const char *argv[]) 
{
    // Read Graph 
    string filegr(argv[1]);
    Graph graph(filegr, UNWEIGHTED);
    // Read Communities
    vector<int> commVector;
    for (int i = 0; i < graph.GetNodesCount(); i++) 
    {
        commVector.push_back(i);
    }

    // Setup Partition
    Partition partition(&graph);
    for (int i = 0; i < commVector.size(); i++) 
    {
        partition.SetCommunityOf(i, commVector[i]);
    }
    // Testing 
    vector<int> subset;
    for (int i = 2; i < argc; i++) 
    {
        subset.push_back(atoi(argv[i]));
    }
    cout << endl;
    ::mergeNodesSubset(&partition, subset);
    vector<int> comms =  partition.GetCommunities();
    for (int j = 0; j < comms.size(); j++) 
    {
        cout << comms[j] << ": ";
        vector<int> nodes = partition.GetNodesInCommunity(comms[j]);
        for (int i = 0; i < nodes.size(); i++) 
        {
            cout << " " << nodes[i];
        }
        cout << endl;
    }
    
    return 0;
}
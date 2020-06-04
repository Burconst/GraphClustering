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
    string filecomm(argv[2]);
    ifstream finput;
    finput.open(filecomm, fstream::in | fstream::binary);
    string str;
    vector<int> commVector;
    for (int i = 0; i < graph.GetNodesCount(); i++) 
    {
        commVector.push_back(0);
    }

    // Setup Partition
    Partition partition(&graph);
    for (int i = 0; i < commVector.size(); i++) 
    {
        partition.SetCommunityOf(i, commVector[i]);
    }
    
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
    
    return 0;
}
#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <algorithm>
#include <map>

#include "../../../src/include/GraphBinary.h"
#include "../../../src/include/Partition.h"
#include "Leiden.h"

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

    // while(getline(finput, str)) 
    // {
    //     int i = 0;
    //     string num;
    //     while (i < str.length()) 
    //     {
    //         num.push_back(str[i]);
    //         i++;
    //     }
    //     commVector.push_back(atoi(num.c_str()));
    //     num = "";
    // }
    // Setup Partition
    Partition partition(&graph);
    for (int i = 0; i < commVector.size(); i++) 
    {
        partition.SetCommunityOf(i, commVector[i]);
    }
    // Testing 
    // vector<int> subset; // = partition.GetNodesInCommunity(atoi(argv[2]));
    // for (int i = 2; i < argc; i++) 
    // {
    //     subset.push_back(atoi(argv[i]));
    //     // cout << subset[i-2] << " ";
    // }
    // cout << endl;
    // for (int i = 0; i < partition.GetCommunities().size(); i++) 
    // {
    //     subset.push_back(i);
    // }
    Partition refpart = GraphClustering::refinePartition(&partition);//,&refpart);
        //     cout << "sadasd";
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
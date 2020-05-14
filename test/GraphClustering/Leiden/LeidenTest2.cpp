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
    // Setup Partition
    Partition partition(&graph);
    for (int i = 0; i < commVector.size(); i++) 
    {
        partition.SetCommunityOf(i, commVector[i]);
    }
    // Testing 
    vector<int> subset;
    for (int i = 3; i < argc; i++) 
    {
        subset.push_back(atoi(argv[i]));
        cout << subset[i-3] << " ";
    }
    cout << "{";
    vector<int> markedNodes = GraphClustering::getWellConnectedNodes(&partition, subset);
    int size =  markedNodes.size();
    for (int j = 0; j < size; j++) 
    {
        cout << " " << markedNodes[j] << " ";
    }
    cout << "}";
    
    return 0;
}
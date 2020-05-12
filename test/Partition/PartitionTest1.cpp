#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <algorithm>
#include <map>

#include "../../src/include/GraphBinary.h"
#include "../../src/include/Partition.h"

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
    int nodes[] = { atoi(argv[3]), atoi(argv[4]), atoi(argv[5]) };
    for (int i = 0; i < 3; i++) 
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
    return 0;
}

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
    // praph1 
    string filegraph1(argv[1]);
    Graph graph1(filegraph1, UNWEIGHTED);

    // Read Communities
    string filecomm1(argv[2]);
    ifstream finput;
    finput.open(filecomm1, fstream::in | fstream::binary);
    string str;
    vector<int> commVector1;
    while(getline(finput, str)) 
    {
        int i = 0;
        string num;
        while (i < str.length()) 
        {
            num.push_back(str[i]);
            i++;
        }
        commVector1.push_back(atoi(num.c_str()));
        num = "";
    }
    finput.close();

    // Setup Partitions
    Partition partition1(&graph1);
    for (int i = 0; i < commVector1.size(); i++) 
    {
        partition1.SetCommunityOf(i, commVector1[i]);
    }
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
    
    return 0;
}
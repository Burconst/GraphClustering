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
    
    // Read Partition    
    string filecomm1(argv[2]);
    ifstream finput;
    finput.open(filecomm1, fstream::in | fstream::binary);
    string str;
    vector<int> commVectorPart;
    while(getline(finput, str)) 
    {
        int i = 0;
        string num;
        while (i < str.length()) 
        {
            num.push_back(str[i]);
            i++;
        }
        commVectorPart.push_back(atoi(num.c_str()));
        num = "";
    }
    finput.close();

    // Read RefPartition    
    string filecomm2(argv[3]);
    finput;
    finput.open(filecomm1, fstream::in | fstream::binary);
    str = "";
    vector<int> commVectorRefPArt;
    while(getline(finput, str)) 
    {
        int i = 0;
        string num;
        while (i < str.length()) 
        {
            num.push_back(str[i]);
            i++;
        }
        commVectorRefPArt.push_back(atoi(num.c_str()));
        num = "";
    }
    finput.close();

    // Setup Partition
    Partition partition(&graph);
    cout << graph.nbLinks << endl;
    for (int i = 0; i < commVectorPart.size(); i++) 
    {
        partition.SetCommunityOf(i, commVectorPart[i]);
    }
    // Setup RefPartition
    Partition refPartition = ::refinePartition(&partition);
    vector<int> newComms = ::maintain_partition(&partition,&refPartition);
    cout << "Partition" << endl;
    for (int i = 0; i < partition.n2c.size(); i++) 
    {
        cout << i << ": " << partition.n2c[i]<< "| ";
    }
    cout << endl;
    cout << "RefPartition" << endl;
    for (int i = 0; i < refPartition.n2c.size(); i++) 
    {
        cout << i << ": " << refPartition.n2c[i]<< "| ";
    }
    cout << endl;
    cout << "newComms" << endl;
    for (int i = 0; i < newComms.size(); i++) 
    {
        cout << i << ": " << newComms[i]<< "| ";
    }
    cout << endl;

    cout << "links" << endl;
    for (int i = 0; i < graph.nbLinks*2; i+=2) 
    {
        cout << graph.links[i] << " " << graph.links[i+1]<< "| ";
    }
    cout << endl;

    return 0;
}
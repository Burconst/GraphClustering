#include <iostream>
#include <string>

#include "../../src/include/GraphBinary.h"

using namespace std;

int main(const int argc, const char *argv[]) 
{
    string filename1(argv[1]);
    Graph graph1(filename1, UNWEIGHTED);
    string filename2(argv[2]);
    Graph graph2(filename2, UNWEIGHTED);
    if (graph1 == graph2) 
    {
        cout << "Equal";
    }
    else 
    {
        cout << "Not Equal";
    }
    return 0;
}

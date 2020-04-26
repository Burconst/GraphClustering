#include <iostream>
#include <string>
#include <fstream>
#include <sysinfoapi.h>
#include <windows.h>

#include "graph_binary.h"
#include "partition.h"
#include "GraphClustering.h"

using namespace std;

void Test(double (*method)(string, double, int), string folder, int filesCount, int iterationsCount);
double Louvain(string filename, double precision, int type);
double Leiden(string filename, double precision, int type);

double Louvain(string filename, double precision, int type)
{
  Graph g = Graph(filename.c_str(), type);
  Partition partition(&g);
  return GraphClustering::GetLouvainPartitionOf(&partition, precision);
}

double Leiden(string filename, double precision, int type) 
{
  Graph g = Graph(filename.c_str(), type);
  Partition partition(&g);
  return GraphClustering::GetLeidenPartitionOf(&partition, precision);
}

void Test(double (*method)(string, double, int), string folder, int filesCount, int iterationsCount)
{
    try
    {
        double mod = -1;
        DWORD timeStart;
        DWORD timeStop;
        string line = "";
        string inputFilename = "";
        string outputFilename = "";
        for(int i = 0;i < filesCount; i++)
        {
            inputFilename = folder+"test"+to_string(i)+".bin";
            outputFilename = folder+"res"+to_string(i)+".txt";
            ofstream out;
            out.open(outputFilename.c_str(), ios::out);
            out << "mod" << endl;
            mod = -1;
            for(int j = 0;j < iterationsCount; j++)
            {
                timeStart = GetTickCount();
                mod = (*method)(inputFilename, 0.000001, 1);
                timeStop = GetTickCount();
                line = to_string(timeStop-timeStart) + " " + to_string(mod);
                out << mod << endl;
            }
            out.close();
        }
    }
    catch(exception e)
    {
      std::cout << e.what() << '\n';
    }
}

int main()
{
  
  return 0;
}

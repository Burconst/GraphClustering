#include <fstream>

#include "graph_binary.h"

using namespace std;

Graph::Graph()
  : nbNodes(0)
  , nbLinks(0)
  , totalWeight(0)
{}

Graph::Graph(std::string filename, int type) 
{
  ifstream finput;
  finput.open(filename,fstream::in | fstream::binary);

  // read number of nodes on 4 bytes
  finput.read((char *)&nbNodes, 4);

  // read cumulative degree sequence: 4 bytes for each node
  // cum_degree[0]=degree(0); cum_degree[1]=degree(0)+degree(1), etc.

  degrees = (int *)malloc((long)nbNodes*4);
  finput.read((char *)degrees, (long)nbNodes*4);

  // read links: 4 bytes for each link (each link is counted twice)
  nbLinks=degrees[nbNodes-1]/2;
  links = (int *)malloc((long)nbLinks*8);
  finput.read((char *)links, (long)nbLinks*8);  
  //cerr << "total : " << nbLinks << endl;

  // IF WEIGHTED : read weights: 4 bytes for each link (each link is counted twice)
  if (type==WEIGHTED) 
  {
    weights = (int *)malloc((long)nbLinks*8);
    finput.read((char *)weights, (long)nbLinks*8);  
    totalWeight=0;
    for (int i = 0 ; i<nbLinks*2 ; i++) 
    {
      totalWeight += weights[i];
    }
  }
  else
  {
    weights = NULL;
    totalWeight = 2*nbLinks;
  }
}

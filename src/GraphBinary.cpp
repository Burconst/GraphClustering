#include <fstream>
#include <iostream>

#include "include/GraphBinary.h"

using namespace std;

Graph::Graph()
    : NodesCount(0)
    , nbLinks(0)
    , totalWeight(0)
{}

Graph::Graph(std::string filename, int type) 
{
    ifstream finput;
    finput.open(filename,fstream::in | fstream::binary);
    // read number of nodes on 4 bytes
    finput.read((char *)&NodesCount, 4);

    // read cumulative degree sequence: 4 bytes for each node
    // cum_degree[0]=degree(0); cum_degree[1]=degree(0)+degree(1), etc.
    degrees = (int *)malloc((long)NodesCount*4);
    finput.read((char *)degrees, (long)NodesCount*4);

    // read links: 4 bytes for each link (each link is counted twice)
    nbLinks=degrees[NodesCount-1]/2;
    links = (int *)malloc((long)nbLinks*8);
    finput.read((char *)links, (long)nbLinks*8);  

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

    norms = (int *)malloc((long)NodesCount*sizeof(int));
    for (int i = 0; i < NodesCount; i++) 
    {
        norms[i] = 1;
    }
}

Graph::Graph(const Graph &graph) 
    : NodesCount(graph.NodesCount)
    , nbLinks(graph.nbLinks)
    , totalWeight(graph.totalWeight)
{
    
    degrees = (int *)malloc(sizeof(int)*graph.NodesCount);
    norms = (int *)malloc(sizeof(int)*graph.NodesCount);
    for (int i = 0; i < graph.NodesCount; i++) 
    {
        degrees[i] = graph.degrees[i];
        norms[i] = graph.norms[i];
    }
    links = (int *)malloc(sizeof(int)*graph.nbLinks);
    for (int i = 0; i < graph.nbLinks; i++) 
    {
        links[i] = graph.links[i];
    }
    if (graph.weights != NULL) 
    {
        weights = (int *)malloc(sizeof(int)*graph.nbLinks);
        for (int i = 0; i < graph.nbLinks; i++) 
        {
            weights[i] = graph.weights[i];
        }
    }
    else
    {
        weights = NULL;
    }
}

Graph::~Graph() 
{
    if (degrees != nullptr) 
    {
         free(degrees);
    }
    if (norms != nullptr) 
    {
         free(norms);
    }
    if (links != nullptr) 
    {
        free(links);
    }
    if (weights != nullptr) 
    {
       free(weights);
    }
}

bool Graph::operator==(Graph g) 
{
    if (g.NodesCount != NodesCount) 
    {
        return false;
    }
    if (g.nbLinks != nbLinks) 
    {
        return false;
    }
    if (g.totalWeight != totalWeight) 
    {
        return false;
    } 

    for (int i = 0; i < g.NodesCount; i++) 
    {
        if (g.degrees[i] != degrees[i]) 
        {
            return false;
        }
    }
    for (int i = 0; i < g.NodesCount; i++) 
    {
        if (g.norms[i] != norms[i]) 
        {
            return false;
        }
    }
    for (int i = 0; i < g.nbLinks; i++) 
    {
        if (g.links[i] != links[i]) 
        {
            return false;
        }
    }
    if (g.weights != NULL) 
    {
        for (int i = 0; i < g.nbLinks; i++) 
        {
            if (g.weights[i] != weights[i]) 
            {
                return false;
            }
        }
    }
    else
    {
        if (weights != NULL)
        {
            return false;
        }
    }

    return true;
}



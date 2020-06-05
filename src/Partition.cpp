#include <algorithm>

#include "include/Partition.h"

using namespace std;

Partition::Partition(Graph* g)
    : g(g)
{
    size = g->GetNodesCount();

    n2c.resize(size);
    in.resize(size);
    tot.resize(size);

    for (int i=0 ; i<size ; i++)
    {
        n2c[i] = i;
        in[i]  = g->GetCountSelfloopsOf(i);
        tot[i] = g->WeightedDegree(i);
    }
}

Partition::Partition (Graph* g, std::vector<int> node2comm)
    : g(g)
{
    size = g->GetNodesCount();

    n2c = node2comm;
    in.resize(size);
    tot.resize(size);

    for (int i=0 ; i<size ; i++)
    {
        in[i]  = g->GetCountSelfloopsOf(i);
        tot[i] = g->WeightedDegree(i);
    }
}

Partition::Partition(const Partition &partition)
    : g(partition.g)
    , n2c(partition.n2c)
    , size(partition.size)
    , tot(partition.tot)
    , in(partition.in)
{
}

bool Partition::operator==(Partition partition) 
{
    if (g != partition.g) 
    {
        return false;
    }
    if (n2c != partition.n2c||size != partition.size||tot != partition.tot||in != partition.in) 
    {
        return false;
    }
    return true;
}

double Partition::Modularity()
{
    double q  = 0.;
    double m2 = (double)g->GetTotalWeight();
    for (int i=0 ; i<size ; i++)
    {
        if (tot[i]>0)
        {
            q += (double)in[i]/m2 - ((double)tot[i]/m2)*((double)tot[i]/m2);
        }
    }

    return q;
}

map<int,int> Partition::neighComm(int node)
{
    assert(node>=0 && node<size);
    map<int,int> res;
    pair<int *,int *> p = g->Neighbors(node);

    int deg = g->GetDergeeOf(node);

    res.insert(make_pair(n2c[node],0));

    for (int i=0 ; i<deg ; i++)
    {
        int neigh = *(p.first+i);
        int neigh_comm = n2c[neigh];
        int neigh_weight = (g->weights==NULL)? 1: *(p.second+i);

        if (neigh!=node)
        {
            map<int,int>::iterator it = res.find(neigh_comm);
            if (it!=res.end())
            {
                it->second+=neigh_weight;
            }
            else
            {
                res.insert(make_pair(neigh_comm,neigh_weight));
            }
        }
    }

    return res;
}

Graph Partition::AggregatePartition()
{
    vector<int> renumber(size, -1);
    for (int node=0 ; node<size ; node++)
    {   
        renumber[n2c[node]]++;
    }

    int final=0;
    for (int i=0 ; i<size ; i++)
    {
        renumber[i]=final++;
    } 
    vector<vector<int>> comm_nodes(final);
    for (int node=0 ; node<final ; node++)
    {

        // if (n2c[node] != -1) 
        // {
            assert(renumber[n2c[node]] >= 0 && renumber[n2c[node]]<size);
            comm_nodes[renumber[n2c[node]]].push_back(node);
        // }

    }

    return MakeGraph(comm_nodes,renumber);
}

// FIX
Graph Partition::MakeGraph(vector<vector<int> > comm_nodes, vector<int> renumber)
{
    int comm_deg = comm_nodes.size();
    Graph graph;
    graph.NodesCount = comm_deg;
    graph.degrees  = (int *)malloc(comm_deg*4);
    graph.norms = (int *)malloc(comm_deg*4);
    // XXX
    graph.links = (int *)malloc((long)10000000*8);
    graph.weights  = (int *)malloc((long)10000000*8);
    long where = 0;
    
    for (int comm=0 ; comm<comm_deg ; comm++)
    {
        map<int,int> m;
        map<int,int>::iterator it;
        int comm_size = comm_nodes[comm].size();
        graph.norms[comm] = comm_size;
        for (int node=0 ; node<comm_size ; node++)
        {
            pair<int *,int *> p = g->Neighbors(comm_nodes[comm][node]);
            int deg = g->GetDergeeOf(comm_nodes[comm][node]);
            for (int i=0 ; i<deg ; i++) 
            {
                int neigh        = *(p.first+i);
                int neigh_comm   = renumber[n2c[neigh]];
                int neigh_weight = (g->weights==NULL)?1:*(p.second+i);

                it = m.find(neigh_comm);
                if (it==m.end())
                {
                    m.insert(make_pair(neigh_comm, neigh_weight));
                }
                else
                {
                    it->second+=neigh_weight;
                }
            }
        }
        graph.degrees[comm]=(comm==0)?m.size():graph.degrees[comm-1]+m.size();
        graph.nbLinks+=m.size();
        for (it = m.begin(); it!=m.end(); it++)
        {
            graph.totalWeight  += it->second;
            graph.links[where]   = it->first;
            graph.weights[where] = it->second;
            where++;
        }
    }

    return graph;
}

vector<int> Partition::GetCommunities()
{
    vector<int> res;
    if (n2c.size() == 0) 
    {
        return res;
    }
    vector<int> tmp = n2c;
    sort(tmp.begin(), tmp.end());
    res.push_back(tmp[0]);
    for (int i = 1; i < tmp.size(); i++) 
    {
        if(tmp[i] != tmp[i-1]) 
        {
            res.push_back(tmp[i]);            
        }
    }
    return res;
}

int Partition::GetCommunityNorm(int comm_num)
{
    int res = 0;
    vector<int> nodes = GetNodesInCommunity(comm_num);
    int size = nodes.size();
    for(int i = 0; i < size; i++) 
    {
        res += g->GetNodeNorm(nodes[i]);
    }
    return res;
}

int Partition::GetSubsetNorm(vector<int> subset)
{
    int res = 0;
    int size = subset.size();
    for(int i = 0; i < size; i++) 
    {
        res += g->GetNodeNorm(subset[i]);
    }
    return res;
}

vector<int> Partition::GetNodesInCommunity(int comm_num)
{
    vector<int> nodes;
    int size = n2c.size();
    for (int node = 0; node < size; node++) 
    {
        if (n2c[node] == comm_num)
        {
            nodes.push_back(node);
        }
    }
    return nodes;
}

vector<int> Partition::GetNodesInCommunity(int comm_num, vector<int> subset) 
{
    vector<int> nodes;
    int size = subset.size();
    for (int i = 0; i < size; i++) 
    {
        if (n2c[subset[i]] == comm_num)
        {
            nodes.push_back(subset[i]);
        }
    }
    return nodes;
}

#include "partition.h"

using namespace std;

Partition::Partition(Graph* g)
  : g(g)
{
  size = g->NodesCount;

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

double Partition::Modularity()
{
  double q  = 0.;
  double m2 = (double)g->totalWeight;
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
  map<int,int> res;
  pair<int *,int *> p = g->Neighbors(node);

  int deg = g->GetDergeeOf(node);

  res.insert(make_pair(n2c[node],0));

  for (int i=0 ; i<deg ; i++)
  {
    int neigh = *(p.first+i);
    int neigh_comm = n2c[neigh];
    int neigh_weight = (g->weights==NULL)?1:*(p.second+i);

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
    if (renumber[i]!=-1)
    {
      renumber[i]=final++;
    }
  }

  vector<vector<int> > comm_nodes(final);
  for (int node=0 ; node<size ; node++)
  {
    comm_nodes[renumber[n2c[node]]].push_back(node);
  }

  return MakeGraph(comm_nodes,renumber);
}

Graph Partition::MakeGraph(vector<vector<int> > comm_nodes, vector<int> renumber)
{
  Graph graph;
  graph.NodesCount = comm_nodes.size();
  graph.degrees  = (int *)malloc(comm_nodes.size()*4);
  graph.links = (int *)malloc((long)10000000*8);
  graph.weights  = (int *)malloc((long)10000000*8);

  long where = 0;
  int comm_deg = comm_nodes.size();
  for (int comm=0 ; comm<comm_deg ; comm++)
  {
    map<int,int> m;
    map<int,int>::iterator it;

    int comm_size = comm_nodes[comm].size();
    for (int node=0 ; node<comm_size ; node++)
    {
      pair<int *,int *> p = g->Neighbors(comm_nodes[comm][node]);
      int deg = g->GetDergeeOf(comm_nodes[comm][node]);
      for (int i=0 ; i<deg ; i++) {
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

  realloc(g->links, (long)graph.nbLinks*4);
  realloc(g->weights, (long)graph.nbLinks*4);

  return graph;
}

// TODO
std::vector<Community> Partition::GetCommunities()
{

}
#ifndef GRAPHBINARY_H
#define GRAPHBINARY_H

#include <string>
#include <assert.h>
#include <vector>

#define WEIGHTED   0
#define UNWEIGHTED 1

struct Graph 
{
    //private:
        int NodesCount;
        int nbLinks;
        int totalWeight;
        int *degrees;
        int *norms;
        int *links;
        int *weights;

    public:
        Graph(); //noexcept;
        // binary file format is
        // 4 bytes for the number of nodes in the graph
        // 4*(nb_nodes) bytes for the cumulative degree for each node:
        //    deg(0)=degrees[0]
        //    deg(k)=degrees[k]-degrees[k-1]
        // 4*(sum_degrees) bytes for the links
        // IF WEIGHTED 4*(sum_degrees) bytes for the weights
        Graph(std::string filename, int type);
        Graph(const Graph &graph);
        ~Graph();

        inline int GetDergeeOf(int node);

        inline int GetCountSelfloopsOf(int node);

        inline int WeightedDegree(int node);

        inline int GetNodesCount();

        inline int GetTotalWeight();
        inline void isValidNode(int node);
        // return pointers to the first neighbor and first weight of the node
        inline std::pair<int *, int *> Neighbors(int node);

    
};

inline void Graph::isValidNode(int node) 
{
    assert(node>=0 && node<NodesCount);
}

inline int Graph::GetDergeeOf(int node)
{
    isValidNode(node);
    // return _degrees[node.GetNumber()];

    if (node==0)
    {
        return degrees[0];
    }
    else
    {
        return degrees[node]-degrees[node-1];
    }
}

inline int Graph::GetCountSelfloopsOf(int node)
{
    isValidNode(node);

    std::pair<int *,int *> p = Neighbors(node);
    for (int i=0 ; i<GetDergeeOf(node) ; i++)
    {
        if (*(p.first+i)==node)
        {
            if (weights!=NULL)
            {
                return *(p.second+i);
            }
            else
            {
                return 1;
            }
        }
    }
    return 0;
}

inline int Graph::WeightedDegree(int node)
{
    isValidNode(node);

    std::pair<int *,int *> p = Neighbors(node);
    if (p.second==NULL)
    {
        return GetDergeeOf(node);
    }
    else {
        int res = 0;
        for (int i=0 ; i<GetDergeeOf(node) ; i++)
        {
            res += *(p.second+i);
        }
        return res;
    }
}

inline std::pair<int *,int *> Graph::Neighbors(int node)
{   
    isValidNode(node);

    if (node==0)
    {
        return std::make_pair(links, weights);
    }
    else if (weights!=NULL)
    {
        return std::make_pair(links+(long)degrees[node-1], weights+(long)degrees[node-1]);
    }
    else
    {
        return std::make_pair(links+(long)degrees[node-1], weights);
    }
}

inline int Graph::GetNodesCount() 
{
    return NodesCount;
}

inline int Graph::GetTotalWeight()
{
    return totalWeight;
}

#endif // GRAPH_H
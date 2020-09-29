using System;
using System.Collections.Generic;
using QuikGraph.Collections;
using System.Runtime.CompilerServices;
using QuikGraph;

[assembly: InternalsVisibleTo("GraphClusteringTest")]
namespace GraphClustering
{
    internal sealed class CommunityManager<TVertex> 
    {
        IEdgeListAndIncidenceGraph<TVertex, Edge<TVertex>> _graph;
        public CommunityManager(IEdgeListAndIncidenceGraph<TVertex, Edge<TVertex>> graph) 
        {
            if (graph == null) 
            {
                throw new ArgumentNullException("TODO");
            }
            _graph = graph;
        }

        public int GetEdgeCountBetween(TVertex vertex, ICommunity<TVertex> community) 
        {
            throw new NotImplementedException("TODO");
        }
        public int GetEdgeCountBetween(ICommunity<TVertex> firstCommunity, ICommunity<TVertex> secondCommunity)
        {
            throw new NotImplementedException("TODO");
        }

        public int GetEdgeCount(ICommunity<TVertex> community) 
        {
            throw new NotImplementedException("TODO");
        }

    }

}
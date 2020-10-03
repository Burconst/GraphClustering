using System;
using System.Collections.Generic;
using QuikGraph.Collections;
using System.Runtime.CompilerServices;
using QuikGraph;

#if DEBUG
[assembly: InternalsVisibleTo("GraphClusteringTest")]
#endif
namespace GraphClustering
{
    internal sealed class CommunityManager<TVertex> 
    {
        IEdgeListAndIncidenceGraph<TVertex, IEdge<TVertex>> _graph;
        public CommunityManager(IEdgeListAndIncidenceGraph<TVertex, IEdge<TVertex>> graph) 
        {
            if (graph == null) 
            {
                throw new ArgumentNullException("Graph should be not null");
            }
            _graph = graph;
        }

        public bool IsValidCommunity(ICommunity<TVertex> community)
        {
            throw new NotImplementedException("TODO");
        }

        public int GetEdgeCount(ICommunity<TVertex> community) 
        {
            throw new NotImplementedException("TODO");
        }

        public int GetEdgeCount(TVertex fromVertex, ICommunity<TVertex> toCommunity) 
        {
            throw new NotImplementedException("TODO");
        }
        
        public int GetEdgeCount(ICommunity<TVertex> fromCommunity, TVertex toVertex) 
        {
            throw new NotImplementedException("TODO");
        }

        public int GetEdgeCount(ICommunity<TVertex> fromCommunity, ICommunity<TVertex> toCommunity)
        {
            throw new NotImplementedException("TODO");
        }

    }

}
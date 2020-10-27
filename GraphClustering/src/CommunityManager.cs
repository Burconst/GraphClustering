using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


#if DEBUG
[assembly: InternalsVisibleTo("GraphClusteringTest")]
#endif
namespace GraphClustering
{
    internal sealed class CommunityManager<TVertex> 
    {
        private readonly IPartitionableGraph<TVertex,IEdge<TVertex>> _graph;
        public CommunityManager(IPartitionableGraph<TVertex,IEdge<TVertex>> graph) 
        {
            if (graph == null) 
            {
                throw new ArgumentNullException("Graph should be not null");
            }
            _graph = graph;
        }

        public bool IsValidCommunity(ICommunity<TVertex> community)
        {
            foreach(var vertex in community) 
            {
                if(!_graph.Contains(vertex)) 
                {
                    return false;
                }
            }
            return true;
        }

        public int GetEdgeCount(ICommunity<TVertex> community) 
        {
            if(community == null) 
            {
                throw new ArgumentNullException("Community shouldn't be null.");
            }
            int edgeCount = GetEdgeCount(community,community);
            if (!_graph.IsDirected) 
            {
                edgeCount = (edgeCount+_graph.GetSelfloopCount())/2;
            }
            return edgeCount;
        }

        public int GetEdgeCount(TVertex fromVertex, ICommunity<TVertex> toCommunity) 
        {
            if(toCommunity == null) 
            {
                throw new ArgumentNullException("Community shouldn't be null.");
            }
            int edgeCount = 0;
            foreach(var edge in _graph.OutEdges(fromVertex)) 
            {
                if(toCommunity.Contains(edge.Target)) 
                {
                    edgeCount++;
                }
            }
            return edgeCount;
        }
        
        public int GetEdgeCount(ICommunity<TVertex> fromCommunity, TVertex toVertex) 
        {
            int edgeCount = 0;
            if(fromCommunity == null) 
            {
                throw new ArgumentNullException("Community shouldn't be null.");
            }
            foreach(var vertex in fromCommunity) 
            {
                edgeCount += _graph.EdgeCountBetween(vertex, toVertex);
            }
            return edgeCount;
        }

        public int GetEdgeCount(ICommunity<TVertex> fromCommunity, ICommunity<TVertex> toCommunity)
        {
            int edgeCount = 0;

            if(fromCommunity == null || toCommunity == null) 
            {
                throw new ArgumentNullException("Community shouldn't be null.");
            }
            foreach(var vertex in fromCommunity) 
            {
                edgeCount += GetEdgeCount(vertex, toCommunity);
            }

            return edgeCount;
        }

    }

}
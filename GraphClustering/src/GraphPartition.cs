using System;
using System.Collections.Generic;
using QuikGraph;

namespace GraphClustering 
{
    public sealed class GraphPartition<TVertex> : IPartition<TVertex>
    {
        private readonly List<ICommunity<TVertex>> _communities;
        
        public IEdgeListAndIncidenceGraph<TVertex, Edge<TVertex>> Graph
        {
            get;
        }

        public GraphPartition(IEdgeListAndIncidenceGraph<TVertex, Edge<TVertex>> graph) 
        {
            if (graph == null) 
            {
                throw new ArgumentNullException("TODO");
            }
            Graph = graph;
            _communities = new List<ICommunity<TVertex>>();
            foreach(var vertex in Graph.Vertices) 
            {
                _communities.Add(new Community<TVertex>(vertex));
            }
        }

        public int GetCommunityCount() 
        {
            return _communities.Count;
        }

        public int GetCommunityNumber(TVertex vertex) 
        {
            throw new NotImplementedException("TODO");
        }
        
        public void PushVertexToCommunity(TVertex vertex, int communityNumber) 
        {
            throw new NotImplementedException("TODO");
        }

        public void PushVertexToCommunity(TVertex vertex, ICommunity<TVertex> community) 
        {
            throw new NotImplementedException("TODO");
        }

        public AdjacencyGraph<TVertex, Edge<TVertex>> AggregatePartition() 
        {
            throw new NotImplementedException("TODO");
        }
        
    }

}

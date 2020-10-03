using System;
using System.Collections.Generic;
using QuikGraph;

namespace GraphClustering 
{
    public sealed class GraphPartition<TVertex> : IPartition<TVertex>
    {
        private readonly List<ICommunity<TVertex>> _communities;
        private readonly CommunityManager<TVertex> _communityManager;
        public IEdgeListAndIncidenceGraph<TVertex, IEdge<TVertex>> Graph
        {
            get;
        }

        public GraphPartition(IEdgeListAndIncidenceGraph<TVertex, IEdge<TVertex>> graph) 
        {
            if (graph == null) 
            {
                throw new ArgumentNullException("TODO");
            }
            Graph = graph;
            _communityManager = new CommunityManager<TVertex>(graph);
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

        public int? GetCommunityNumber(TVertex vertex) 
        {
            throw new NotImplementedException("TODO");
        }
        
        public void AddVertexToCommunity(TVertex vertex, int communityNumber) 
        {
            throw new NotImplementedException("TODO");
        }

        public void RemoveVertexFromCommunity(TVertex vertex, int communityNumber)
        {
            throw new NotImplementedException("TODO");
        } 

        public int GetEdgeCountBetween(TVertex vertex, int communityNumber) 
        {
            throw new NotImplementedException("TODO");
        }
        public int GetEdgeCountBetween(int firstCommunityNumber, int secondCommunityNumber) 
        {
            throw new NotImplementedException("TODO");
        }

        public IEnumerable<TVertex> GetVerticesFromCommunity(int communityNumber) 
        {
            throw new NotImplementedException("TODO");
        }

        public IEdgeListAndIncidenceGraph<TVertex, Edge<TVertex>> AggregatePartition() 
        {
            throw new NotImplementedException("TODO");
        }
        
    }

}

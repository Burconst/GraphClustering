using System;
using System.Collections.Generic;
using QuikGraph;

namespace GraphClustering 
{
    public sealed class GraphPartition<TVertex> : IGraphPartition<TVertex>
    {
        private readonly ICollection<ICommunity<TVertex>> _communities;
        private readonly CommunityManager<TVertex> _communityManager;

        public IEdgeListAndIncidenceGraph<TVertex, IEdge<TVertex>> Graph
        {
            get;
        }

        public GraphPartition(IEdgeListAndIncidenceGraph<TVertex, IEdge<TVertex>> graph, PartitionType type = PartitionType.Singletone) 
        {
            Graph = graph ?? throw new ArgumentNullException("The graph cannot be null.");
            _communityManager = new CommunityManager<TVertex>(graph);
            _communities = new List<ICommunity<TVertex>>();
            switch (type)
            {
                case PartitionType.Singletone:
                    foreach(var vertex in Graph.Vertices)
                    {
                        _communities.Add(new Community<TVertex>(vertex));
                    }
                    break;
                default: 
                    throw new ArgumentException("Wrong partition type value.");
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
        
        public void AddVertexToCommunity(TVertex vertex, int communityNumber) 
        {
            throw new NotImplementedException("TODO");
        }

        public void RemoveVertexFromCommunity(TVertex vertex)
        {
            throw new NotImplementedException("TODO");
        }

        public void RemoveVertexFromCommunity(TVertex vertex, int communityNumber)
        {
            throw new NotImplementedException("TODO");
        } 

        public int UniteCommunities(int firstCommunityNumber, int secondCommunityNumber) 
        {
            throw new NotImplementedException("TODO");
        }

        public int UniteCommunities(IEnumerable<int> communityNumbers) 
        {
            throw new NotImplementedException("TODO");
        }

        public int GetEdgeCount(TVertex fromVertex, int toCommunityNumber) 
        {
            throw new NotImplementedException("TODO");
        }

        public int GetEdgeCount(int fromCommunityNumber, int toCommunityNumber) 
        {
            throw new NotImplementedException("TODO");
        }

        public IEnumerable<TVertex> GetVerticesFromCommunity(int communityNumber) 
        {
            throw new NotImplementedException("TODO");
        }

        public IEdgeListAndIncidenceGraph<TVertex, IEdge<TVertex>> AggregatePartition() 
        {
            throw new NotImplementedException("TODO");
        }

        public IEnumerator<ICommunity<TVertex>> GetEnumerator() => _communities.GetEnumerator();
        
    }

}

using System;
using System.Collections.Generic;

namespace GraphClustering 
{
    public sealed class GraphPartition<TVertex> : IGraphPartition<TVertex>
    {
        private readonly Dictionary<int,ICommunity<TVertex>> _communities;
        private readonly CommunityManager<TVertex> _communityManager;

        public IPartitionableGraph<TVertex,IEdge<TVertex>> Graph
        {
            get;
        }
        
        public GraphPartition(IPartitionableGraph<TVertex,IEdge<TVertex>> graph) : this(graph, PartitionType.Singletone) 
        {
        }

        public GraphPartition(IPartitionableGraph<TVertex,IEdge<TVertex>> graph, PartitionType type) 
        {
            Graph = graph ?? throw new ArgumentNullException("The graph cannot be null.");
            _communityManager = new CommunityManager<TVertex>(graph);
            _communities = new Dictionary<int,ICommunity<TVertex>>();
            switch (type)
            {
                case PartitionType.Singletone:
                    int communityNumber = 0;
                    foreach(var vertex in Graph.Vertices)
                    {
                        _communities.Add(communityNumber, new Community<TVertex>(vertex));
                        communityNumber++;
                    }
                    break;
                default: 
                    throw new ArgumentException("Wrong partition type value.");
            }
        }

        public int GetCommunityCount() => _communities.Count;

        public int GetCommunityNumber(TVertex vertex) 
        {
            foreach(var community in _communities)
            {
                if(community.Value.Contains(vertex))
                {
                    return community.Key;
                }
            }  
            throw new ArgumentException("Can't find vertex.");
        }
        
        public bool MoveVertexToCommunity(TVertex vertex, int communityNumber) 
        {
            validateCommunityNumber(communityNumber);
            RemoveVertexFromCommunity(vertex, GetCommunityNumber(vertex));
            return _communities[communityNumber].Add(vertex);
        }

        public bool RemoveVertexFromCommunity(TVertex vertex)
        {
            foreach(var community in _communities.Values)
            {
                if(community.Remove(vertex))
                {
                    return true;
                }
            } 
            return false;
        }

        public bool RemoveVertexFromCommunity(TVertex vertex, int communityNumber)
        {
            validateCommunityNumber(communityNumber);
            return _communities[communityNumber].Remove(vertex);
        } 

        public int UniteCommunities(int firstCommunityNumber, int secondCommunityNumber) 
        {
            if (firstCommunityNumber == secondCommunityNumber) 
            {
                return firstCommunityNumber;
            }
            try 
            {
                _communities[firstCommunityNumber].Add(_communities[secondCommunityNumber].Vertices);
            } 
            catch 
            {

            }
            _communities.Remove(secondCommunityNumber);
            return firstCommunityNumber;
        }

        public int UniteCommunities(IEnumerable<int> communityNumbers) 
        {
            int? minCommunityNumber = null;
            bool thisIsFirstIteration = true;
            foreach(var communityNumber in communityNumbers) 
            {
                if (thisIsFirstIteration) 
                {
                    minCommunityNumber = communityNumber;
                    thisIsFirstIteration = false;
                    continue;
                }
                if (minCommunityNumber > communityNumber) 
                {
                    UniteCommunities(communityNumber, minCommunityNumber.Value);
                    minCommunityNumber = communityNumber;
                }
                else 
                {
                    UniteCommunities(minCommunityNumber.Value, communityNumber);
                }
            }

            if (!minCommunityNumber.HasValue) 
            {
                throw new Exception("TODO");
            }
            return minCommunityNumber.Value;
        }

        public int GetEdgeCount(TVertex fromVertex, int toCommunityNumber) 
        {
            validateCommunityNumber(toCommunityNumber);
            return _communityManager.GetEdgeCount(fromVertex, _communities[toCommunityNumber]);
        }

        public int GetEdgeCount(int fromCommunityNumber, int toCommunityNumber) 
        {
            validateCommunityNumber(fromCommunityNumber);
            return _communityManager.GetEdgeCount(_communities[fromCommunityNumber], _communities[toCommunityNumber]);
        }

        public IEnumerable<TVertex> GetCommunityVertices(int communityNumber) 
        {
            if(!_communities.TryGetValue(communityNumber, out _)) 
            {
                throw new ArgumentException("TODO");
            }
            return _communities[communityNumber].Vertices;
        }

        private void validateCommunityNumber(int communityNumber) 
        {
            if(!_communities.TryGetValue(communityNumber, out _)) 
            {
                throw new KeyNotFoundException($"Community {communityNumber} not found.");
            }
        }

        public bool RemoveCommunity(int communityNumber)
        {
            validateCommunityNumber(communityNumber);
            return _communities.Remove(communityNumber);
        }

        public IEnumerator<ICommunity<TVertex>> GetEnumerator() => _communities.Values.GetEnumerator();

        public override string ToString()
        {
            var stringView = new System.Text.StringBuilder();
            foreach(var community in _communities) 
            {
                stringView.Append($"Community {community.Key} -> {community.Value.ToString()} \n");
            }
            return stringView.ToString();
        }

    }

}

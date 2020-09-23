using System;
using System.Collections.Generic;
using QuikGraph;

namespace GraphClustering 
{
    public class Partition<TVertex> : IPartition<TVertex>
    {
        private readonly List<Community<TVertex>> _communities;

        public  AdjacencyGraph<TVertex, Edge<TVertex>> Graph
        {
            get;
            private set;
        }

        public int Size
        {
            get { return _communities.Count; } 
        }

        public Partition(AdjacencyGraph<TVertex, Edge<TVertex>> graph) 
        {
            Graph = graph;
            _communities = new List<Community<TVertex>>();
            foreach(var vertex in Graph.Vertices) 
            {
                _communities.Add(new Community<TVertex>(vertex));
            }
        }

        public double? GetModularity()
        {
            throw new NotImplementedException();
        }

        public int GetCommunityNumber(TVertex vertex) 
        {
            throw new NotImplementedException("TODO");
        }
        
        public void PushVertexToCommunity(TVertex vertex, int communityNumber) 
        {
            throw new NotImplementedException("TODO");
        }

        public AdjacencyGraph<TVertex, Edge<TVertex>> AggregatePartition() 
        {
            throw new NotImplementedException("TODO");
        }
        
    }

}

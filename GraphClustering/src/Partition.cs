using System;
using System.Collections.Generic;
using QuikGraph;
using QuikGraph.Collections;


namespace GraphClustering 
{
    public class Partition<TVertex> : Partition
    {
        private List<Community<TVertex>> Communities;
        public  AdjacencyGraph<TVertex, Edge<TVertex>> Graph
        {
            get;
            private set;
        }

        public int Size
        {
            get { return Communities.Count; } 
        }

        public Partition(AdjacencyGraph<TVertex, Edge<TVertex>> graph) 
        {
            Graph = graph;
            Communities = new List<Community<TVertex>>();
            foreach(var vertex in Graph.Vertices) 
            {
                Communities.Add(new Community<TVertex>(vertex));
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

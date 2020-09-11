using System;
using System.Collections.Generic;
using QuikGraph;
using QuikGraph.Collections;


namespace GraphClustering 
{
    public class Partition<TVertex>
    {
        private List<Community<TVertex>> Communities;
        public  AdjacencyGraph<TVertex, SEdge<TVertex>> Graph
        {
            get;
            private set;
        }

        public int Size
        {
            get { return Communities.Count; } 
        }

        public Partition(AdjacencyGraph<TVertex, SEdge<TVertex>> graph) 
        {
            Graph = graph;
            foreach(var vertex in Graph.Vertices) 
            {
                Communities.Add(new Community<TVertex>(vertex));
            }
        }

        public double? GetModularity()
        {
            throw new NotImplementedException();
        }

    }

}

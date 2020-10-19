using System.Collections.Generic;

namespace GraphClustering.UnitTests
{
    public class UndirectedGraph<TVertex, TEdge> : IPartitionableGraph<TVertex, TEdge> where TEdge : IEdge<TVertex>
    {
        private QuikGraph.UndirectedGraph<TVertex, QuikGraph.IEdge<TVertex>> _graph;
        public UndirectedGraph()
        {
            _graph = new QuikGraph.UndirectedGraph<TVertex, QuikGraph.IEdge<TVertex>>();
        }
        public IEnumerable<TVertex> Vertices => _graph.Vertices;
        public int VertexCount => _graph.VertexCount;
        public int EdgeCount => _graph.EdgeCount;
        public bool AddVertex(TVertex vertex) => _graph.AddVertex(vertex);
        public bool AddVerticesAndEdge(IEdge<TVertex> edge) => _graph.AddVerticesAndEdge(new QuikGraph.Edge<TVertex>(edge.Source, edge.Target));
        public bool Contains(TVertex vertex) => _graph.ContainsVertex(vertex);

        public int EdgeCountBetween(TVertex source, TVertex target)
        {
            if(_graph.AllowParallelEdges) 
            {
                IEnumerable<QuikGraph.IEdge<TVertex>> edges = _graph.AdjacentEdges(source);
                int counter = 0;
                foreach(var edge in edges) 
                {
                    if(edge.Target.Equals(target)) 
                    {
                        counter++;
                    }
                }
                return counter;
            }
            if(_graph.TryGetEdge(source,target, out _) || _graph.TryGetEdge(target,source, out _)) 
            {
                return 1;
            }
            return 0;
        }

        public IEnumerable<IEdge<TVertex>> OutEdges(TVertex vertex) 
        {
            var outEdges = new List<IEdge<TVertex>>();
            foreach(var edge in _graph.AdjacentEdges(vertex)) 
            {
                if (!edge.Source.Equals(vertex))
                {
                    outEdges.Add((IEdge<TVertex>)new Edge<TVertex>(edge.Target,edge.Source));
                    continue;
                }
                outEdges.Add((IEdge<TVertex>)new Edge<TVertex>(edge.Source,edge.Target));
            }
            return outEdges;
        }
    }
}
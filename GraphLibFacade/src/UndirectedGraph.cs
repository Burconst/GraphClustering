using System.Collections.Generic;
using GraphClustering;

namespace GraphLibFacade
{
    public class UndirectedGraph<TVertex, TEdge> : IPartitionableGraph<TVertex, TEdge> where TEdge : IEdge<TVertex>
    {
        private readonly QuikGraph.UndirectedGraph<TVertex, QuikGraph.IEdge<TVertex>> _graph;

        public UndirectedGraph()
        {
            _graph = new QuikGraph.UndirectedGraph<TVertex, QuikGraph.IEdge<TVertex>>();
        }
        public IEnumerable<TVertex> Vertices => _graph.Vertices;
        public int VertexCount => _graph.VertexCount;
        public int EdgeCount => _graph.EdgeCount;

        public bool IsDirected => _graph.IsDirected;

        public bool AddVertex(TVertex vertex) => _graph.AddVertex(vertex);
        public bool AddVerticesAndEdge(IEdge<TVertex> edge) => _graph.AddVerticesAndEdge(new QuikGraph.Edge<TVertex>(edge.Source, edge.Target));
        public bool Contains(TVertex vertex) => _graph.ContainsVertex(vertex);

        public int EdgeCountBetween(TVertex source, TVertex target)
        {
            if(_graph.TryGetEdge(source,target, out _) || _graph.TryGetEdge(target,source, out _)) 
            {
                return 1;
            }
            return 0;
        }

        public int GetSelfloopCount()
        {
            int count = 0;
            foreach (var edge in _graph.Edges)
            {
                if(edge.Source.Equals(edge.Target)) 
                {
                    count++;
                }
            }
            return count;
        }

        public IEnumerable<IEdge<TVertex>> OutEdges(TVertex vertex) 
        {
            var outEdges = new List<IEdge<TVertex>>();
            foreach(var edge in _graph.AdjacentEdges(vertex)) 
            {
                if(edge.Source.Equals(edge.Target) && edge.Source.Equals(vertex))
                {
                    outEdges.Add((IEdge<TVertex>)new Edge<TVertex>(edge.Target,edge.Source));
                    continue;
                }
                if(edge.Source.Equals(vertex)) 
                {
                    outEdges.Add((IEdge<TVertex>)new Edge<TVertex>(edge.Source,edge.Target));
                    continue;
                }
                outEdges.Add((IEdge<TVertex>)new Edge<TVertex>(edge.Target,edge.Source));
            }
            return outEdges;
        }
    }
}
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

    }
}
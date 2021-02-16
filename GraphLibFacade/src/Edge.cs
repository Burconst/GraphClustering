using GraphClustering;

namespace GraphLibFacade 
{
    public class Edge<TVertex> : IEdge<TVertex>
    {
        private readonly QuikGraph.Edge<TVertex> _edge;

        public Edge(TVertex source, TVertex target) 
        {
            _edge = new QuikGraph.Edge<TVertex>(source, target);
        }
        public TVertex Source => _edge.Source;

        public TVertex Target => _edge.Target;
        
    }
}
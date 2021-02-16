using GraphClustering;

namespace GraphLibFacade 
{
    public class WeightEdge<TVertex, TWeight> : IWeightedEdge<TVertex, TWeight>
    {
        private readonly QuikGraph.Edge<TVertex> _edge;

        public TWeight Weight { get; }

        public TVertex Source =>_edge.Source;

        public TVertex Target => _edge.Target;

        public WeightEdge(TVertex source, TVertex target, TWeight weight) 
        {
            _edge = new QuikGraph.Edge<TVertex>(source, target);
            Weight = weight;
        }

    } 
}
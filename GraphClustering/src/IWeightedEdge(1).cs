namespace GraphClustering 
{
    public interface IWeightedEdge<TVertex, TWeight> : IEdge<TVertex> 
    {
        TWeight Weight { get; }
    }
}
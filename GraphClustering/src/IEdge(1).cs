namespace GraphClustering 
{
    public interface IEdge<out TVertex>
    {
        TVertex Source { get; }
        TVertex Target { get; }
    }
}
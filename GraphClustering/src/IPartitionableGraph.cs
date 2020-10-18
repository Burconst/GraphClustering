using System.Collections.Generic;

namespace GraphClustering 
{
    public interface IPartitionableGraph<TVertex,out TEdge> where TEdge : IEdge<TVertex>
    {   
        IEnumerable<TVertex> Vertices { get; }
        int VertexCount { get; } 
        int EdgeCount { get; }
        bool AddVertex(TVertex vertex);
        bool AddVerticesAndEdge(IEdge<TVertex> edge);
    }
}
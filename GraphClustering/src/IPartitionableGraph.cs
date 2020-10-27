using System.Collections.Generic;

namespace GraphClustering 
{
    public interface IPartitionableGraph<TVertex,out TEdge> where TEdge : IEdge<TVertex>
    {   
        bool IsDirected { get; }
        IEnumerable<TVertex> Vertices { get; }
        int VertexCount { get; } 
        int EdgeCount { get; }
        bool Contains(TVertex vertex);
        bool AddVertex(TVertex vertex);
        bool AddVerticesAndEdge(IEdge<TVertex> edge);
        IEnumerable<IEdge<TVertex>> OutEdges(TVertex vertex);
        
        int EdgeCountBetween(TVertex source, TVertex target);

        int GetSelfloopCount();

    }
}
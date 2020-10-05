using System;
using System.Collections.Generic;
using QuikGraph;

namespace GraphClustering 
{
    interface IGraphPartition<TVertex>
    {
        int GetCommunityCount();
        int? GetCommunityNumber(TVertex vertex);
        void AddVertexToCommunity(TVertex vertex, int communityNumber);
        void RemoveVertexFromCommunity(TVertex vertex);
        void RemoveVertexFromCommunity(TVertex vertex, int communityNumber);
        int GetEdgeCountBetween(TVertex vertex, int communityNumber);
        int GetEdgeCountBetween(int firstCommunityNumber, int secondCommunityNumber);
        IEnumerable<TVertex> GetVerticesFromCommunity(int communityNumber);
        IEdgeListAndIncidenceGraph<TVertex, IEdge<TVertex>> AggregatePartition();
        IEnumerator<ICommunity<TVertex>> GetEnumerator();
    }

}
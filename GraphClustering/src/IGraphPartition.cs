using System;
using System.Collections.Generic;
using QuikGraph;

namespace GraphClustering 
{
    interface IGraphPartition<TVertex>
    {
        int GetCommunityCount();
        int GetCommunityNumber(TVertex vertex);
        void AddVertexToCommunity(TVertex vertex, int communityNumber);
        void RemoveVertexFromCommunity(TVertex vertex);
        void RemoveVertexFromCommunity(TVertex vertex, int communityNumber);
        int UniteCommunities(IEnumerable<int> communityNumbers);
        int UniteCommunities(int firstCommunityNumber, int secondCommunityNumber);
        int GetEdgeCount(TVertex fromVertex, int toCommunityNumber);
        int GetEdgeCount(int fromCommunityNumber, int toCommunityNumber);
        IEnumerable<TVertex> GetVerticesFromCommunity(int communityNumber);
        IEdgeListAndIncidenceGraph<TVertex, IEdge<TVertex>> AggregatePartition();
        IEnumerator<ICommunity<TVertex>> GetEnumerator();
    }

}
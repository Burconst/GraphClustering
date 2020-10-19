using System.Collections.Generic;

namespace GraphClustering 
{
    public interface IGraphPartition<TVertex>
    {
        IPartitionableGraph<TVertex,IEdge<TVertex>> Graph { get; }
        int GetCommunityCount();
        int GetCommunityNumber(TVertex vertex);
        bool MoveVertexToCommunity(TVertex vertex, int communityNumber);
        bool RemoveCommunity(int communityNumber);
        bool RemoveVertexFromCommunity(TVertex vertex);
        bool RemoveVertexFromCommunity(TVertex vertex, int communityNumber);
        int UniteCommunities(IEnumerable<int> communityNumbers);
        int UniteCommunities(int firstCommunityNumber, int secondCommunityNumber);
        int GetEdgeCount(TVertex fromVertex, int toCommunityNumber);
        int GetEdgeCount(int fromCommunityNumber, int toCommunityNumber);
        IEnumerable<TVertex> GetCommunityVertices(int communityNumber);
        IEnumerator<ICommunity<TVertex>> GetEnumerator();
    }

}
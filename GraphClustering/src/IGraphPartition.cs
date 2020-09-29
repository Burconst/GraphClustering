using System;
using System.Collections.Generic;
using QuikGraph;

namespace GraphClustering 
{
    interface IPartition<TVertex>
    {
        int GetCommunityCount();
        int GetCommunityNumber(TVertex vertex);
        void PushVertexToCommunity(TVertex vertex, int communityNumber);
        void PushVertexToCommunity(TVertex vertex, ICommunity<TVertex> community);
        AdjacencyGraph<TVertex, Edge<TVertex>> AggregatePartition();

    }

}
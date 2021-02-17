namespace GraphClustering.UnitTests.Builders
{
    internal static class CommunityManagerBuilder
    {
        public static CommunityManager<TVertex> Create<TVertex>(IPartitionableGraph<TVertex, IEdge<TVertex>> graph)
        {
            return new CommunityManager<TVertex>(graph);
        }
    }

}
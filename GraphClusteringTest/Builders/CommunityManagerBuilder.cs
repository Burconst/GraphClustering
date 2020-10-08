using QuikGraph;

namespace GraphClustering.UnitTests.Builders
{
    internal static class CommunityManagerBuilder
    {
        public static CommunityManager<TVertex> Create<TVertex>(IEdgeListAndIncidenceGraph<TVertex, IEdge<TVertex>> graph)
        {
            return new CommunityManager<TVertex>(graph);
        }

    }

}
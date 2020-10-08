using QuikGraph;

namespace GraphClustering.UnitTests.Builders
{
    public static class PartitionBuilder 
    {
        public static IGraphPartition<TVertex> Create<TVertex>(IEdgeListAndIncidenceGraph<TVertex, IEdge<TVertex>> graph)
        {
            return Create<TVertex>(graph,PartitionType.Singletone);    
        }

        public static IGraphPartition<TVertex> Create<TVertex>(IEdgeListAndIncidenceGraph<TVertex, IEdge<TVertex>> graph, PartitionType type)
        {
            return new GraphPartition<TVertex>(graph, type);
        }

    }
}
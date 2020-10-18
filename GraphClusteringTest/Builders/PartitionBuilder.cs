namespace GraphClustering.UnitTests.Builders
{
    public static class PartitionBuilder 
    {
        public static IGraphPartition<TVertex> Create<TVertex>(IPartitionableGraph<TVertex, IEdge<TVertex>> graph)
        {
            return new GraphPartition<TVertex>(graph);    
        }

        public static IGraphPartition<TVertex> Create<TVertex>(IPartitionableGraph<TVertex, IEdge<TVertex>> graph, PartitionType type)
        {
            return new GraphPartition<TVertex>(graph, type);
        }

    }
}
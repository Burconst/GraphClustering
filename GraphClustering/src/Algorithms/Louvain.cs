using System;

namespace GraphClustering.Algorithms
{
    public static class Louvain<TVertex>
    {
        public static IGraphPartition<TVertex> GetPartition(IPartitionableGraph<TVertex, IEdge<TVertex>> graph, Metrics.PartitionMetric<TVertex> metric) 
        {
            throw new NotImplementedException();
        }

        private static IGraphPartition<TVertex> MoveNodes(IGraphPartition<TVertex> partition) 
        {
            throw new NotImplementedException();
        }

        


    }
}
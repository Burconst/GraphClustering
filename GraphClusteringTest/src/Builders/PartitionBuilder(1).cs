using System.Collections.Generic;

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

        public static Dictionary<string, List<IGraphPartition<TVertex>>> GetPartitions<TVertex>() 
        {
            var graphs = GraphLibFacade.GraphBuilder.GetGraphs();
            var partitions = new Dictionary<string, List<IGraphPartition<TVertex>>>();
            

            IGraphPartition<TVertex> makePartition(string graphName, IPartitionableGraph<TVertex, IEdge<TVertex>> graph, List<(TVertex,int)> communities)
            {
                var newPartition = Create(graph);    
                foreach (var pair in communities)
                {
                    newPartition.MoveVertexToCommunity(pair.Item1, pair.Item2);
                }
                return newPartition;
            }

            return partitions;
        }

    }
}
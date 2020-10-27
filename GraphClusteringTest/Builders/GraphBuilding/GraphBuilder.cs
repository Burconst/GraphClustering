using System.Collections.Generic;

namespace GraphClustering.UnitTests.Builders
{
    public static class GraphBuilder
    {
        public static Dictionary<string, IPartitionableGraph<int, IEdge<int>>> GetGraphsDict()
        {   
            var _graphDict = new Dictionary<string, IPartitionableGraph<int, GraphClustering.IEdge<int>>>();
            _graphDict.Add("DGraph1", CreateGraph<int>(
                new [] 
                {
                    (1,0), (7,5), (5,1), (3,7),
                    (4,3), (7,0), (5,0), (8,6),
                    (2,6), (10,9),(10,2),(11,6),
                    (10,11)
                },
                true
            ));
            _graphDict.Add("DGraph2",CreateGraph<int>(
                new [] 
                {
                    (0,2), (0,4), (0,5), (1,4),
                    (1,5), (2,3), (2,4), (4,5)
                },
                true
            ));
            _graphDict.Add("DGraph3",CreateGraph<int>(
                new [] 
                {
                    (1,1), (5,12),  (12,11),
                    (11,4),  (2,4), (2,12),  (5,9),
                    (8,6),  (6,13), (13,8),  (3,10),
                    (7,10), (10,15),(15,14), (6,14),
                    (14,6), (15,8), (8,10),  (9,11)
                },
                true, new [] { 0, 1 }
            ));
            _graphDict.Add("DGraph4",CreateGraph<int>(
                new [] 
                {
                    (0,2),  (0,4), (0,5),  (1,4),
                    (1,5),  (2,3), (2,4),  (4,5),
                    (8,3),  (6,3), (6,7),  (7,8),
                    (7,3),  (9,1),(9,10), (9,12),
                    (9,11)
                },
                true
            ));
            _graphDict.Add("DGraph5",CreateGraph<int>(
                new [] 
                {
                    (8,9),  (5,9), (3,9),  (4,9),
                    (6,9),  (2,9),(7,10), (1,10),
                    (10,0)
                },
                true
            ));
            _graphDict.Add("UGraph1",CreateGraph<int>(
                new [] 
                {
                    (0,1), (0,0), (1,2), (1,3),
                    (4,2), (4,0), (5,3), (1,5),
                    (6,2), (6,7), (3,7),
                    (8,0), (8,4), (5,9)
                },
                false
            ));
            _graphDict.Add("UGraph2",CreateGraph<int>(
                new [] 
                {
                    (8,8), (7,7), (2,3), (8,3),
                    (0,8), (2,5), (5,1), (1,3),
                    (3,9), (0,9), (0,7), (7,6),
                    (4,6)
                },
                false
            ));
            _graphDict.Add("UGraph3",CreateGraph<int>(
                new [] 
                {
                     (0,0),   (0,3),
                     (3,4),   (4,5),
                     (0,19),  (19,20),
                     (20,21), (21,22),
                     (22,23), (23,25),
                     (25,26), (26,0),
                     (8,9),   (9,10),
                     (10,12), (0,12),
                     (0,13),  (2,0),
                     (0,11),  (0,29),
                     (0,30),  (30,34),
                     (34,33), (33,32),
                     (32,31), (31,28),
                     (28,27), (27,0),
                     (0,6),   (6,1),
                     (1,7),   (7,8),
                     (13,14), (14,15),
                     (15,16), (16,17),
                     (17,2),  (0,24),
                     (0,18)
                },
                false
            ));
            _graphDict.Add("UGraph4",CreateGraph<int>(
                new [] 
                {
                     (0,1),   (0,2),
                     (1,3),   (1,4),
                     (3,7),   (3,8),
                     (7,11),  (7,12),
                     (11,16), (11,17),
                     (8,13),  (13,18),
                     (18,19), (2,5),
                     (2,6),   (6,9),
                     (6,10),  (10,14),
                     (10,15), (14,19),
                     (14,20), (15,21),
                     (21,22), (21,23),
                     (16,0),  (21,0)
                },
                false
            ));
            _graphDict.Add("UGraph5",CreateGraph<int>(
                new [] 
                {
                     (4,5),   (4,4),
                     (5,5),   (4,2),
                     (1,4),   (2,3),
                     (0,1),   (4,6),
                     (5,6),   (6,7),
                     (4,8),   (5,8),
                     (9,8),   (10,5),
                     (11,5),  (12,10),
                     (11,13), (1,8),
                     (6,11),  (3,7),
                     (9,12)
                },
                false
            ));
            return _graphDict;
        }

        public static IPartitionableGraph<TVertex, IEdge<TVertex>> CreateGraph<TVertex>(IEnumerable<(TVertex,TVertex)> edges, bool IsDirected) => CreateGraph(edges, IsDirected, null);

        public static IPartitionableGraph<TVertex, IEdge<TVertex>> CreateGraph<TVertex>(IEnumerable<(TVertex,TVertex)> edges, bool IsDirected, IEnumerable<TVertex> singleVerticesList) 
        {
            IPartitionableGraph<TVertex, IEdge<TVertex>> graph;
            if(IsDirected) 
            {
                AdjacencyGraph<TVertex, Edge<TVertex>> adjacencyGraph = new AdjacencyGraph<TVertex, Edge<TVertex>>();
                graph = (IPartitionableGraph<TVertex, Edge<TVertex>>)adjacencyGraph;
            } else 
            {
                UndirectedGraph<TVertex, Edge<TVertex>> undirectedGraph = new UndirectedGraph<TVertex, Edge<TVertex>>();
                graph = (IPartitionableGraph<TVertex, IEdge<TVertex>>)undirectedGraph;
            }
            if (singleVerticesList != null) 
            {
                foreach (var vertex in singleVerticesList) 
                {
                    graph.AddVertex(vertex); 
                }
            }
            foreach(var vertex in edges)
            {
                if (vertex == (null,null))
                {
                    continue;
                }
                if(vertex.Item1 == null)
                {
                    graph.AddVertex(vertex.Item2); 
                } else if (vertex.Item2 == null) 
                {
                    graph.AddVertex(vertex.Item1); 
                }
                graph.AddVerticesAndEdge((IEdge<TVertex>)new Edge<TVertex>(vertex.Item1,vertex.Item2));
            }
            return (IPartitionableGraph<TVertex, IEdge<TVertex>> )graph;
        }

    }
}



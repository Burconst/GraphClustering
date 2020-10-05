using System.Collections.Generic;
using QuikGraph;

namespace GraphClustering.UnitTests 
{
    public static class GraphFactory 
    {
        public static IEdgeListAndIncidenceGraph<int, IEdge<int>> CreateDGraph1() 
        {
            var graph = new AdjacencyGraph<int, IEdge<int>>();
            graph.AddVerticesAndEdgeRange(
                new List<Edge<int>>
                {
                    new Edge<int>(1,0), new Edge<int>(7,5),
                    new Edge<int>(5,1), new Edge<int>(3,7),
                    new Edge<int>(4,3), new Edge<int>(7,0),
                    new Edge<int>(5,0), new Edge<int>(8,6),
                    new Edge<int>(2,6), new Edge<int>(10,9),
                    new Edge<int>(10,2),new Edge<int>(11,6),
                    new Edge<int>(10,11)
                }
            );
            return (IEdgeListAndIncidenceGraph<int, IEdge<int>>)graph;
        }

        public static IEdgeListAndIncidenceGraph<int, IEdge<int>> CreateDGraph2() 
        {
            var graph = new AdjacencyGraph<int, IEdge<int>>();
            graph.AddVerticesAndEdgeRange(
                new List<Edge<int>>
                {
                    new Edge<int>(0,2),new Edge<int>(0,4),
                    new Edge<int>(0,5),new Edge<int>(1,4),
                    new Edge<int>(1,5),new Edge<int>(2,3),
                    new Edge<int>(2,4),new Edge<int>(4,5)
                }
            );
            return (IEdgeListAndIncidenceGraph<int, IEdge<int>>)graph;
        }

        public static IEdgeListAndIncidenceGraph<int, IEdge<int>> CreateDGraph3() 
        {
            var graph = new AdjacencyGraph<int, IEdge<int>>();
            graph.AddVertex(0);
            graph.AddVertex(1);
            graph.AddVerticesAndEdgeRange(
                new List<Edge<int>>
                {
                    new Edge<int>(1,1),
                    new Edge<int>(5,12), new Edge<int>(12,11),
                    new Edge<int>(11,4), new Edge<int>(2,4),
                    new Edge<int>(2,12), new Edge<int>(5,9),
                    new Edge<int>(8,6),  new Edge<int>(6,13),
                    new Edge<int>(13,8), new Edge<int>(3,10),
                    new Edge<int>(7,10), new Edge<int>(10,15),
                    new Edge<int>(15,14),new Edge<int>(6,14),
                    new Edge<int>(14,6), new Edge<int>(15,8),
                    new Edge<int>(8,10), new Edge<int>(9,11)
                }
            );
            return (IEdgeListAndIncidenceGraph<int, IEdge<int>>)graph;
        }

        public static IEdgeListAndIncidenceGraph<int, IEdge<int>> CreateDGraph4() 
        {
            var graph = new AdjacencyGraph<int, IEdge<int>>();
            graph.AddVerticesAndEdgeRange(
                new List<Edge<int>>
                {
                    new Edge<int>(0,2), new Edge<int>(0,4),
                    new Edge<int>(0,5), new Edge<int>(1,4),
                    new Edge<int>(1,5), new Edge<int>(2,3),
                    new Edge<int>(2,4), new Edge<int>(4,5),
                    new Edge<int>(8,3), new Edge<int>(6,3),
                    new Edge<int>(6,7), new Edge<int>(7,8),
                    new Edge<int>(7,3), new Edge<int>(9,1),
                    new Edge<int>(9,10),new Edge<int>(9,12),
                    new Edge<int>(9,11)
                }
            );
            return (IEdgeListAndIncidenceGraph<int, IEdge<int>>)graph;
        }

        public static IEdgeListAndIncidenceGraph<int, IEdge<int>> CreateDGraph5() 
        {
            var graph = new AdjacencyGraph<int, IEdge<int>>();
            graph.AddVerticesAndEdgeRange(
                new List<Edge<int>>
                {
                    new Edge<int>(8,9), new Edge<int>(5,9),
                    new Edge<int>(3,9), new Edge<int>(4,9),
                    new Edge<int>(6,9), new Edge<int>(2,9),
                    new Edge<int>(7,10),new Edge<int>(1,10),
                    new Edge<int>(10,0)
                }
            );
            return (IEdgeListAndIncidenceGraph<int, IEdge<int>>)graph;
        }

        public static IEdgeListAndIncidenceGraph<int, IEdge<int>> CreateUGraph1() 
        {
            var graph = new BidirectionalGraph<int, IEdge<int>>();
            graph.AddVerticesAndEdgeRange(
                new List<Edge<int>>
                {
                    new Edge<int>(0,1),new Edge<int>(0,0),
                    new Edge<int>(1,2),new Edge<int>(1,3),
                    new Edge<int>(4,2),new Edge<int>(4,0),
                    new Edge<int>(5,3),new Edge<int>(1,5),
                    new Edge<int>(6,2),new Edge<int>(6,7),
                    new Edge<int>(3,7),new Edge<int>(3,3),
                    new Edge<int>(8,0),new Edge<int>(8,4),
                    new Edge<int>(5,9)
                }
            );
            return (IEdgeListAndIncidenceGraph<int, IEdge<int>>)graph;
        }

        public static IEdgeListAndIncidenceGraph<int, IEdge<int>> CreateUGraph2() 
        {
            var graph = new BidirectionalGraph<int, IEdge<int>>();
            graph.AddVerticesAndEdgeRange(
                new List<Edge<int>>
                {
                    new Edge<int>(8,8),new Edge<int>(7,7),
                    new Edge<int>(2,3),new Edge<int>(8,3),
                    new Edge<int>(0,8),new Edge<int>(2,5),
                    new Edge<int>(5,1),new Edge<int>(1,3),
                    new Edge<int>(3,9),new Edge<int>(0,9),
                    new Edge<int>(0,7),new Edge<int>(7,6),
                    new Edge<int>(4,6)
                }
            );
            return (IEdgeListAndIncidenceGraph<int, IEdge<int>>)graph;
        }

        public static IEdgeListAndIncidenceGraph<int, IEdge<int>> CreateUGraph3() 
        {
            var graph = new BidirectionalGraph<int, IEdge<int>>();
            graph.AddVerticesAndEdgeRange(
                new List<Edge<int>>
                {
                    new Edge<int>(0,0),  new Edge<int>(0,3),
                    new Edge<int>(3,4),  new Edge<int>(4,5),
                    new Edge<int>(0,19), new Edge<int>(19,20),
                    new Edge<int>(20,21),new Edge<int>(21,22),
                    new Edge<int>(22,23),new Edge<int>(23,25),
                    new Edge<int>(25,26),new Edge<int>(26,0),
                    new Edge<int>(8,9),  new Edge<int>(9,10),
                    new Edge<int>(10,12),new Edge<int>(0,12),
                    new Edge<int>(0,13), new Edge<int>(2,0),
                    new Edge<int>(0,11), new Edge<int>(0,29),
                    new Edge<int>(0,30), new Edge<int>(30,34),
                    new Edge<int>(34,33),new Edge<int>(33,32),
                    new Edge<int>(32,31),new Edge<int>(31,28),
                    new Edge<int>(28,27),new Edge<int>(27,0),
                    new Edge<int>(0,6),  new Edge<int>(6,1),
                    new Edge<int>(1,7),  new Edge<int>(7,8),
                    new Edge<int>(13,14),new Edge<int>(14,15),
                    new Edge<int>(15,16),new Edge<int>(16,17),
                    new Edge<int>(17,2), new Edge<int>(0,24),
                    new Edge<int>(0,18)
                }
            );
            return (IEdgeListAndIncidenceGraph<int, IEdge<int>>)graph;
        }

        public static IEdgeListAndIncidenceGraph<int, IEdge<int>> CreateUGraph4() 
        {
            var graph = new BidirectionalGraph<int, IEdge<int>>();
            graph.AddVerticesAndEdgeRange(
                new List<Edge<int>>
                {
                    new Edge<int>(0,1),  new Edge<int>(0,2),
                    new Edge<int>(1,3),  new Edge<int>(1,4),
                    new Edge<int>(3,7),  new Edge<int>(3,8),
                    new Edge<int>(7,11), new Edge<int>(7,12),
                    new Edge<int>(11,16),new Edge<int>(11,17),
                    new Edge<int>(8,13), new Edge<int>(13,18),
                    new Edge<int>(18,19),new Edge<int>(2,5),
                    new Edge<int>(2,6),  new Edge<int>(6,9),
                    new Edge<int>(6,10), new Edge<int>(10,14),
                    new Edge<int>(10,15),new Edge<int>(14,19),
                    new Edge<int>(14,20),new Edge<int>(15,21),
                    new Edge<int>(21,22),new Edge<int>(21,23),
                    new Edge<int>(16,0), new Edge<int>(21,0)
                }
            );
            return (IEdgeListAndIncidenceGraph<int, IEdge<int>>)graph;
        }

        public static IEdgeListAndIncidenceGraph<int, IEdge<int>> CreateUGraph5() 
        {
            var graph = new BidirectionalGraph<int, IEdge<int>>();
            graph.AddVerticesAndEdgeRange(
                new List<Edge<int>>
                {
                    new Edge<int>(4,5),  new Edge<int>(4,4),
                    new Edge<int>(5,5),  new Edge<int>(4,2),
                    new Edge<int>(1,4),  new Edge<int>(2,3),
                    new Edge<int>(0,1),  new Edge<int>(4,6),
                    new Edge<int>(5,6),  new Edge<int>(6,7),
                    new Edge<int>(4,8),  new Edge<int>(5,8),
                    new Edge<int>(9,8),  new Edge<int>(10,5),
                    new Edge<int>(11,5), new Edge<int>(12,10),
                    new Edge<int>(11,13),new Edge<int>(1,8),
                    new Edge<int>(6,11), new Edge<int>(3,7),
                    new Edge<int>(9,12)
                }
            );
            
            return (IEdgeListAndIncidenceGraph<int, IEdge<int>>)graph;
        }

    }

}



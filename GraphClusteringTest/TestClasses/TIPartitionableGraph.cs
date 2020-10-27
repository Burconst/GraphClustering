using System.Collections.Generic;
using NUnit.Framework;

namespace GraphClustering.UnitTests 
{
    [TestFixture]
    public class TIPartitionableGraph 
    {
        private Dictionary<string, IPartitionableGraph<int?, IEdge<int?>>> _graphDict;

        [SetUp]
        public void SetUp() => _graphDict = Builders.GraphBuilder.GetGraphsDict();

        [Test]
        public void IPartitionableGraph_IsDirected_ReturnsTrue()
        {
            Assert.IsTrue(_graphDict["DGraph1"].IsDirected);
            Assert.IsTrue(_graphDict["DGraph2"].IsDirected);
            Assert.IsTrue(_graphDict["DGraph3"].IsDirected);
            Assert.IsTrue(_graphDict["DGraph4"].IsDirected);
            Assert.IsTrue(_graphDict["DGraph5"].IsDirected);
        }

        [Test]
        public void IPartitionableGraph_IsDirected_ReturnsFalse()
        {
            Assert.IsFalse(_graphDict["UGraph1"].IsDirected);
            Assert.IsFalse(_graphDict["UGraph2"].IsDirected);
            Assert.IsFalse(_graphDict["UGraph3"].IsDirected);
            Assert.IsFalse(_graphDict["UGraph4"].IsDirected);
            Assert.IsFalse(_graphDict["UGraph5"].IsDirected);
        }

        [Test]
        public void IPartitionableGraph_VertexCount_AreEqual() 
        {
            Assert.AreEqual(12, _graphDict["DGraph1"].VertexCount);
            Assert.AreEqual(6, _graphDict["DGraph2"].VertexCount);
            Assert.AreEqual(16, _graphDict["DGraph3"].VertexCount);
            Assert.AreEqual(13, _graphDict["DGraph4"].VertexCount);
            Assert.AreEqual(11, _graphDict["DGraph5"].VertexCount);
            Assert.AreEqual(10, _graphDict["UGraph1"].VertexCount);
            Assert.AreEqual(10, _graphDict["UGraph2"].VertexCount);
            Assert.AreEqual(35, _graphDict["UGraph3"].VertexCount);
            Assert.AreEqual(24, _graphDict["UGraph4"].VertexCount);
            Assert.AreEqual(14, _graphDict["UGraph5"].VertexCount);
        }

        [Test]
        public void IPartitionableGraph_EdgeCount_AreEqual() 
        {
            Assert.AreEqual(13, _graphDict["DGraph1"].EdgeCount);
            Assert.AreEqual(8, _graphDict["DGraph2"].EdgeCount);
            Assert.AreEqual(19, _graphDict["DGraph3"].EdgeCount);
            Assert.AreEqual(17, _graphDict["DGraph4"].EdgeCount);
            Assert.AreEqual(9, _graphDict["DGraph5"].EdgeCount);
            Assert.AreEqual(14, _graphDict["UGraph1"].EdgeCount);
            Assert.AreEqual(13, _graphDict["UGraph2"].EdgeCount);
            Assert.AreEqual(39, _graphDict["UGraph3"].EdgeCount);
            Assert.AreEqual(26, _graphDict["UGraph4"].EdgeCount);
            Assert.AreEqual(21, _graphDict["UGraph5"].EdgeCount);
        }
        
        [Test]
        public void IPartitionableGraph_Contains_ReturnsTrue()
        {
            Assert.IsTrue(_graphDict["DGraph1"].Contains(0));
            Assert.IsTrue(_graphDict["DGraph2"].Contains(3));
            Assert.IsTrue(_graphDict["DGraph3"].Contains(0));
            Assert.IsTrue(_graphDict["DGraph4"].Contains(9));
            Assert.IsTrue(_graphDict["DGraph5"].Contains(10));
            Assert.IsTrue(_graphDict["UGraph1"].Contains(0));
            Assert.IsTrue(_graphDict["UGraph2"].Contains(8));
            Assert.IsTrue(_graphDict["UGraph3"].Contains(18));
            Assert.IsTrue(_graphDict["UGraph4"].Contains(6));
            Assert.IsTrue(_graphDict["UGraph5"].Contains(5));
        }   

        [Test]
        public void IPartitionableGraph_Contains_ReturnsFalse()
        {
            Assert.IsFalse(_graphDict["DGraph1"].Contains(-1));
            Assert.IsFalse(_graphDict["DGraph2"].Contains(300));
            Assert.IsFalse(_graphDict["DGraph3"].Contains(16));
            Assert.IsFalse(_graphDict["DGraph4"].Contains(-4));
            Assert.IsFalse(_graphDict["DGraph5"].Contains(11));
            Assert.IsFalse(_graphDict["UGraph1"].Contains(-10));
            Assert.IsFalse(_graphDict["UGraph2"].Contains(111));
            Assert.IsFalse(_graphDict["UGraph3"].Contains(80));
            Assert.IsFalse(_graphDict["UGraph4"].Contains(36));
            Assert.IsFalse(_graphDict["UGraph5"].Contains(15));
        }   

        [Test]
        public void IPartitionableGraph_AddVertex_ReturnsTrue()
        {
            Assert.IsTrue(!_graphDict["DGraph1"].Contains(-1) 
                            && _graphDict["DGraph1"].AddVertex(-1) 
                            && _graphDict["DGraph1"].Contains(-1));
            Assert.IsTrue(_graphDict["DGraph2"].Contains(3)
                            && !_graphDict["DGraph1"].AddVertex(3));
            Assert.IsTrue(!_graphDict["UGraph1"].Contains(-1) 
                            && _graphDict["UGraph1"].AddVertex(-1) 
                            && _graphDict["UGraph1"].Contains(-1));
            Assert.IsTrue(_graphDict["UGraph2"].Contains(3)
                            && !_graphDict["UGraph1"].AddVertex(3));
        }   

        [Test]
        public void IPartitionableGraph_AddVerticesAndEdge_ReturnsTrue()
        {
            Assert.IsTrue(!_graphDict["DGraph1"].Contains(-1) 
                            && _graphDict["DGraph1"].AddVerticesAndEdge(new Edge<int?>(0,-1)) 
                            && _graphDict["DGraph1"].Contains(-1));
            Assert.IsTrue(!_graphDict["UGraph1"].Contains(-1) 
                            && _graphDict["UGraph1"].AddVerticesAndEdge(new Edge<int?>(0,-1)) 
                            && _graphDict["UGraph1"].Contains(-1));
        }   

        [Test]
        public void IPartitionableGraph_Vertices_ReturnsTrue()
        {
            foreach (var graph in _graphDict)
            {
                foreach (var vertex in graph.Value.Vertices)
                {
                    Assert.IsTrue(graph.Value.Contains(vertex));
                }
            }
        }  

        [Test]
        public void IPartitionableGraph_OutEdges_ReturnsTrue() 
        {
            OutEdges(_graphDict["DGraph1"], new List<int?>{}, 0);
            OutEdges(_graphDict["DGraph1"], new List<int?>{ 5, 0 }, 7);

            OutEdges(_graphDict["DGraph2"], new List<int?>{ 5 }, 4);
            OutEdges(_graphDict["DGraph2"], new List<int?>{ 3, 4 }, 2);
            
            OutEdges(_graphDict["DGraph3"], new List<int?>{}, 0);
            OutEdges(_graphDict["DGraph3"], new List<int?>{ 1 }, 1);
            
            OutEdges(_graphDict["DGraph4"], new List<int?>{ 1, 10, 11, 12 }, 9);
            OutEdges(_graphDict["DGraph4"], new List<int?>{ 5 }, 4);
            
            OutEdges(_graphDict["DGraph5"], new List<int?>{ 0 }, 10);
            OutEdges(_graphDict["DGraph5"], new List<int?>{ 9 }, 6);

            OutEdges(_graphDict["UGraph1"], new List<int?>{ 0, 1, 4, 8 }, 0);
            OutEdges(_graphDict["UGraph1"], new List<int?>{ 5 }, 9);

            OutEdges(_graphDict["UGraph2"], new List<int?>{ 8, 0, 3 }, 8);
            OutEdges(_graphDict["UGraph2"], new List<int?>{ 1, 2, 8, 9 }, 3);
            
            OutEdges(_graphDict["UGraph3"], new List<int?>{ 0, 3, 18, 26, 11, 19, 29, 27, 24, 30, 2, 13, 6, 12}, 0);
            OutEdges(_graphDict["UGraph3"], new List<int?>{ 0 }, 29);
            
            OutEdges(_graphDict["UGraph4"], new List<int?>{ 23, 22, 15, 0 }, 21);
            OutEdges(_graphDict["UGraph4"], new List<int?>{ 0, 6, 5 }, 2);
            
            OutEdges(_graphDict["UGraph5"], new List<int?>{ 11, 6, 10, 8, 4, 5 }, 5);
            OutEdges(_graphDict["UGraph5"], new List<int?>{ 0, 8, 4 }, 1);

            void OutEdges<TVertex>(IPartitionableGraph<TVertex, IEdge<TVertex>> graph, List<TVertex> vertices, TVertex outVertex) 
            {
                int count = 0;
                foreach (var edge in graph.OutEdges(outVertex))
                {
                    count++;
                    Assert.IsTrue(vertices.Contains(edge.Target));
                }
                Assert.AreEqual(vertices.Count, count);
            }
        }
        
        [Test]
        public void IPartitionableGraph_EdgeCountBetween_AreEqual() 
        {
            Assert.AreEqual(1,_graphDict["DGraph1"].EdgeCountBetween(11,6));
            Assert.AreEqual(1,_graphDict["DGraph2"].EdgeCountBetween(4,5));
            Assert.AreEqual(2,_graphDict["DGraph3"].EdgeCountBetween(14,6));
            Assert.AreEqual(0,_graphDict["DGraph4"].EdgeCountBetween(4,8));
            Assert.AreEqual(0,_graphDict["DGraph5"].EdgeCountBetween(9,10));
            Assert.AreEqual(1,_graphDict["UGraph1"].EdgeCountBetween(0,1));
            Assert.AreEqual(1,_graphDict["UGraph2"].EdgeCountBetween(8,8));
            Assert.AreEqual(0,_graphDict["UGraph3"].EdgeCountBetween(18,26));
            Assert.AreEqual(1,_graphDict["UGraph4"].EdgeCountBetween(5,2));
            Assert.AreEqual(1,_graphDict["UGraph5"].EdgeCountBetween(4,5));
        }

        [Test]
        public void IPartitionableGraph_GetSelfloopCount_AreEqual() 
        {
            Assert.AreEqual(0,_graphDict["DGraph1"].GetSelfloopCount());
            Assert.AreEqual(0,_graphDict["DGraph2"].GetSelfloopCount());
            Assert.AreEqual(1,_graphDict["DGraph3"].GetSelfloopCount());
            Assert.AreEqual(0,_graphDict["DGraph4"].GetSelfloopCount());
            Assert.AreEqual(0,_graphDict["DGraph5"].GetSelfloopCount());
            Assert.AreEqual(1,_graphDict["UGraph1"].GetSelfloopCount());
            Assert.AreEqual(2,_graphDict["UGraph2"].GetSelfloopCount());
            Assert.AreEqual(1,_graphDict["UGraph3"].GetSelfloopCount());
            Assert.AreEqual(0,_graphDict["UGraph4"].GetSelfloopCount());
            Assert.AreEqual(2,_graphDict["UGraph5"].GetSelfloopCount());
        }

    }
}
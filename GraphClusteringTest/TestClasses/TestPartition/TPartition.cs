using System.Collections.Generic;
using NUnit.Framework;
using QuikGraph;

namespace GraphClustering.UnitTests
{
    [TestFixture]
    public class TGraphPartition
    {
        private Dictionary<string,IEdgeListAndIncidenceGraph<int, IEdge<int>>> _graphDict;

        [SetUp]
        public void SetUp()
        {   
            _graphDict = UtilityFunctions.GetGraphsDict();
        }

        [Test]
        public void Partition_Constructor_ReturnTrue() 
        {
            foreach(var graph in _graphDict.Values) 
            {
                var partition = new GraphPartition<int>(graph);
                Assert.IsTrue(partition.Graph == graph, "TODO");
                Assert.IsTrue(partition.GetCommunityCount() == graph.VertexCount, "TODO");
            }
        }

        [Test]
        public void Partition_AddVertexToCommunity_ReturnTrue() 
        {
            foreach(var graph in _graphDict.Values) 
            {
                var partition = new GraphPartition<int>(graph);
                if(graph.VertexCount > 0) 
                {
                    foreach(var vertex in graph.Vertices) 
                    {
                        partition.AddVertexToCommunity(vertex, 0);
                    }
                    Assert.IsTrue(partition.GetCommunityCount() == 1, "TODU");
                }
            }
        }

        [Test]
        public void Partition_GetCommunityNumber_ReturnTrue() 
        {
            foreach(var graph in _graphDict.Values) 
            {
                var partition = new GraphPartition<int>(graph);
                if(graph.VertexCount > 0) 
                {
                    foreach(var vertex in graph.Vertices) 
                    {
                        partition.AddVertexToCommunity(vertex, 0);
                    }
                    foreach(var vertex in graph.Vertices) 
                    {
                        Assert.IsTrue(partition.GetCommunityNumber(vertex) == 0, "TODU");
                    }
                }
            }
        }

        

    }
    
}
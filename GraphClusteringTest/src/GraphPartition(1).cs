using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

namespace GraphClustering.UnitTests
{
    [TestFixture]
    public class GraphPartition
    {
        private Dictionary<string, IPartitionableGraph<int?, IEdge<int?>>> _graphDict;

        [SetUp]
        public void SetUp() => _graphDict = GraphLibFacade.GraphBuilder.GetGraphs();

        [Test]
        public void GraphPartition_Constructor_ReturnTrue() 
        {
            foreach(var graph in _graphDict.Values) 
            {
                var partition = Builders.PartitionBuilder.Create<int?>(graph);
                Assert.AreEqual(graph, partition.Graph, "A partition must refer to the graph that it was created with.");
            }

            bool wasExeption = false;
            try 
            {
                Builders.PartitionBuilder.Create<int?>(null);
            }
            catch 
            {
                wasExeption = true;
            }
            Assert.IsTrue(wasExeption, "The constructor must throw an exceptions if the graph is null.");
        }


        [Test]
        public void GraphPartition_AddVertexToCommunity_AreEqual() 
        {
            foreach(var graph in _graphDict.Values)
            {
                var partition = Builders.PartitionBuilder.Create<int?>(graph);
                foreach (var vertex in graph.Vertices)
                {
                    int prevCommNum = partition.GetCommunityNumber(vertex);
                    partition.MoveVertexToCommunity(vertex, 0);
                    if (prevCommNum != 0) 
                    {
                        partition.RemoveCommunity(prevCommNum);
                    }
                }
                Assert.AreEqual(1, partition.GetCommunityCount());
            }
        }


        [Test]
        public void GraphPartition_RemoveVertexFromCommunity_ReturnTrue() 
        {
            foreach(var graph in _graphDict.Values)
            {
                var partition = Builders.PartitionBuilder.Create<int?>(graph);
                foreach (var vertex in graph.Vertices)
                {
                    Assert.IsTrue(partition.RemoveVertexFromCommunity(vertex));
                }
            }
        }

        [Test]
        public void GraphPartition_GetCommunityNumber_AreEqual() 
        {
            foreach(var graph in _graphDict.Values)
            {
                var partition = Builders.PartitionBuilder.Create<int?>(graph);
                foreach (var vertex in graph.Vertices)
                {
                    partition.MoveVertexToCommunity(vertex, 0);
                    Assert.AreEqual(0, partition.GetCommunityNumber(vertex), "TODU");
                }
            }
        }

        [Test]
        public void GraphPartition_GetCommunityNumber_ThrowsExeption() 
        {
            foreach(var graph in _graphDict.Values)
            {
                var partition = Builders.PartitionBuilder.Create<int?>(graph);
                foreach (var vertex in graph.Vertices)
                {
                    int communityNumber = partition.GetCommunityNumber(vertex);
                    partition.RemoveVertexFromCommunity(vertex, communityNumber);
                    Assert.Throws<System.ArgumentException>(() => partition.GetCommunityNumber(vertex), "TODO");
                }
            }
        }
        
        [Test]
        public void GraphPartition_UniteCommunitiesByNumbers_AreEqual() 
        {
            foreach (var graph in _graphDict)
            {
                var partition = Builders.PartitionBuilder.Create<int?>(graph.Value);
                if (partition.GetCommunityCount() <= 0)
                {
                    continue;
                }
                foreach(var commNumber in Enumerable.Range(0, partition.GetCommunityCount())) 
                {
                    partition.UniteCommunities(0,commNumber);
                }
                Assert.AreEqual(1,partition.GetCommunityCount(),graph.Key);
            }
        }

        [Test]
        public void GraphPartition_UniteCommunitiesByRange_AreEqual() 
        {
            foreach (var graph in _graphDict.Values)
            {
                var partition = Builders.PartitionBuilder.Create<int?>(graph);
                partition.UniteCommunities(Enumerable.Range(0, partition.GetCommunityCount()));
                Assert.AreEqual(1, partition.GetCommunityCount(), "TODO");
            }
            Assert.AreEqual(2, uniteCommunities(_graphDict["DGraph1"], new []{ 9,10,11,2,6,8 }));

            int uniteCommunities<TVertex>(IPartitionableGraph<TVertex,IEdge<TVertex>> graph, IEnumerable<int> commNumbers) 
            {
                var partition = Builders.PartitionBuilder.Create<TVertex>(graph);
                return partition.UniteCommunities(commNumbers);
            }
        }

        [Test]
        public void GraphPartition_GetEdgeCountBetweenVertAndComm_AreEqual() 
        {
            Assert.AreEqual(0, getEdgeCount(_graphDict["DGraph1"],vertexFrom: 4,verticesTo: new int?[]{ 2,6,8,9,10,11 }),"TODO");
            Assert.AreEqual(0, getEdgeCount(_graphDict["DGraph1"],vertexFrom: 5,verticesTo: new int?[]{ 7,3,4 }),"TODO");
            Assert.AreEqual(2, getEdgeCount(_graphDict["DGraph1"],vertexFrom: 7,verticesTo: new int?[]{ 5,1,0 }),"TODO");
            
            Assert.AreEqual(2, getEdgeCount(_graphDict["UGraph1"],vertexFrom: 5,verticesTo: new int?[]{ 1,2,3 }),"TODO");
            Assert.AreEqual(4, getEdgeCount(_graphDict["UGraph1"],vertexFrom: 0,verticesTo: new int?[]{ 0,1,2,4,8 }),"TODO");

            int getEdgeCount<TVertex>(IPartitionableGraph<TVertex,IEdge<TVertex>> graph,TVertex vertexFrom, IEnumerable<TVertex> verticesTo) 
            {
                var partition = Builders.PartitionBuilder.Create<TVertex>(graph);
                var commNumbers = new List<int>();
                foreach(var vertex in verticesTo) 
                {
                    commNumbers.Add(partition.GetCommunityNumber(vertex));
                }
                int commToNumber = partition.UniteCommunities(commNumbers);
                return partition.GetEdgeCount(vertexFrom, commToNumber);
            }
        }

        [Test]
        public void GraphPartition_GetVerticesFromCommunity_AreEqual() 
        {
            var partition = Builders.PartitionBuilder.Create(_graphDict["DGraph1"]);
            var comm = new [] { 0,1,3,4,5,7 };
            int commNumber = partition.UniteCommunities(comm);
            System.Console.WriteLine(partition);
            foreach(var vertex in partition.GetCommunityVertices(commNumber)) 
            {
                Assert.AreEqual(commNumber, partition.GetCommunityNumber(vertex));
            }
        }

        [Test]
        public void GraphPartition_GetEnumerator_ReturnTrue() 
        {
            foreach(var graph in _graphDict.Values)
            {
                var partition = Builders.PartitionBuilder.Create<int?>(graph);
                bool enumeratorWasReceived = false;
                foreach(var community in partition)
                {
                    enumeratorWasReceived = true;
                    break;
                }
                Assert.IsTrue((graph.VertexCount > 0) && enumeratorWasReceived,"TODO");
            }
        }

    }
    
}
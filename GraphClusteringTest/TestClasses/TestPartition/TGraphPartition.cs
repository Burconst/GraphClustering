using System.Collections.Generic;
using NUnit.Framework;
using QuikGraph;
using System.Linq;

namespace GraphClustering.UnitTests
{
    [TestFixture]
    public class TGraphPartition
    {
        private Dictionary<string,IEdgeListAndIncidenceGraph<int, IEdge<int>>> _graphDict;

        [SetUp]
        public void SetUp() => _graphDict = Builders.GraphBuilder.GetGraphsDict();

        [Test]
        public void GraphPartition_Constructor_ReturnTrue() 
        {
            foreach(var graph in _graphDict.Values) 
            {
                var partition = Builders.PartitionBuilder.Create<int>(graph);
                Assert.IsTrue(partition.Graph == graph, "A partition must refer to the graph that it was created with.");
            }

            bool wasExeption = false;
            try 
            {
                var partition = Builders.PartitionBuilder.Create<int>(null);
            }
            catch 
            {
                wasExeption = true;
            }
            Assert.IsTrue(wasExeption, "The constructor must throw an exceptions if the graph is null.");
        }


        [Test]
        public void GraphPartition_AddVertexToCommunity_ReturnTrue() 
        {
            foreach(var graph in _graphDict.Values)
            {
                var partition = Builders.PartitionBuilder.Create<int>(graph);
                foreach (var vertex in graph.Vertices)
                {
                    partition.AddVertexToCommunity(vertex, 0);
                }
                Assert.IsTrue(partition.GetCommunityCount() == 1);
            }
        }

        [Test]
        public void GraphPartition_GetCommunityNumber_ReturnTrue() 
        {
            foreach(var graph in _graphDict.Values)
            {
                var partition = Builders.PartitionBuilder.Create<int>(graph);
                foreach (var vertex in graph.Vertices)
                {
                    partition.AddVertexToCommunity(vertex, 0);
                    Assert.IsTrue(partition.GetCommunityNumber(vertex) == 0, "TODU");
                }
            }
        }

        [Test]
        public void GraphPartition_RemoveVertexFromCommunity_ReturnTrue() 
        {
            foreach(var graph in _graphDict.Values)
            {
                var partition = Builders.PartitionBuilder.Create<int>(graph);
                foreach (var vertex in graph.Vertices)
                {
                    partition.RemoveVertexFromCommunity(vertex);
                    try 
                    {
                        partition.GetCommunityNumber(vertex);
                        Assert.IsTrue(false, "TODU");
                    } 
                    catch 
                    {
                        Assert.IsTrue(true, "TODU");
                    }
                }
            }
        }
        
        [Test]
        public void GraphPartition_RemoveVertexFromCommunityWithCommNumber_ReturnTrue() 
        {
            foreach(var graph in _graphDict.Values)
            {
                var partition = Builders.PartitionBuilder.Create<int>(graph);
                foreach (var vertex in graph.Vertices)
                {
                    partition.RemoveVertexFromCommunity(vertex, partition.GetCommunityNumber(vertex));
                    try 
                    {
                        partition.GetCommunityNumber(vertex);
                        Assert.IsTrue(false, "TODU");
                    } 
                    catch 
                    {
                        Assert.IsTrue(true, "TODU");
                    }
                }
            }
        }    

        [Test]
        public void GraphPartition_UniteCommunitiesByNumbers_ReturnTrue() 
        {
            foreach (var graph in _graphDict.Values)
            {
                var partition = Builders.PartitionBuilder.Create<int>(graph);
                if (partition.GetCommunityCount() <= 0)
                {
                    continue;
                }
                foreach(var commNumber in Enumerable.Range(0, partition.GetCommunityCount())) 
                {
                    partition.UniteCommunities(0,commNumber);
                }
                Assert.IsTrue(partition.GetCommunityCount() == 1,"TODO");
            }
        }

        [Test]
        public void GraphPartition_UniteCommunitiesByRange_ReturnTrue() 
        {
            foreach (var graph in _graphDict.Values)
            {
                var partition = Builders.PartitionBuilder.Create<int>(graph);
                partition.UniteCommunities(Enumerable.Range(0, partition.GetCommunityCount()));
                Assert.IsTrue(partition.GetCommunityCount() == 1,"TODO");
            }
        }

        [Test]
        public void GraphPartition_GetEdgeCountBetweenVertAndComm_ReturnTrue() 
        {
            Assert.True(0 == getEdgeCount(_graphDict["DGraph1"],vertexFrom: 4,verticesTo: new []{ 2,6,8,9,10,11 }),"TODO");
            Assert.True(0 == getEdgeCount(_graphDict["DGraph1"],vertexFrom: 5,verticesTo: new []{ 7,3,4 }),"TODO");
            Assert.True(2 == getEdgeCount(_graphDict["DGraph1"],vertexFrom: 7,verticesTo: new []{ 5,1,0 }),"TODO");
            
            Assert.True(2 == getEdgeCount(_graphDict["UGraph1"],vertexFrom: 5,verticesTo: new []{ 1,2,3 }),"TODO");
            Assert.True(5 == getEdgeCount(_graphDict["UGraph1"],vertexFrom: 0,verticesTo: new []{ 0,1,2,3,8 }),"TODO");

            int getEdgeCount<TVertex>(IEdgeListAndIncidenceGraph<TVertex,IEdge<TVertex>> graph,TVertex vertexFrom, IEnumerable<TVertex> verticesTo) 
            {
                var partition = Builders.PartitionBuilder.Create<TVertex>(graph);
                var commNumbers = new List<int>();
                foreach(var vertex in verticesTo) 
                {
                    commNumbers.Add(partition.GetCommunityNumber(vertex));
                }
                int commToNUmber = partition.UniteCommunities(commNumbers);
                var communityTo = Builders.CommunityBuilder.Create<TVertex>(verticesTo);
                return partition.GetEdgeCount(vertexFrom, commToNUmber);
            }
        }

        [Test]
        public void GraphPartition_GetVerticesFromCommunity_ReturnTrue() 
        {
            var partition = Builders.PartitionBuilder.Create(_graphDict["DGraph1"]);
            var comm = new [] { 0,1,3,4,5,7 };
            int commNumber = partition.UniteCommunities(comm);
            foreach(var vertex in partition.GetVerticesFromCommunity(commNumber)) 
            {
                Assert.IsTrue(comm.Contains(vertex));
            }
            foreach(var vertex in comm) 
            {
                Assert.IsTrue(partition.GetVerticesFromCommunity(commNumber).Contains(vertex));
            }
        }

        [Test]
        public void GraphPartition_AggregatePartition_ReturnTrue() 
        {
            var graph = getAgregationOfPartition(_graphDict["DGraph1"], new[] { new [] { 0,1,3,4,5,7 },  new [] { 2,6,8,9,10,11 } });
            Assert.IsTrue(graph.VertexCount == 2);
            Assert.IsTrue(graph.EdgeCount == 0);

            graph = getAgregationOfPartition(_graphDict["UGraph1"], new[] { new [] { 5,9 },  new [] { 0,4,8 }, new [] { 1,2,3,6,7 } });
            Assert.IsTrue(graph.VertexCount == 3);
            Assert.IsTrue(graph.EdgeCount == 2);

            IEdgeListAndIncidenceGraph<TVertex, IEdge<TVertex>> getAgregationOfPartition<TVertex>(IEdgeListAndIncidenceGraph<TVertex, IEdge<TVertex>> graph, IEnumerable<IEnumerable<TVertex>> verticesSets) 
            {
                var partition = Builders.PartitionBuilder.Create(graph);
                foreach(var vertices in verticesSets) 
                {
                    var commNumbers = new List<int>();
                    foreach(var vertex in vertices) 
                    {
                        commNumbers.Add(partition.GetCommunityNumber(vertex));
                    }
                    partition.UniteCommunities(commNumbers);
                }
                return partition.AggregatePartition();
            }
        }

        [Test]
        public void GraphPartition_GetEnumerator_ReturnTrue() 
        {
            foreach(var graph in _graphDict.Values)
            {
                var partition = Builders.PartitionBuilder.Create<int>(graph);
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
using System.Collections.Generic;
using NUnit.Framework;

namespace GraphClustering.UnitTests
{
    [TestFixture]
    public class Community
    {
        private Dictionary<string, IPartitionableGraph<int?, IEdge<int?>>> _graphDict;

        [SetUp]
        public void SetUp() => _graphDict = GraphLibFacade.GraphBuilder.GetGraphsDict();
        
        [Test]
        public void Community_Constructor_ReturnTrue()
        {
            foreach(var graph in _graphDict.Values)
            {
                foreach(var vertex in graph.Vertices) 
                {
                    var community = Builders.CommunityBuilder.Create(vertex);
                    Assert.AreEqual(1,community.GetVertexCount(),"The community should consist of one vertex.");
                    break;
                }
            }

            bool wasExeption = false;
            try 
            {
                object nullVertex = null;
                Builders.CommunityBuilder.Create(nullVertex);
            }
            catch 
            {
                wasExeption = true;
            }
            Assert.IsTrue(wasExeption, "The constructor should throw an exceptions if the constructor parameter is null.");
        }

        [Test]
        public void Community_Constructor_AreEqual()
        {
            var community = Builders.CommunityBuilder.Create<int>();
            Assert.AreEqual(0, community.GetVertexCount(),"The community should be empty in initial state.");
        }

        [Test]
        public void Community_ConstructorWithRange_AreEqual()
        {
            foreach(var graph in _graphDict.Values) 
            {
                var community = Builders.CommunityBuilder.Create(graph.Vertices);
                Assert.AreEqual(graph.VertexCount, community.GetVertexCount(), "The community should be the same size as the graph.");
            }
        }

        [Test]
        public void Community_ConstructorWithRange_AreNotEqual() 
        {
            // Value type testing
            var verticesInt = new List<int>{ 1, 2, 3 };
            var communityInt = Builders.CommunityBuilder.Create<int>(verticesInt);
            verticesInt.Add(4);
            Assert.AreNotEqual(verticesInt.Count, communityInt.GetVertexCount(),"The community should be independent of the collection that it was created with.");
            verticesInt.Clear();
            Assert.AreNotEqual(verticesInt.Count, communityInt.GetVertexCount(),"The community should be independent of the collection that it was created with.");
            
            // Reference type Testing
            var verticesString = new List<string> { "one", "two", "three"}; 
            var communityString = Builders.CommunityBuilder.Create<string>(verticesString);
            verticesString.Clear();
            Assert.AreNotEqual(verticesInt.Count, communityString.GetVertexCount(),"The community should be independent of the collection that it was created with.");
        }

        [Test]
        public void Community_Contains_ReturnTrue() 
        {
            foreach(var graph in _graphDict) 
            {
                foreach(var vertex in graph.Value.Vertices) 
                {
                    var community = Builders.CommunityBuilder.Create(vertex);
                    Assert.IsTrue(community.Contains(vertex),"The community should contain vertex that it was created with.");
                }
            }
            var verticesInt = new List<int>{ 1, 2, 3 };
            var communityInt = Builders.CommunityBuilder.Create<int>(verticesInt);
            Assert.IsTrue(communityInt.Contains(verticesInt[2]),"The community should contain collection that it was created with.");
        }

        [Test]
        public void Community_Contains_ReturnFalse() 
        {
            var verticesInt = new List<int>{ 1, 2, 3 };
            var communityInt = Builders.CommunityBuilder.Create<int>(verticesInt);
            verticesInt.Add(4);
            Assert.IsFalse(communityInt.Contains(verticesInt[3]),"The community should be independent of the collection that it was created with.");
            var verticesString = new List<string> { "one", "two", "three"}; 
            var communityString = Builders.CommunityBuilder.Create<string>(verticesString);
            var one = new string("one");
            Assert.IsFalse(communityString.Contains(one),"The contains method should look for an object with the same reference.");
        } 

        [Test]
        public void Community_ContainsRange_ReturnTrue() 
        {
            foreach(var graph in _graphDict.Values) 
            {
                var community = Builders.CommunityBuilder.Create(graph.Vertices);
                Assert.IsTrue(community.Contains(graph.Vertices),"The community should contain collection that it was created with.");
            }
        }

        [Test]
        public void Community_Add_ReturnTrue() 
        {
            foreach (var graph in _graphDict)
            {
                var community = Builders.CommunityBuilder.Create<int?>();
                var vertList = new List<int?>();
                int i = 0;
                foreach(var vertex in graph.Value.Vertices) 
                {
                    if (i%2 == 0) 
                    {
                        community.Add(vertex);
                        vertList.Add(vertex);
                    }
                    i++;
                }
                Assert.IsTrue(community.Contains(vertList),"The community should contain added vertices.");
            }
        }

        [Test]
        public void Community_AddRange_ReturnTrue()
        {
            foreach (var graph in _graphDict)
            {
                var community = Builders.CommunityBuilder.Create<int?>();
                var vertList = new List<int?>();
                int i = 0;
                foreach(var vertex in graph.Value.Vertices) 
                {
                    if (i%2 == 0) 
                    {
                        vertList.Add(vertex);
                    }
                    i++;
                }
                Assert.IsTrue(community.Add(vertList),"It should be possible to add any vertex to an empty community.");
            }
        }

        [Test]
        public void Community_Remove_ReturnTrue() 
        {
            foreach(var graph in _graphDict)
            {
                var community = Builders.CommunityBuilder.Create(graph.Value.Vertices);
                foreach(var vertex in graph.Value.Vertices) 
                {
                    bool answer = community.Remove(vertex);
                    Assert.IsTrue((answer == true) && !community.Contains(vertex),"The community shouldn't contain removed vertices.");
                }
            }
        }
        
        [Test]
        public void Community_Remove_ReturnFalse() 
        {
            var communityOfInts = Builders.CommunityBuilder.Create<int>(new [] {1,2,3,4,5,6});
            Assert.IsFalse(communityOfInts.Remove(0), "A removal was successful if argument was found and removed.");
        }

        [Test]
        public void Community_RemoveRange_ReturnTrue() 
        {
            foreach(var graph in _graphDict)
            {
                var community = Builders.CommunityBuilder.Create(graph.Value.Vertices);
                var vertList = new List<int?>();
                int i = 0;
                foreach(var vertex in graph.Value.Vertices) 
                {
                    if (i%2 == 0) 
                    {
                        vertList.Add(vertex);
                    }
                    i++;
                }
                Assert.IsTrue(community.Remove(vertList) && !community.Contains(vertList),"The community shouldn't contain removed vertices.");
            }
        }

        [Test]
        public void Community_RemoveRange_ReturnFalse() 
        {
            var communityOfInts = Builders.CommunityBuilder.Create<int>(new [] {1,2,3,4,5,6});
            Assert.IsFalse(communityOfInts.Remove(new []{0,1,2,3}), "A removal was successful if all elements in collection was removed.");
        }

        [Test]
        public void Community_Clear_AreEqual() 
        {
            foreach(var graph in _graphDict)
            {
                var community = Builders.CommunityBuilder.Create<int>();
                var vertList = new List<int?>();
                int i = 0;
                foreach(var vertex in graph.Value.Vertices) 
                {
                    if (i%2 == 0) 
                    {
                        vertList.Add(vertex);
                    }
                    i++;
                }
                community.Clear();
                Assert.AreEqual(0, community.GetVertexCount(),"The cleared community should be empty.");
            }
        }

        [Test]
        public void Community_GetEnumerator_ReturnTrue() 
        {
            foreach(var graph in _graphDict)
            {
                var community = Builders.CommunityBuilder.Create(graph.Value.Vertices);
                bool enumeratorWasReceived = false;
                foreach(var vertex in community)
                {
                    enumeratorWasReceived = true;
                    break;
                }
                Assert.IsTrue((graph.Value.VertexCount > 0) && enumeratorWasReceived,"You should be able to get enumerator of a community.");
            }
        }

    }
    
}
using System.Collections.Generic;
using NUnit.Framework;
using QuikGraph;

namespace GraphClustering.UnitTests
{
    [TestFixture]
    public class TCommunity
    {
        private Dictionary<string,IEdgeListAndIncidenceGraph<int, Edge<int>>> _graphDict;

        [SetUp]
        public void SetUp()
        {   
            _graphDict = UtilityFunctions.GetGraphsDict();
        }

        [Test]
        public void Community_Constructor_ReturnTrue()
        {
            foreach(var graph in _graphDict) 
            {
                foreach(var vertex in graph.Value.Vertices) 
                {
                    var community = new Community<int>(vertex);
                    Assert.IsTrue(community.GetVertexCount() == 1,"TODO");
                    break;
                }
            }
        }

        [Test]
        public void Community_Constructor_ReturnFalse()
        {
            var community1 = new Community<int>();
            Assert.IsFalse(community1.GetVertexCount() > 0,"TODO");
        }

        [Test]
        public void Community_ConstructorWithRange_ReturnTrue()
        {
            foreach(var graph in _graphDict) 
            {
                var community = new Community<int>(graph.Value.Vertices);
                Assert.IsTrue(community.GetVertexCount() == graph.Value.VertexCount,"TODO");
            }
        }

        [Test]
        public void Community_ConstructorWithRange_ReturnFalse() 
        {
            var verticesInt = new List<int>{ 1, 2, 3 };
            var communityInt = new Community<int>(verticesInt);
            verticesInt.Add(4);
            Assert.IsFalse(verticesInt.Count == communityInt.GetVertexCount(),"TODO");
            verticesInt.Clear();
            Assert.IsFalse(verticesInt.Count == communityInt.GetVertexCount(),"TODO");
            var verticesString = new List<string> { "one", "two", "three"}; 
            var communityString = new Community<string>(verticesString);
            verticesString.Clear();
            Assert.IsFalse(verticesInt.Count == communityInt.GetVertexCount(),"TODO");
        }

        [Test]
        public void Community_Contains_ReturnTrue() 
        {
            foreach(var graph in _graphDict) 
            {
                foreach(var vertex in graph.Value.Vertices) 
                {
                    var community = new Community<int>(vertex);
                    Assert.IsTrue(community.Contains(vertex),"TODO");
                }
            }
            var verticesInt = new List<int>{ 1, 2, 3 };
            var communityInt = new Community<int>(verticesInt);
            Assert.IsTrue(communityInt.Contains(verticesInt[2]),"TODO");
        }

        [Test]
        public void Community_Contains_ReturnFalse() 
        {
            var verticesInt = new List<int>{ 1, 2, 3 };
            var communityInt = new Community<int>(verticesInt);
            verticesInt.Add(4);
            Assert.IsFalse(communityInt.Contains(verticesInt[3]),"TODO");
            var verticesString = new List<string> { "one", "two", "three"}; 
            var communityString = new Community<string>(verticesString);
            var one = new string("one");
            Assert.IsFalse(communityString.Contains(one),"TODO");
        } 

        [Test]
        public void Community_ContainsRange_ReturnTrue() 
        {
            foreach(var graph in _graphDict) 
            {
                var community = new Community<int>(graph.Value.Vertices);
                Assert.IsTrue(community.Contains(graph.Value.Vertices),"TODO");
            }
        }

        [Test]
        public void Community_Add_ReturnTrue() 
        {
            foreach (var graph in _graphDict)
            {
                var community = new Community<int>();
                var vertList = new List<int>();
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
                Assert.IsTrue(community.Contains(vertList),"TODO");
            }
        }

        [Test]
        public void Community_AddRange_ReturnTrue()
        {
            foreach (var graph in _graphDict)
            {
                var community = new Community<int>();
                var vertList = new List<int>();
                int i = 0;
                foreach(var vertex in graph.Value.Vertices) 
                {
                    if (i%2 == 0) 
                    {
                        vertList.Add(vertex);
                    }
                    i++;
                }
                community.Add(vertList);
                Assert.IsTrue(community.Contains(vertList),"TODO");
            }
        }

        [Test]
        public void Community_Remove_ReturnTrue() 
        {
            foreach(var graph in _graphDict)
            {
                var community = new Community<int>(graph.Value.Vertices);
                foreach(var vertex in graph.Value.Vertices) 
                {
                    bool answer = community.Remove(vertex);
                    Assert.IsTrue((answer == true )&& !community.Contains(vertex),$"Can't remove vertex {vertex} in graph {graph.Key}");
                }
            }
        }
        
        [Test]
         public void Community_RemoveRange_ReturnTrue() 
        {
            foreach(var graph in _graphDict)
            {
                var community = new Community<int>(graph.Value.Vertices);
                var vertList = new List<int>();
                int i = 0;
                foreach(var vertex in graph.Value.Vertices) 
                {
                    if (i%2 == 0) 
                    {
                        vertList.Add(vertex);
                    }
                    i++;
                }
                bool answer = community.Remove(vertList);
                Assert.IsTrue(answer == true && !community.Contains(vertList),"TODo");
            }
        }

        [Test]
        public void Community_Clear_ReturnTrue() 
        {
            foreach(var graph in _graphDict)
            {
                var community = new Community<int>();
                var vertList = new List<int>();
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
                Assert.IsTrue(community.GetVertexCount() == 0,"TODo");
            }
        }

    }
    
}
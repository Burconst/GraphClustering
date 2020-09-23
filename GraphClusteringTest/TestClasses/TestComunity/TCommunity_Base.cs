using System.IO;
using System.Collections.Generic;
using NUnit.Framework;
using QuikGraph;
using QuikGraph.Collections;

namespace GraphClustering.UnitTests
{
    [TestFixture]
    public class TCommunity_Base
    {

        private ICommunity<int> _community;
        private Dictionary<string,IEdgeListAndIncidenceGraph<int, Edge<int>>> _graphDict;

        [SetUp]
        public void SetUp()
        {   
            _graphDict = new Dictionary<string, IEdgeListAndIncidenceGraph<int, Edge<int>>>();
            _graphDict.Add("DGraph1",GraphFactory.CreateDGraph1());
            _graphDict.Add("DGraph2",GraphFactory.CreateDGraph2());
            _graphDict.Add("DGraph3",GraphFactory.CreateDGraph3());
            _graphDict.Add("DGraph4",GraphFactory.CreateDGraph4());
            _graphDict.Add("DGraph5",GraphFactory.CreateDGraph5());
            _graphDict.Add("UGraph1",GraphFactory.CreateUGraph1());
            _graphDict.Add("UGraph2",GraphFactory.CreateUGraph2());
            _graphDict.Add("UGraph3",GraphFactory.CreateUGraph3());
            _graphDict.Add("UGraph4",GraphFactory.CreateUGraph4());
            _graphDict.Add("UGraph5",GraphFactory.CreateUGraph5());
        }

        [TearDown]
        public void TearDown()
        {

            _community = null;
        }

        [Test]
        public void Community_Constructor_ReturnTrue()
        {
            foreach(var graph in _graphDict) 
            {
                foreach(var vertex in graph.Value.Vertices) 
                {
                    _community = new Community<int>(vertex);
                    Assert.IsTrue(_community.GetVertexCount() == 1,"TODO");
                    break;
                }
            }
        }

        [Test]
        public void Community_ConstructorWithRange_ReturnTrue()
        {
            foreach(var graph in _graphDict) 
            {
                _community = new Community<int>(graph.Value.Vertices);
                Assert.IsTrue(_community.GetVertexCount() == graph.Value.VertexCount,"TODO");
            }
        }

        [Test]
        public void Community_Contains_ReturnTrue() 
        {
            foreach(var graph in _graphDict) 
            {
                foreach(var vertex in graph.Value.Vertices) 
                {
                    _community = new Community<int>(vertex);
                    Assert.IsTrue(_community.Contains(vertex),"TODO");
                }
            }
        }

        [Test]
        public void Community_ContainsRange_ReturnTrue() 
        {
            foreach(var graph in _graphDict) 
            {
                _community = new Community<int>(graph.Value.Vertices);
                Assert.IsTrue(_community.Contains(graph.Value.Vertices),"TODO");
            }
        }

        [Test]
        public void Community_Add_ReturnTrue() 
        {
            foreach (var graph in _graphDict)
            {
                _community = new Community<int>();
                var vertList = new List<int>();
                int i = 0;
                foreach(var vertex in graph.Value.Vertices) 
                {
                    if (i%2 == 0) 
                    {
                        _community.Add(vertex);
                        vertList.Add(vertex);
                    }
                    i++;
                }
                Assert.IsTrue(_community.Contains(vertList),"TODO");
            }
        }

        [Test]
        public void Community_AddRange_ReturnTrue()
        {
            foreach (var graph in _graphDict)
            {
                _community = new Community<int>();
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
                _community.Add(vertList);
                Assert.IsTrue(_community.Contains(vertList),"TODO");
            }
        }

        [Test]
        public void Community_Remove_ReturnTrue() 
        {
            foreach(var graph in _graphDict)
            {
                _community = new Community<int>(graph.Value.Vertices);
                foreach(var vertex in graph.Value.Vertices) 
                {
                    bool answer = _community.Remove(vertex);
                    Assert.IsTrue((answer == true )&& !_community.Contains(vertex),$"Can't remove vertex {vertex} in graph {graph.Key}");
                }
            }
        }
        
        [Test]
         public void Community_RemoveRange_ReturnTrue() 
        {
            foreach(var graph in _graphDict)
            {
                _community = new Community<int>(graph.Value.Vertices);
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
                bool answer = _community.Remove(vertList);
                Assert.IsTrue(answer == true && !_community.Contains(vertList),"TODo");
            }
        }

        [Test]
        public void Community_Clear_ReturnTrue() 
        {
            foreach(var graph in _graphDict)
            {
                _community = new Community<int>();
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
                _community.Clear();
                Assert.IsTrue(_community.GetVertexCount() == 0,"TODo");
            }
        }

    }
}
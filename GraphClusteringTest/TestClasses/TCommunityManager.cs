using System.Collections.Generic;
using NUnit.Framework;
using QuikGraph;

namespace GraphClustering.UnitTests
{
    [TestFixture]
    public class TCommunityManager
    {
        private Dictionary<string,IEdgeListAndIncidenceGraph<int, IEdge<int>>> _graphDict;

        [SetUp]
        public void SetUp() => _graphDict = UtilityFunctions.GetGraphsDict();

        [Test]
        public void CommunityManager_Constructor_ReturnTrue() 
        {
            foreach(var graph in _graphDict.Values) 
            {
                try 
                {
                    var communityManager = new CommunityManager<int>(graph);
                }
                catch 
                {
                    Assert.IsTrue(false, "The constructor mustn't throw an exceptions if the graph is not null.");
                }
            }

            bool wasExeption = false;
            try 
            {
                var communityManager = new CommunityManager<int>(null);
            }
            catch 
            {
                wasExeption = true;
            }
            Assert.IsTrue(wasExeption, "The constructor must throw an exceptions if the graph is null.");
        }

        [Test]
        public void CommunityManager_IsValidCommunity_ReterunTrue()
        {
            foreach(var graph in _graphDict.Values) 
            {
                var communityManager = new CommunityManager<int>(graph);
                foreach(var vertex in graph.Vertices) 
                {
                    var singleVertexCommunity = new Community<int>(vertex);
                    Assert.IsTrue(communityManager.IsValidCommunity(singleVertexCommunity),"A community must be valid if it consists of vertices from graph that object was created with.");
                }
                var allVerticesCommunity = new Community<int>(graph.Vertices);
                Assert.IsTrue(communityManager.IsValidCommunity(allVerticesCommunity),"A community must be valid if it consists of vertices from graph that object was created with.");
            }
        }

        [Test]
        public void CommunityManager_GetEdgeCountInCommunity_ReturnTrue() 
        {
            foreach(var graph in _graphDict.Values) 
            {
                var communityManager = new CommunityManager<int>(graph);
                var community = new Community<int>(graph.Vertices);
                Assert.IsTrue(communityManager.GetEdgeCount(community) == graph.EdgeCount);
            }
        }

        [Test]
        public void CommunityManager_GetEdgeCountFromVertToComm_ReturnTrue()
        {
            Assert.True(0 == getEdgeCount(_graphDict["DGraph1"],vertexFrom: 0,verticesTo: new []{ 1,3,4,5,7 }));
            Assert.True(2 == getEdgeCount(_graphDict["DGraph1"],vertexFrom: 10,verticesTo: new []{ 2,4,11,6 }));
            Assert.True(0 == getEdgeCount(_graphDict["DGraph1"],vertexFrom: 0,verticesTo: new []{ 0,1,5,7 }));
            Assert.True(2 == getEdgeCount(_graphDict["DGraph1"],vertexFrom: 5,verticesTo: new []{ 0,1,5,7 }));

            Assert.True(2 == getEdgeCount(_graphDict["UGraph1"],vertexFrom: 0,verticesTo: new []{ 1,2,4,6 }));
            Assert.True(4 == getEdgeCount(_graphDict["UGraph1"],vertexFrom: 0,verticesTo: new []{ 2,4,11,6 }));

            int getEdgeCount<TVertex>(IEdgeListAndIncidenceGraph<TVertex,IEdge<TVertex>> graph,TVertex vertexFrom,IEnumerable<TVertex> verticesTo) 
            {
                var communityManager = new CommunityManager<TVertex>(graph);
                var community = new Community<TVertex>(verticesTo);
                return communityManager.GetEdgeCount(vertexFrom,community);
            }
        }

        [Test]
        public void CommunityManager_GetEdgeCountFromCommToVert_ReturnTrue()
        {
            Assert.True(3 == getEdgeCount(_graphDict["DGraph1"],verticesFrom: new []{ 1,3,4,5,7 },vertexTo: 0));
            Assert.True(0 == getEdgeCount(_graphDict["DGraph1"],verticesFrom: new []{ 2,4,11,6 },vertexTo: 10));
            Assert.True(3 == getEdgeCount(_graphDict["DGraph1"],verticesFrom: new []{ 0,1,5,7 },vertexTo: 0));
            Assert.True(1 == getEdgeCount(_graphDict["DGraph1"],verticesFrom: new []{ 0,1,5,7 },vertexTo: 5));

            Assert.True(2 == getEdgeCount(_graphDict["UGraph1"],verticesFrom: new []{ 1,2,4,6 },vertexTo: 0));
            Assert.True(4 == getEdgeCount(_graphDict["UGraph1"],verticesFrom: new []{ 0,1,2,4,6 },vertexTo: 0));

            int getEdgeCount<TVertex>(IEdgeListAndIncidenceGraph<TVertex,IEdge<TVertex>> graph,IEnumerable<TVertex> verticesFrom, TVertex vertexTo) 
            {
                var communityManager = new CommunityManager<TVertex>(graph);
                var communityFrom = new Community<TVertex>(verticesFrom);
                return communityManager.GetEdgeCount(communityFrom, vertexTo);
            }
        }

        [Test]
        public void CommunityManager_GetEdgeCountFromCommToComm_ReturnTrue()
        {
            Assert.True(0 == getEdgeCount(_graphDict["DGraph1"],verticesFrom: new []{ 0,1,3,4,5,7 },verticesTo: new []{ 2,6,8,9,10,11 }));
            Assert.True(0 == getEdgeCount(_graphDict["DGraph1"],verticesFrom: new []{ 5,1,0 },verticesTo: new []{ 7,3,4 }));
            Assert.True(2 == getEdgeCount(_graphDict["DGraph1"],verticesFrom: new []{ 7,3,4 },verticesTo: new []{ 5,1,0 }));

            Assert.True(2 == getEdgeCount(_graphDict["UGraph1"],verticesFrom: new []{ 0,4,8 },verticesTo: new []{ 1,2,3 }));
            Assert.True(6 == getEdgeCount(_graphDict["UGraph1"],verticesFrom: new []{ 0,4,8 },verticesTo: new []{ 0,1,2,3 }));


            int getEdgeCount<TVertex>(IEdgeListAndIncidenceGraph<TVertex,IEdge<TVertex>> graph,IEnumerable<TVertex> verticesFrom, IEnumerable<TVertex> verticesTo) 
            {
                var communityManager = new CommunityManager<TVertex>(graph);
                var communityFrom = new Community<TVertex>(verticesFrom);
                var communityTo = new Community<TVertex>(verticesTo);
                return communityManager.GetEdgeCount(communityFrom, communityTo);
            }
        }


    }
    
}
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
        public void SetUp()
        {   
            _graphDict = UtilityFunctions.GetGraphsDict();
        }

        [Test]
        public void CommunityManager_Constructor_ReturnTrue() 
        {
            foreach(var graph in _graphDict.Values) 
            {
                try 
                {
                    var communityManager = new CommunityManager<int>(graph);
                    Assert.IsTrue(true, "TODO");
                }
                catch 
                {
                    Assert.IsTrue(false, "TODO");
                }
            }
        }
        
        [Test]
        public void CommunityManager_Constructor_ReturnFalse() 
        {
            try 
            {
                var communityManager = new CommunityManager<int>(null);
                Assert.IsFalse(true, "TODO");
            }
            catch 
            {
                Assert.IsFalse(false, "TODO");
            }
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
                    Assert.IsTrue(communityManager.IsValidCommunity(singleVertexCommunity),"TODO");
                }
                var allVerticesCommunity = new Community<int>(graph.Vertices);
                Assert.IsTrue(communityManager.IsValidCommunity(allVerticesCommunity),"TODO");
            }
        }

        [Test]
        public void CommunityManager_GetEdgeCountInCommunity_ReturnTrue() 
        {
            foreach(var graph in _graphDict.Values) 
            {
                var communityManager = new CommunityManager<int>(graph);
                var community = new Community<int>(graph.Vertices);
                Assert.IsTrue(communityManager.GetEdgeCount(community) == graph.EdgeCount, "TODO");
            }
        }

        [Test]
        public void CommunityManager_GetEdgeCountFromVertToComm_ReturnTrue()
        {
            var communityManager = new CommunityManager<int>(_graphDict["DGraph1"]);
            Assert.True(0 == getEdgeCount(communityManager,vertexFrom: 0,verticesTo: new []{ 1,3,4,5,7 }),"TODO");
            Assert.True(2 == getEdgeCount(communityManager,vertexFrom: 10,verticesTo: new []{ 2,4,11,6 }),"TODO");
            Assert.True(0 == getEdgeCount(communityManager,vertexFrom: 0,verticesTo: new []{ 0,1,5,7 }),"TODO");
            Assert.True(2 == getEdgeCount(communityManager,vertexFrom: 5,verticesTo: new []{ 0,1,5,7 }),"TODO");

            communityManager = new CommunityManager<int>(_graphDict["UGraph1"]);
            Assert.True(2 == getEdgeCount(communityManager,vertexFrom: 0,verticesTo: new []{ 1,2,4,6 }),"TODO");
            Assert.True(4 == getEdgeCount(communityManager,vertexFrom: 0,verticesTo: new []{ 2,4,11,6 }),"TODO");

            int getEdgeCount<TVertex>(CommunityManager<TVertex> communityManager,TVertex vertexFrom,IEnumerable<TVertex> verticesTo) 
            {
                var community = new Community<TVertex>(verticesTo);
                return communityManager.GetEdgeCount(vertexFrom,community);
            }
        }

        [Test]
        public void CommunityManager_GetEdgeCountFromCommToVert_ReturnTrue()
        {
            var communityManager = new CommunityManager<int>(_graphDict["DGraph1"]);
            Assert.True(3 == getEdgeCount(communityManager,verticesFrom: new []{ 1,3,4,5,7 },vertexTo: 0),"TODO");
            Assert.True(0 == getEdgeCount(communityManager,verticesFrom: new []{ 2,4,11,6 },vertexTo: 10),"TODO");
            Assert.True(3 == getEdgeCount(communityManager,verticesFrom: new []{ 0,1,5,7 },vertexTo: 0),"TODO");
            Assert.True(1 == getEdgeCount(communityManager,verticesFrom: new []{ 0,1,5,7 },vertexTo: 5),"TODO");

            communityManager = new CommunityManager<int>(_graphDict["UGraph1"]);
            Assert.True(2 == getEdgeCount(communityManager,verticesFrom: new []{ 1,2,4,6 },vertexTo: 0),"TODO");
            Assert.True(4 == getEdgeCount(communityManager,verticesFrom: new []{ 0,1,2,4,6 },vertexTo: 0),"TODO");

            int getEdgeCount<TVertex>(CommunityManager<TVertex> communityManager,IEnumerable<TVertex> verticesFrom, TVertex vertexTo) 
            {
                var communityFrom = new Community<TVertex>(verticesFrom);
                return communityManager.GetEdgeCount(communityFrom, vertexTo);
            }
        }

        [Test]
        public void CommunityManager_GetEdgeCountFromCommToComm_ReturnTrue()
        {
            var communityManager = new CommunityManager<int>(_graphDict["DGraph1"]);
            Assert.True(0 == getEdgeCount(communityManager,verticesFrom: new []{ 0,1,3,4,5,7 },verticesTo: new []{ 2,6,8,9,10,11 }),"TODO");
            Assert.True(0 == getEdgeCount(communityManager,verticesFrom: new []{ 5,1,0 },verticesTo: new []{ 7,3,4 }),"TODO");
            Assert.True(2 == getEdgeCount(communityManager,verticesFrom: new []{ 7,3,4 },verticesTo: new []{ 5,1,0 }),"TODO");

            communityManager = new CommunityManager<int>(_graphDict["UGraph1"]);
            Assert.True(2 == getEdgeCount(communityManager,verticesFrom: new []{ 0,4,8 },verticesTo: new []{ 1,2,3 }),"TODO");
            Assert.True(6 == getEdgeCount(communityManager,verticesFrom: new []{ 0,4,8 },verticesTo: new []{ 0,1,2,3 }),"TODO");


            int getEdgeCount<TVertex>(CommunityManager<TVertex> communityManager,IEnumerable<TVertex> verticesFrom, IEnumerable<TVertex> verticesTo) 
            {
                var communityFrom = new Community<TVertex>(verticesFrom);
                var communityTo = new Community<TVertex>(verticesTo);
                return communityManager.GetEdgeCount(communityFrom, communityTo);
            }
        }


    }
    
}
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

        }

        [Test]
        public void CommunityManager_GetEdgeCountFromCommToVert_ReturnTrue()
        {
            
        }

        [Test]
        public void CommunityManager_GetEdgeCountFromCommToComm_ReturnTrue()
        {
            
        }


    }
    
}
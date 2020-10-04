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
            // DGraph1
            // edge count from 0 to { 1,3,4,5,7 }
            var communityManager = new CommunityManager<int>(_graphDict["DGraph1"]);
            var community = new Community<int>();
            community.Add(new List<int>(){ 1,3,4,5,7 });
            Assert.True(communityManager.GetEdgeCount(0,community) == 0,"TODO");
            community.Clear();
            // edge count from 10 to { 2,4,11,6 }
            community.Add(new List<int>(){ 2,4,11,6 });
            Assert.True(communityManager.GetEdgeCount(10,community) == 2,"TODO");
            community.Clear();
            // edge count from 0 to { 0,1,5,7 }
            community.Add(new List<int>(){ 0,1,5,7 });
            Assert.True(communityManager.GetEdgeCount(0,community) == 0,"TODO");
            community.Clear();
            // edge count from 5 to { 0,1,5,7 }
            community.Add(new List<int>(){ 0,1,5,7 });
            Assert.True(communityManager.GetEdgeCount(5,community) == 2,"TODO");
            community.Clear();

            // UGraph1
            // edge count from 0 to { 1,2,4,6 }
            communityManager = new CommunityManager<int>(_graphDict["UGraph1"]);
            community = new Community<int>();
            community.Add(new List<int>(){ 1,2,4,6 });
            Assert.True(communityManager.GetEdgeCount(0,community) == 2,"TODO");
            community.Clear();
            // edge count from 0 to { 0,1,2,4,6 }
            community.Add(new List<int>(){ 2,4,11,6 });
            Assert.True(communityManager.GetEdgeCount(0,community) == 4,"TODO");
            community.Clear();
        }

        [Test]
        public void CommunityManager_GetEdgeCountFromCommToVert_ReturnTrue()
        {
            // DGraph1
            // edge count from { 1,3,4,5,7 } to 0
            var communityManager = new CommunityManager<int>(_graphDict["DGraph1"]);
            var community = new Community<int>();
            community.Add(new List<int>(){ 1,3,4,5,7 });
            Assert.True(communityManager.GetEdgeCount(community,0) == 3,"TODO");
            community.Clear();
            // edge count from { 2,4,11,6 } to 10
            community.Add(new List<int>(){ 2,4,11,6 });
            Assert.True(communityManager.GetEdgeCount(community,10) == 0,"TODO");
            community.Clear();
            // edge count from { 0,1,5,7 } to 0
            community.Add(new List<int>(){ 0,1,5,7 });
            Assert.True(communityManager.GetEdgeCount(community,0) == 3,"TODO");
            community.Clear();
            // edge count from { 0,1,5,7 } to 5
            community.Add(new List<int>(){ 0,1,5,7 });
            Assert.True(communityManager.GetEdgeCount(community,5) == 1,"TODO");
            community.Clear();

            // UGraph1
            // edge count from { 1,2,4,6 } to 0
            communityManager = new CommunityManager<int>(_graphDict["UGraph1"]);
            community = new Community<int>();
            community.Add(new List<int>(){ 1,2,4,6 });
            Assert.True(communityManager.GetEdgeCount(community,0) == 2,"TODO");
            community.Clear();
            // edge count from { 0,1,2,4,6 } to 0
            community.Add(new List<int>(){ 2,4,11,6 });
            Assert.True(communityManager.GetEdgeCount(community,0) == 4,"TODO");
            community.Clear();
        }

        [Test]
        public void CommunityManager_GetEdgeCountFromCommToComm_ReturnTrue()
        {
            // DGraph1
            // edge count from { 0,1,3,4,5,7 } to { 2,6,8,9,10,11 }
            var communityManager = new CommunityManager<int>(_graphDict["DGraph1"]);
            var communityForm = new Community<int>();
            var communityTo = new Community<int>();
            communityForm.Add(new List<int>(){ 0,1,3,4,5,7 });
            communityTo.Add(new List<int>(){ 2,6,8,9,10,11 });
            Assert.True(communityManager.GetEdgeCount(communityForm,communityTo) == 0,"TODO");
            communityForm.Clear();
            communityTo.Clear();
            // edge count from { 5,1,0 } to { 7,3,4 }
            communityForm.Add(new List<int>(){ 5,1,0 });
            communityTo.Add(new List<int>(){ 7,3,4 });
            Assert.True(communityManager.GetEdgeCount(communityForm,communityTo) == 0,"TODO");
            communityForm.Clear();
            communityTo.Clear();
            // edge count from { 7,3,4 } to { 5,1,0 } 
            communityForm.Add(new List<int>(){ 7,3,4 });
            communityTo.Add(new List<int>(){ 5,1,0 });
            Assert.True(communityManager.GetEdgeCount(communityForm,communityTo) == 2,"TODO");
            communityForm.Clear();
            communityTo.Clear();

            // UGraph1
            // edge count from { 0,4,8 } to { 1,2,3 }
            communityManager = new CommunityManager<int>(_graphDict["UGraph1"]);
            communityForm = new Community<int>();
            communityTo = new Community<int>();
            communityForm.Add(new List<int>(){ 0,4,8 });
            communityTo.Add(new List<int>(){ 1,2,3 });
            Assert.True(communityManager.GetEdgeCount(communityForm,communityTo) == 2,"TODO");
            communityForm.Clear();
            communityTo.Clear();
            // edge count from { 0,4,8 } to { 0,1,2,3 }
            communityForm.Add(new List<int>(){ 0,4,8 });
            communityTo.Add(new List<int>(){ 0,1,2,3 });
            Assert.True(communityManager.GetEdgeCount(communityForm,communityTo) == 6,"TODO");
            communityForm.Clear();
            communityTo.Clear();
        }


    }
    
}
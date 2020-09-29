using System.Collections.Generic;
using NUnit.Framework;
using QuikGraph;

namespace GraphClustering.UnitTests
{
    [TestFixture]
    public class TCommunityManager
    {
        private Dictionary<string,IEdgeListAndIncidenceGraph<int, Edge<int>>> _graphDict;

        [SetUp]
        public void SetUp()
        {   
            _graphDict = UtilityFunctions.GetGraphsDict();
            
        }

        [Test]
        public void CommunityManager_GetEdgeCount_ReturnTrue() 
        {
            foreach(var graph in _graphDict.Values) 
            {
                var communityManager = new CommunityManager<int>(graph);
                var community = new Community<int>(graph.Vertices);
                Assert.IsTrue(communityManager.GetEdgeCount(community) == graph.EdgeCount, "TODO");
            }
        }

        

    }
    
}
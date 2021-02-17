using System.Collections.Generic;
using NUnit.Framework;
using GraphClustering.Algorithms;

namespace GraphClustering.UnitTests 
{
    [TestFixture]
    public class Louvain
    {
        private Dictionary<string, IPartitionableGraph<int?, IEdge<int?>>> _graphDict;

        [SetUp]
        public void SetUp() => _graphDict = GraphLibFacade.GraphBuilder.GetGraphsDict();

        [Test]
        public void Louvain_GetPartition_ReturnsTrue()
        {
            
        }
    }
}
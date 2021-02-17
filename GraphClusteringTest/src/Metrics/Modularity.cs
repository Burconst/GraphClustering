using System.Collections.Generic;
using NUnit.Framework;

namespace GraphClustering.UnitTests 
{
    [TestFixture]
    public class Modularity
    {
        private Dictionary<string, IPartitionableGraph<int?, IEdge<int?>>> _graphDict;

        [SetUp]
        public void SetUp() => _graphDict = GraphLibFacade.GraphBuilder.GetGraphs();

        [Test]
        public void Modularity_GetValue_ReturnTrue() 
        {
            
        }
    }
}
using NUnit.Framework;
using GraphClustering;

namespace GraphClusteringTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            Assert.IsTrue(Pls.plus(2,2) == 4);
        }
    }
}
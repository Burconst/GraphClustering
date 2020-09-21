using System.IO;
using System.Collections.Generic;
using NUnit.Framework;
using QuikGraph;
using QuikGraph.Collections;
using GraphClustering;



namespace Prime.UnitTests.Services
{
    [TestFixture]
    public class TestPartition
    {
        private List<Partition<int>> _partition;

        private string _testsDir = "../../../../TestClasses/TestData/";

        private List<AdjacencyGraph<int, Edge<int>>> GetGraphsFrom(List<string> filenames) 
        {
            var graphList = new List<AdjacencyGraph<int, Edge<int>>>();
            
            foreach(var filename in filenames) 
            {
                var graph = new AdjacencyGraph<int, Edge<int>>();
                using(var fstream = new StreamReader(filename)) 
                {
                    while(!fstream.EndOfStream) 
                    {
                        string line = fstream.ReadLine();
                        var sNumbers = line.Split(" ");
                        int i = 0, j = 0;
                        bool allCorrect = (sNumbers.Length == 2)&&int.TryParse(sNumbers[0], out i)&&int.TryParse(sNumbers[1], out j);
                        if (allCorrect) 
                        {
                            graph.AddVerticesAndEdge(new Edge<int>(i,j));   
                        } 
                        else 
                        {
                            throw new VertexNotFoundException("Invalid input. Please, use following format: v1 v2\nv3v4...");
                        }
                    }
                } 
                graphList.Add(graph);
            }

            return graphList;
        }

        [SetUp]
        public void SetUp()
        {
            _partition = new List<Partition<int>>();
             
            var filenames = new List<string>() { _testsDir+"test3.txt" };
            var graphList = GetGraphsFrom(filenames);
            foreach(var graph in graphList) 
            {
                _partition.Add(new Partition<int>(graph));
            }
        }

        [TearDown]
        public void TearDown()
        {
            _partition = null;
        }

        [Test]
        public void Partition_Size_ReturnTrue()
        {
            Assert.IsTrue(_partition[0].Size == 3, "Incorrect partition size.");
        }

    }
}
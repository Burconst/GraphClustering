using System.IO;
using System.Collections.Generic;
using QuikGraph;
using QuikGraph.Collections;
using GraphClustering;

namespace GraphClustering.UnitTests
{
    public static class UtilityFunctions
    {
        public static List<AdjacencyGraph<int, Edge<int>>> GetGraphsList(List<string> filenames) 
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
                    fstream.Close();
                } 
                graphList.Add(graph);
            }

            return graphList;
        }

        public static Dictionary<string,AdjacencyGraph<int, Edge<int>>> GetGraphsDict(List<string> filenames) 
        {
            var graphs = GetGraphsList(filenames);
            var resultDict = new Dictionary<string,AdjacencyGraph<int, Edge<int>>>();
            for (int i = 0; i < graphs.Count; i++) 
            {
                resultDict.Add(filenames[i].Substring(filenames[i].LastIndexOf("\\")+1),graphs[i]);
            }
            return resultDict;
        }

    }
}
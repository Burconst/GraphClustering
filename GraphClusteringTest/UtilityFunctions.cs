using System.Collections.Generic;
using QuikGraph;

namespace GraphClustering.UnitTests
{
    public static class UtilityFunctions
    {
        public static Dictionary<string, IEdgeListAndIncidenceGraph<int, Edge<int>>> GetGraphsDict()
        {   
            var _graphDict = new Dictionary<string, IEdgeListAndIncidenceGraph<int, Edge<int>>>();
            _graphDict.Add("DGraph1",GraphFactory.CreateDGraph1());
            _graphDict.Add("DGraph2",GraphFactory.CreateDGraph2());
            _graphDict.Add("DGraph3",GraphFactory.CreateDGraph3());
            _graphDict.Add("DGraph4",GraphFactory.CreateDGraph4());
            _graphDict.Add("DGraph5",GraphFactory.CreateDGraph5());
            _graphDict.Add("UGraph1",GraphFactory.CreateUGraph1());
            _graphDict.Add("UGraph2",GraphFactory.CreateUGraph2());
            _graphDict.Add("UGraph3",GraphFactory.CreateUGraph3());
            _graphDict.Add("UGraph4",GraphFactory.CreateUGraph4());
            _graphDict.Add("UGraph5",GraphFactory.CreateUGraph5());
            return _graphDict;
        }

    }
    
}
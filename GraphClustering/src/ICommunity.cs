using System.Collections.Generic;
using QuikGraph;
using QuikGraph.Collections;

namespace GraphClustering
{
    public interface ICommunity<TVertex> 
    {
        void Add(TVertex vertex);
        void Add(IEnumerable<TVertex> vertices);
        bool Remove(TVertex vertex);
        bool Remove(IEnumerable<TVertex> vertices);
        void Clear();
        bool Contains(TVertex vertex);
        bool Contains(IEnumerable<TVertex> vertices);
        int GetVertexCount();
    }

}
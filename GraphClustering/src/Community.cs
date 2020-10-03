using System.Collections.Generic;
using QuikGraph.Collections;

namespace GraphClustering
{
    public sealed class Community<TVertex> : ICommunity<TVertex>
    {
        private readonly VertexList<TVertex> _vertices;

        public Community()
        {
            _vertices = new VertexList<TVertex>();
        }
        public Community(TVertex vertex) 
        {
            _vertices = new VertexList<TVertex> { vertex };
        }

        public Community(IEnumerable<TVertex> vertices) 
        {
            if (_vertices == null) 
            {
                _vertices = new VertexList<TVertex>();
            }
            _vertices.AddRange(vertices);
        }

        public int GetVertexCount() 
        {
            return _vertices.Count;
        }

        public void Add(TVertex vertex) 
        {
         //   _vertices.Add(null);
            _vertices.Add(vertex);
        }

        public void Add(IEnumerable<TVertex> vertices) 
        {
            _vertices.AddRange(vertices);
        }

        public bool Remove(TVertex vertex) 
        {
            return _vertices.Remove(vertex);
        }

        public bool Remove(IEnumerable<TVertex> vertices) 
        {
            bool allRemoved = true;
            foreach(var vertex in vertices) 
            {
                allRemoved = Remove(vertex)? allRemoved : false;
            }
            return allRemoved;
        }

        public bool Contains(TVertex vertex) 
        {
            if(vertex.GetType().IsValueType) 
            {
                return _vertices.Contains(vertex);
            }

            foreach(var _vertex in _vertices) 
            {
                if (object.ReferenceEquals(_vertex,vertex))
                {
                    return true;
                }
            }
           return false;
        }

        public bool Contains(IEnumerable<TVertex> vertices)
        {
            bool contains = true;
            foreach (var vertex in vertices) 
            {
                if(!Contains(vertex)) 
                {
                    contains = false;
                }
            }
            return contains;
        }

        public void Clear() 
        {
            _vertices.Clear();
        }

        public List<TVertex>.Enumerator GetEnumerator() 
        {
            return _vertices.GetEnumerator();
        }

    }

}


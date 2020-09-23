using System.Collections.Generic;
using QuikGraph.Collections;

namespace GraphClustering
{
    public class Community<TVertex> : ICommunity<TVertex>
    {
        private readonly VertexList<TVertex> _vertices;

        public Community()
        {
            _vertices = new VertexList<TVertex>();
        }
        public Community(TVertex vertex) 
        {
            _vertices = new VertexList<TVertex>() { vertex };
        }

        public Community(VertexList<TVertex> vertices) 
        {
            _vertices = vertices;
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
            return _vertices.Contains(vertex);
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

    }

}


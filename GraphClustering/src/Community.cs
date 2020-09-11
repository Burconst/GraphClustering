using QuikGraph;
using QuikGraph.Collections;

namespace GraphClustering
{
    public class Community<TVertex>
    {
        public VertexList<TVertex> Vertices 
        {
            get;
            private set;
        }

        public int Size
        {
            get { return Vertices.Count; }
        }

        public Community(TVertex vertex) 
        {
            Vertices = new VertexList<TVertex>() { vertex };
        }

        public Community(VertexList<TVertex> vertices) 
        {
            Vertices = vertices;
        }

        public void Add(TVertex vertex) 
        {
            Vertices.Add(vertex);
        }

        public void Add(VertexList<TVertex> vertices) 
        {
            Vertices.AddRange(vertices);
        }

        public void Remove(TVertex vertex) 
        {
            if (Vertices.Contains(vertex)) 
            {
                Vertices.Remove(vertex);
            }
        }

        public void Remove(VertexList<TVertex> vertices)
        {
            foreach (var v in vertices) 
            {
                Remove(v);
            }
        }

    }

}


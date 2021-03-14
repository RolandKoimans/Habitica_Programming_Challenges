using System;
using System.Collections.Generic;

namespace MessageRoute
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inp = Console.ReadLine().Split(" ");

            int n = Int32.Parse(inp[0]);
            int m = Int32.Parse(inp[1]);

            Graph graph = new Graph(n, m);

            graph.ReadEdges();
            graph.FindShortestPath();
        }
    }

    class Graph {

        int n;
        int m;
        Vertex[] vertices;

        public Graph(int n, int m)
        {
            this.n = n;
            this.m = m;
            vertices = new Vertex[this.n+1];

            for(int i = 1; i <= n; i++)
            {
                vertices[i] = new Vertex(i);
            }

        }

        //Read the m edges and turn them into Edge objects
        public void ReadEdges()
        {
            for (int i = 0; i < m; i++)
            {
                string[] inpEdge = Console.ReadLine().Split(" ");

                int current = Int32.Parse(inpEdge[0]);
                int next = Int32.Parse(inpEdge[1]);

                //Add edges to corresponding vertex
                vertices[current].edges.Add(new Edge(current, next));

                //Undirected graph means we add the edge both ways
                vertices[next].edges.Add(new Edge(next, current));
            }
        }

        public void FindShortestPath()
        {
            //Set all visited nodes to false, for constant lookup later
            Dictionary<int, bool> visited = new Dictionary<int, bool>();
            for (int i = 1; i <= n; i++)
            {
                visited[i] = false;
            }

            //Set up for the search
            Queue<Vertex> q = new Queue<Vertex>();
            q.Enqueue(vertices[1]);
            visited[1] = true;
            bool found = false;

            //Search until computer n is found, otherwise if the queue is empty, there is no solution
            while (q.Count != 0)
            {
                Vertex current = q.Dequeue();

                //Found computer n, now backtrack for path
                if(current.label == n)
                {
                    found = true;
                    FindPath();
                    break;
                }

                //Check all unvisited edges
                foreach(Edge edge in current.edges)
                {
                    if (!visited[edge.next])
                    {
                        visited[edge.next] = true;
                        vertices[edge.next].parent = current.label;
                        q.Enqueue(vertices[edge.next]);
                    }
                }

            }

            //Queue is empty, no solution found
            if(!found)
            {
                Console.WriteLine("IMPOSSIBLE");
            }
        }

        //Find a path by backtracking
        public void FindPath()
        {
            List<int> path = new List<int>();

            path.Add(n);
            int parent = vertices[n].parent;
            path.Add(parent);

            while(parent != 0)
            {
                parent = vertices[parent].parent;
                if (parent != 0)
                {
                    path.Add(parent);
                }
            }

            for(int i = path.Count-1; i >= 0; i--)
            {
                Console.Write(path[i] + " ");
            }

        }

    
    }

    class Vertex {

        //Name of the vertex
        public int label;
        public List<Edge> edges;
        //Parent vertex for finding the route later
        public int parent;

        public Vertex(int label)
        {
            this.label = label;
            edges = new List<Edge>();
            parent = 0;
        }

    }

    class Edge {

        public int current;
        public int next;
        public Edge(int current, int next)
        {
            this.current = current;
            this.next = next;
        }
    
    }


}

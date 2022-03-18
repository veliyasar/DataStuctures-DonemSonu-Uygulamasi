using System;
using System.Collections.Generic;
using System.Linq;

namespace DS_Proje_4
{
	// C# program to print BFS traversal from a given source vertex. 
    // BFS(int s) traverses vertices reachable from s. 
 
    // This class represents a directed graph using adjacency list representation 
    class Graph
    {
        static void Main(string[] args)
        {
            var graph = new Graph(4);

            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 0);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 3);

            Console.Write("Following is Breadth First Traversal(starting from vertex 2): \n");
            graph.BFS(2);

            Console.ReadKey();
        }

        //Nnumber of vertices
        private int V;

        //Adjacency Lists 
        LinkedList<int>[] adj;

        public Graph(int V)
        {
            adj = new LinkedList<int>[V];
            for (var i = 0; i < adj.Length; i++)
            {
                adj[i] = new LinkedList<int>();
            }
            this.V = V;
        }

        // Function to add an edge into the graph 
        public void AddEdge(int v, int w)
        {
            adj[v].AddLast(w);

        }

        // Prints BFS traversal from a given source s 
        public void BFS(int s)
        {

            // Mark all the vertices as not visited(By default set as false) 
            var visited = new bool[V];
            for (var i = 0; i < V; i++)
                visited[i] = false;

            // Create a queue for BFS 
            var queue = new LinkedList<int>();

            // Mark the current node as visited and enqueue it 
            visited[s] = true;
            queue.AddLast(s);

            while (queue.Any())
            {
                // Dequeue a vertex from queue and print it
                s = queue.First();
                Console.Write(s + " ");
                queue.RemoveFirst();

                // Get all adjacent vertices of the dequeued vertex s.
                // If a adjacent has not been visited, then mark it visited and enqueue it 
                var list = adj[s];

                foreach (var val in list)
                {
                    if (visited[val]) continue;
                    visited[val] = true;
                    queue.AddLast(val);
                }
            }
        }
    }
}

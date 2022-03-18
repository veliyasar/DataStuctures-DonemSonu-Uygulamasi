using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_Proje_4
{
    // The program is for adjacency matrix representation of the graph 
	class PrimsMST
	{
        public static void Main()
        {
            int[,] graph = { { 0, 2, 0, 6, 0 },
                { 2, 0, 3, 8, 5 },
                { 0, 3, 0, 0, 7 },
                { 6, 8, 0, 0, 9 },
                { 0, 5, 7, 9, 0 } };

            primMST(graph);

            Console.ReadKey();
        }


        // Number of vertices in the graph 
        static int V = 5;

		// A utility function to find the vertex with minimum key value
		// from the set of vertices not yet included in PrimsMST 
		static int minKey(int[] key, bool[] mstSet)
		{
			// Initialize min value 
			int min = int.MaxValue, min_index = -1;

			for (int v = 0; v < V; v++)
				if (mstSet[v] == false && key[v] < min)
				{
					min = key[v];
					min_index = v;
				}

			return min_index;
		}

		// A utility function to print the constructed PrimsMST stored in parent[] 
		static void printMST(int[] parent, int[,] graph)
		{
			Console.WriteLine("Edge \tWeight");
			for (int i = 1; i < V; i++)
				Console.WriteLine(parent[i] + " - " + i + "\t" + graph[i, parent[i]]);
		}

		// Function to construct and print PrimsMST for a graph represented 
		// using adjacency matrix representation 
		static void primMST(int[,] graph)
		{
			// Array to store constructed PrimsMST 
			int[] parent = new int[V];

			// Key values used to pick minimum weight edge in cut 
			int[] key = new int[V];

			// To represent set of vertices included in PrimsMST 
			bool[] mstSet = new bool[V];

			// Initialize all keys as INFINITE 
			for (int i = 0; i < V; i++)
			{
				key[i] = int.MaxValue;
				mstSet[i] = false;
			}

			// Always include first 1st vertex in PrimsMST. 
			// Make key 0 so that this vertex is picked as first vertex 
			// First node is always root of PrimsMST 
			key[0] = 0;
			parent[0] = -1;

			// The PrimsMST will have V vertices 
			for (int count = 0; count < V - 1; count++)
			{
                // Pick thd minimum key vertex from the set of vertices 
				// not yet included in PrimsMST 
				int u = minKey(key, mstSet);

				// Add the picked vertex to the PrimsMST Set 
				mstSet[u] = true;

				// Update key value and parent index of the adjacent vertices of the picked vertex.
				// Consider only those vertices which are not yet included in PrimsMST 
				for (int v = 0; v < V; v++)
					// graph[u][v] is non zero only for adjacent vertices of m 
					// mstSet[v] is false for vertices not yet included in PrimsMST Update 
					// the key only if graph[u][v] is smaller than key[v] 
					if (graph[u, v] != 0 && mstSet[v] == false && graph[u, v] < key[v])
					{
						parent[v] = u;
						key[v] = graph[u, v];
					}
			}

			printMST(parent, graph);
		}
    }
}

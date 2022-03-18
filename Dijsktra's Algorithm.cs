using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static int INF = 1000;

        static void Main(string[] args)
        {
           int N = 5;
           int SRC = 2;
            
		int[,] cost = {	{ INF,    5,    3, INF,    2},
					{ INF, INF,    2,    6, INF},
					{ INF,    1, INF,    2, INF},
					{ INF, INF, INF, INF, INF},
					{ INF,    6,   10,    4,    INF} };

            int[] distances = new int[N];

            int[] previous = Distance(N, cost, distances, SRC);

            for (int i = 0; i < distances.Length; ++i)
                if (distances[i] != INF)
                    Console.WriteLine(distances[i]);
                else Console.WriteLine("INF");

            int DEST = 1;
            Console.WriteLine("\n Shortest path from " + SRC + " to " + DEST + " (straight):");
            printShortestPathStraight(DEST, previous);
            Console.WriteLine("\n\n Shortest path from " + SRC + " to " + DEST + " (reverse) :");
            printShortestPathReverse(DEST, previous);
            Console.ReadKey();
        }

        public static int[] Distance(int N, int[,] cost, int[] D, int src)
        {
            int w, v, min;
            bool[] visited = new bool[N];
            int[] previous = new int[N]; //for tracking shortest paths (güzergah)

            //initialization of D[], visited[] and previous[] arrays according to src node
            for (v = 0; v < N; v++)
            {
                if (v != src)
                {
                    visited[v] = false;
                    D[v] = cost[src, v];
                    if (D[v] != INF) //there is a connection between src and v
                    {
                        previous[v] = src;
                    }
                    else //no path from source
                    {
                        previous[v] = -1;
                    }
                }
                else
                {
                    visited[v] = true;
                    D[v] = 0;
                    previous[v] = -1;
                }

            }

            // Searching for shortest paths
            for (int i = 0; i < N; ++i)
            {
                min = INF;
                for (w = 0; w < N; w++)
                    if (!visited[w])
                        if (D[w] < min)
                        {
                            v = w;
                            min = D[w];
                        }

                visited[v] = true;

                for (w = 0; w < N; w++)
                    if (!visited[w])
                        if (min + cost[v, w] < D[w])
                        {
                            D[w] = min + cost[v, w];
                            previous[w] = v; //update the path info
                        }
            }

            return previous;
        }

        public static void printShortestPathStraight(int dest, int[] previous)
        {
            Stack<int> pathStack = new Stack<int>();

            int current = dest;
            pathStack.Push(current);

            while (previous[current] != -1)
            {
                current = previous[current];
                pathStack.Push(current);
            }

            if (pathStack.Count == 1)
            {
                Console.Write(" NO PATH");
                return;
            }

            while (pathStack.Count > 0)
            {
                Console.Write(" -> " + pathStack.Pop());
            }
        }

        public static void printShortestPathReverse(int dest, int[] previous)
        {
            int current = dest;
            Console.Write(dest + " <- ");

            while (previous[current] != -1)
            {
                current = previous[current];
                Console.Write(current + " <- ");
            }

        }
    }
}

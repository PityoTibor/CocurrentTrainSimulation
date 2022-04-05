using Route.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route
{
    public class Dijkstra
    {
        public static void DijsktraShortestRoute(int[][] adjacencyMatrix, int numberOfVertex, int[] distance, int[] parent)
        {
            PriorityQueue<int> vertexQueue = new PriorityQueue<int>(true);
            //adding all vertex to priority queue
            for (int i = 0; i < numberOfVertex; i++)
                vertexQueue.Enqueue(distance[i], i); // priority = distance, object = vertex

            //treversing to all vertices
            while (vertexQueue.Count > 0)
            {
                var u = vertexQueue.Dequeue(); // vertax with least distance
                                               //Traversing to all connecting edges
                for (int v = 0; v < adjacencyMatrix[u].Length; v++)
                {
                    if (adjacencyMatrix[u][v] > 0)
                    {
                        Relax(u, v, adjacencyMatrix[u][v], distance, parent);
                        //updating priority value since distance is changed
                        vertexQueue.UpdatePriority(v, distance[v]);
                    }
                }
            }
            ;
        }

        //public static void DijsktraShortestRoute2(Station[][] adjacencyMatrix, int numberOfVertex, int[] distance, int[] parent)
        //{
        //    PriorityQueue<int> vertexQueue = new PriorityQueue<int>(true);

        //    for (int i = 0; i < numberOfVertex; i++)
        //        vertexQueue.Enqueue(distance[i], i); // priority = distance, object = vertex

        //    //treversing to all vertices
        //    while (vertexQueue.Count > 0)
        //    {
        //        var u = vertexQueue.Dequeue(); // vertax with least distance
        //                                       //Traversing to all connecting edges
        //        for (int v = 0; v < adjacencyMatrix[u].Length; v++)
        //        {
        //            if (adjacencyMatrix[u][v] > 0)
        //            {
        //                Relax(u, v, adjacencyMatrix[u][v], distance, parent);
        //                //updating priority value since distance is changed
        //                vertexQueue.UpdatePriority(v, distance[v]);
        //            }
        //        }
        //    }
        //}

        static void Relax(int u, int v, int weight, int[] distance, int[] parent)
        {
            if (distance[u] != int.MaxValue && distance[v] > distance[u] + weight)
            {
                distance[v] = distance[u] + weight;
                parent[v] = u;
            }
        }

        public static void PrintPath(int u, int v, int[] distance, int[] parent)
        {
            if (v < 0 || u < 0)
            {
                return;
            }
            if (v != u)
            {
                PrintPath(u, parent[v], distance, parent);
                Console.WriteLine("Vertax {0} weight: {1}", v, distance[v]);
            }
            else
                Console.WriteLine("Vertax {0} weight: {1}", v, distance[v]);
        }
    }
}

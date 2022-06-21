using Route;
using Route.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentTrainSimulation
{
    public class TrafficManager
    {
        static int number = 1;
        public class ShortestLineMapDiksktra
        {
            public int[] distance { get; set; }
            public int[] parent { get; set; }
        }

        public class ShortestLineMapFloyd_Warshal
        {
            public List<Road> roads;
            public ShortestLineMapFloyd_Warshal()
            {
                this.roads = new List<Road>();
            }
        }

        public ShortestLineMapDiksktra Map_Dijsktra { get; set; } = new ShortestLineMapDiksktra();
        public ShortestLineMapFloyd_Warshal Map_FloydWarshall { get; set; }

        public int id { get; set; } = number++;
        public void GetAllShortestPath()
        {
            //int[][] adjacencyMatrix = new int[][]
            //{
            //        new int[] { 0, 1, 0, 2, 4, 0, 0, 0 },
            //        new int[] { 1, 0, 9, 2, 0, 0, 0, 0 },
            //        new int[] { 0, 9, 0, 5, 0, 5, 0, 0 },
            //        new int[] { 2, 2, 5, 0, 3, 0, 0, 0 },
            //        new int[] { 4, 0, 0, 0, 0, 0, 0, 3 },
            //        new int[] { 0, 0, 1, 3, 0, 0, 3, 0 },
            //        new int[] { 0, 0, 0, 0, 0, 3, 0, 2 },
            //        new int[] { 0, 0, 0, 3, 0, 0, 0, 2 }
            //};

            //int[,] adjacencyMatrix = new int[,]
            //{
            //         { 0, 1, 0, 2, 4, 0, 0, 0 },
            //         { 1, 0, 9, 2, 0, 0, 0, 0 },
            //         { 0, 9, 0, 5, 0, 5, 0, 0 },
            //         { 2, 2, 5, 0, 3, 0, 0, 0 },
            //         { 4, 0, 0, 0, 0, 0, 0, 3 },
            //         { 0, 0, 1, 3, 0, 0, 3, 0 },
            //         { 0, 0, 0, 0, 0, 3, 0, 2 },
            //         { 0, 0, 0, 3, 0, 0, 0, 2 }
            //};

            int[,] adjacencyMatrix =
            {
                { 1, 2, 1}, {2, 1, 1 },
                { 1, 4, 2}, {4, 1, 2 },
                { 1, 5, 4}, {5, 1, 4 },

                { 2, 3, 9}, {3, 2, 9 },
                { 2, 4, 2}, {4, 2, 2 },

                { 3, 4, 5}, {4, 3, 5 },
                { 3, 6, 1}, {6, 3, 1 },

                { 4, 6, 3}, {6, 4, 3 },

                { 5, 8, 3}, {8, 5, 3 },

                { 6, 7, 3}, {7, 6, 3 },

                { 7, 8, 2}, {8, 7, 2 },

            };

            Map_FloydWarshall = new ShortestLineMapFloyd_Warshal();
            int numVerticies = 8;
            Map_FloydWarshall.roads = Floyd_Warshall.FloydWarshall(adjacencyMatrix, numVerticies);

            //int numberOfVertex = adjacencyMatrix[0].Length;
            //Map.distance = Enumerable.Repeat(int.MaxValue, numberOfVertex).ToArray();
            //Map.parent = Enumerable.Repeat(-1, numberOfVertex).ToArray();
            //Map.distance[0] = 0;
            //Dijkstra.DijsktraShortestRoute(adjacencyMatrix, numberOfVertex, Map.distance, Map.parent);
        }

        private Dictionary<int, Tuple<int, int>> CreateMapRouteDijsktra()
        {
            Dictionary<int, Tuple<int, int>> tmp = new Dictionary<int, Tuple<int, int>>();
            for (int i = 0; i < Map_Dijsktra.distance.Length; i++)
            {
                tmp.Add(i, new Tuple<int, int>(Map_Dijsktra.distance[i], Map_Dijsktra.parent[i]));
            }

            return tmp;
        }


    }
}

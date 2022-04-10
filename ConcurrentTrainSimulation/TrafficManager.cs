using Route;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentTrainSimulation
{
    public class TrafficManager
    {
        internal class ShortestLineMap
        {
            public int[] distance { get; set; }
            public int[] parent { get; set; }
        }

        ShortestLineMap Map { get; set; } = new ShortestLineMap();

        private void FillMap()
        {
            int[][] adjacencyMatrix = new int[][]
            {
                    new int[] { 0, 1, 0, 2, 4, 0, 0, 0 },
                    new int[] { 1, 0, 9, 2, 0, 0, 0, 0 },
                    new int[] { 0, 9, 0, 5, 0, 5, 0, 0 },
                    new int[] { 2, 2, 5, 0, 3, 0, 0, 0 },
                    new int[] { 4, 0, 0, 0, 0, 0, 0, 3 },
                    new int[] { 0, 0, 1, 3, 0, 0, 3, 0 },
                    new int[] { 0, 0, 0, 0, 0, 3, 0, 2 },
                    new int[] { 0, 0, 0, 3, 0, 0, 0, 2 }
            };

            int numberOfVertex = adjacencyMatrix[0].Length;
            Map.distance = Enumerable.Repeat(int.MaxValue, numberOfVertex).ToArray();
            Map.parent = Enumerable.Repeat(-1, numberOfVertex).ToArray();
            Map.distance[0] = 0;
            Dijkstra.DijsktraShortestRoute(adjacencyMatrix, numberOfVertex, Map.distance, Map.parent);
        }

        private Dictionary<int, Tuple<int, int>> CreateMapRoute()
        {
            Dictionary<int, Tuple<int, int>> tmp = new Dictionary<int, Tuple<int, int>>();
            for (int i = 0; i < Map.distance.Length; i++)
            {
                tmp.Add(i, new Tuple<int, int>(Map.distance[i], Map.parent[i]));
            }

            return tmp;
        }
    }
}

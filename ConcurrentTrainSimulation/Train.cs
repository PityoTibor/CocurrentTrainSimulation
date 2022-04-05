using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Route;


namespace ConcurrentTrainSimulation
{
    public enum Phases {Init, Start, OnTheRoad, End }
    public class Train
    {
        public class shortestLineMap
        {
            public int[] distance { get; set; } /*= new int[8];*/
            public int[] parent { get; set; } /*= new int[8];*/
        }

        object lockobj = new object();
        List<ConcurrentStack<int>> fittings;
        public List<string> Citys = new List<string>()
        {
            "Abby","Bobby","Colly","DownTown"
        };

        public shortestLineMap map { get; set; } = new shortestLineMap();

        public Phases Phase { get; set; }

        public Train()
        {
            fittings = new List<ConcurrentStack<int>>();
        }

        public void Init()
        {
            AddFitting();
            FillMap();
            Phase = Phases.Init;

        }

        public void OnTheGo()
        {
            Phase = Phases.Start;
            Console.WriteLine($"A vonat {Phase}");
            for (int i = 0; i < Citys.Count; i++)
            {
                Phase = Phases.OnTheRoad;
                Console.WriteLine($"A vonat {Phase}");

                Console.WriteLine($"A vonat megérkezik a {i} megállóba");
                Console.WriteLine("Rakodás...");
                lock (this)
                    Monitor.Wait(this);
            }
        }
        private void AddFitting()
        {
            fittings.AddRange(Enumerable.Range(1, 4).Select(x => new ConcurrentStack<int>()));
        }

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
            map.distance = Enumerable.Repeat(int.MaxValue, numberOfVertex).ToArray();
            map.parent = Enumerable.Repeat(-1, numberOfVertex).ToArray();
            map.distance[0] = 0;
            Dijkstra.DijsktraShortestRoute(adjacencyMatrix, numberOfVertex, map.distance, map.parent);
        }
    }
}

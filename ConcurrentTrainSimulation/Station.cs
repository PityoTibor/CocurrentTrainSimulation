using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Route;

namespace ConcurrentTrainSimulation
{

    public class Stations
    {
        public Station[,] matrix;
        public void InitMatrix(int num)
        {
            matrix = new Station[10,10];
        }

        //static int[][] adjacencyMatrix = new int[][]
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
        static int[][] adjacencyMatrix = new int[][]
                {
                    new int []{ 0,0,0,3,12 },
                    new int []{ 0,0,2,0,0 },
                    new int []{ 0,0,0,2,0 },
                    new int []{ 0,5,3,0,0 },
                    new int []{ 0,0,7,0,0 }
                };

        static int numberOfVertex = adjacencyMatrix[0].Length;
        static int[] distance = Enumerable.Repeat(int.MaxValue, numberOfVertex).ToArray();
        int[] parent = Enumerable.Repeat(-1, numberOfVertex).ToArray();

        public void asd()
        {
            //int[][] adjacencyMatrix2 = new int[][]
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


            Route.Dijkstra.DijsktraShortestRoute(adjacencyMatrix, numberOfVertex,  distance,  parent);
            ;
        }

        public void CreateStations()
        {
            AddEdges(new Station(0, 0, 1, 1.0));
            AddEdges(new Station(1, 0, 3, 2.0));
            AddEdges(new Station(2, 0, 4, 4.0));

            AddEdges(new Station(3, 1, 0, 1.0));
            AddEdges(new Station(4, 1, 2, 9.0));
            AddEdges(new Station(5, 1, 3, 2.0));

            AddEdges(new Station(6, 2, 1, 9.0));
            AddEdges(new Station(7, 2, 3, 5.0));
            AddEdges(new Station(8, 2, 5, 5.0));

            AddEdges(new Station(9, 3, 0, 2.0));
            AddEdges(new Station(10, 3, 1, 2.0));
            AddEdges(new Station(11, 3, 2, 5.0));
            AddEdges(new Station(12, 3, 5, 3.0));

            AddEdges(new Station(13, 4, 0, 4.0));
            AddEdges(new Station(14, 4, 7, 3.0));

            AddEdges(new Station(15, 5, 2, 1.0));
            AddEdges(new Station(16, 5, 3, 3.0));
            AddEdges(new Station(17, 5, 6, 3.0));

            AddEdges(new Station(18, 6, 5, 3.0));
            AddEdges(new Station(19, 6, 7, 2.0));

            AddEdges(new Station(20, 7, 4, 3.0));
            AddEdges(new Station(21, 7, 6, 2.0));
        }

        private void AddEdges(Station edge)
        {
            matrix[edge.X, edge.Y] = edge;
        }

    }

    public class Station
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public double Value { get; set; }
        public bool Processed { get; set; } = false;

        public Station(int id, int x, int y, double value)
        {
            Id = id;
            X = x;
            Y = y;
            Value = value;
        }
    }
}

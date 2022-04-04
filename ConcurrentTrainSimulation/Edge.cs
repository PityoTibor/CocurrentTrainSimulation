using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrentTrainSimulation
{

    public class Stations
    {
        public Edge[,] matrix;
        public void InitMatrix(int num)
        {
            matrix = new Edge[10,10];
        }


        void asd()
        {
            int[][] adjacencyMatrix2 = new int[][]
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
        }

        public void CreateStations()
        {
            AddEdges(new Edge(0, 0, 1, 1.0));
            AddEdges(new Edge(1, 0, 3, 2.0));
            AddEdges(new Edge(2, 0, 4, 4.0));

            AddEdges(new Edge(3, 1, 0, 1.0));
            AddEdges(new Edge(4, 1, 2, 9.0));
            AddEdges(new Edge(5, 1, 3, 2.0));

            AddEdges(new Edge(6, 2, 1, 9.0));
            AddEdges(new Edge(7, 2, 3, 5.0));
            AddEdges(new Edge(8, 2, 5, 5.0));

            AddEdges(new Edge(9, 3, 0, 2.0));
            AddEdges(new Edge(10, 3, 1, 2.0));
            AddEdges(new Edge(11, 3, 2, 5.0));
            AddEdges(new Edge(12, 3, 5, 3.0));

            AddEdges(new Edge(13, 4, 0, 4.0));
            AddEdges(new Edge(14, 4, 7, 3.0));

            AddEdges(new Edge(15, 5, 2, 1.0));
            AddEdges(new Edge(16, 5, 3, 3.0));
            AddEdges(new Edge(17, 5, 6, 3.0));

            AddEdges(new Edge(18, 6, 5, 3.0));
            AddEdges(new Edge(19, 6, 7, 2.0));

            AddEdges(new Edge(20, 7, 4, 3.0));
            AddEdges(new Edge(21, 7, 6, 2.0));
        }

        private void AddEdges(Edge edge)
        {
            matrix[edge.X, edge.Y] = edge;
        }

    }



    public class Edge
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public double Value { get; set; }
        public bool Processed { get; set; } = false;

        public Edge(int id, int x, int y, double value)
        {
            Id = id;
            X = x;
            Y = y;
            Value = value;
        }
    }
}

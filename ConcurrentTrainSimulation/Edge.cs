using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentTrainSimulation
{
    public class Stations
    {
        int nodes = 21;
        public Edge[,] matrix;
        public void InitMatrix(int num)
        {
            matrix = new Edge[num, num];
        }

        public void CreateStations()
        {
            AddEdges(new Edge(1, 0, 1, 1.0));
            AddEdges(new Edge(2, 0, 3, 2.0));
            AddEdges(new Edge(3, 0, 4, 4.0));

            AddEdges(new Edge(4, 1, 0, 1.0));
            AddEdges(new Edge(5, 1, 2, 9.0));
            AddEdges(new Edge(6, 1, 3, 2.0));

            AddEdges(new Edge(7, 2, 1, 9.0));
            AddEdges(new Edge(8, 2, 3, 5.0));
            AddEdges(new Edge(9, 2, 5, 5.0));

            AddEdges(new Edge(10, 3, 0, 2.0));
            AddEdges(new Edge(11, 3, 1, 2.0));
            AddEdges(new Edge(12, 3, 2, 5.0));
            AddEdges(new Edge(11, 3, 5, 3.0));

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

        public Dictionary<int, Tuple<double, Edge>> DijsktraShortestRoute()
        {
            Dictionary<int, Tuple<double, Edge>> re = new Dictionary<int, Tuple<double, Edge>>();

            Queue<Tuple<Edge, int>> S = new Queue<Tuple<Edge, int>>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] != null)
                    {
                        S.Enqueue(new Tuple<Edge, int>(matrix[i,j], int.MaxValue));
                    }
                }
            }
            ;

            for (int i = 0; i < nodes; i++)
            {
                re.Add(i+1, new Tuple<double, Edge>(double.NaN, null));
            }
            ;

            Edge start = GetStartEdge();
            re.Add(start.Id, new Tuple<double, Edge>(0, null));

            GetMinValue(S);
            while (S.Count != 0)
            {

            }

            return re;
        }

        public void VisitAllEdge()
        {
            Queue<Edge> S = new Queue<Edge>();
            HashSet<Edge> F = new HashSet<Edge>();

            Edge start = GetStartEdge();
            S.Enqueue(start);
            F.Add(start);

            while (S.Count != 0)
            {
                Edge k = S.Dequeue();
                Process(k);
                List<Edge> allNeighbour = Neighbours(k);
                for (int i = 0; i < allNeighbour.Count; i++)
                {
                    if (!(F.Contains(allNeighbour[i])))
                    {
                        S.Enqueue(allNeighbour[i]);
                        F.Add(allNeighbour[i]);
                    }
                }
            }
        }

        private void GetMinValue(Queue<Tuple<Edge, int>> S)
        {
            var asd = S.Select(x => x.Item2).Min();
            ;
        }


        private List<Edge> Neighbours(Edge e)
        {
            List<Edge> allNeighbour = new List<Edge>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[e.Y, i] != e && matrix[e.Y, i] != null)
                {
                    Edge tmp = matrix[e.Y, i];
                    allNeighbour.Add(tmp);
                    //allNeighbour.Add(matrix[tmp.Y, tmp.X]);
                }
                    
            }

            return allNeighbour; 
        }

        private void Process(Edge e)
        {
            e.Processed = true;
        }

        private Edge GetStartEdge()
        {
            Edge RandomEdge = null;
            var rnd = new Random().Next(8);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[rnd, i] != null)
                    RandomEdge = matrix[rnd, i];
            }
            return RandomEdge;
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

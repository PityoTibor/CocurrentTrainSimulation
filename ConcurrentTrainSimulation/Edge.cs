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
        int nodes = 22;
        public Edge[,] matrix;
        public void InitMatrix(int num)
        {
            matrix = new Edge[num, num];
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

        public Dictionary<int, Tuple<double, Edge, List<Edge>>> DijsktraShortestRoute()
        {
            Dictionary<int, Tuple<double, Edge, List<Edge>>> LE = new Dictionary<int, Tuple<double, Edge, List<Edge>>>();

            List<Tuple<Edge, double>> S = new List<Tuple<Edge, double>>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] != null)
                    {
                        S.Add(new Tuple<Edge, double>(matrix[i,j], double.MaxValue));
                    }
                }
            }

            for (int i = 0; i < nodes; i++)
            {
                LE.Add(i, new Tuple<double, Edge, List<Edge>>(double.MaxValue, null, null));
            }
            
            Edge start = GetStartEdge();
            LE[start.Id] = new Tuple<double, Edge, List<Edge>>(0, null, new List<Edge>());
            S[start.Id] = new Tuple<Edge, double>(start, 0);
            
            while (S.Count != 0)
            {
                var u = GetMinValue(S);
                var allNeighbour = Neighbours(u);
                for (int i = 0; i < allNeighbour.Count; i++)
                {
                    Edge aktualNeighbour = allNeighbour[i];

                    int uId = SearchEdge(LE, u);
                    int aktualNeighbourId = SearchEdge(LE, aktualNeighbour);

                    if (LE[u.Id].Item1 + aktualNeighbour.Value < LE[aktualNeighbour.Id].Item1)
                    {
                        var list = LE[u.Id].Item3;
                        list.AddRange(list);
                        LE[u.Id] = new Tuple<double, Edge, List<Edge>>(LE[u.Id].Item1 + aktualNeighbour.Value, u, list);
                        for (int j = 0; j < S.Count; j++)
                        {
                            if (S[j].Item1 == aktualNeighbour)
                            {
                                S[j] = new Tuple<Edge, double>(aktualNeighbour, LE[u.Id].Item1 + aktualNeighbour.Value);
                            }
                        }
                    }
                }
                ;
            }

            return LE;
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

        private int SearchEdge(Dictionary<int, Tuple<double, Edge, List<Edge>>> LE, Edge e)
        {
            for (int i = 0; i < LE.Count; i++)
            {
                if (LE[i].Item2 == e)
                {
                    return i;
                }
            }
            return 0;
        }

        private Edge GetMinValue(List<Tuple<Edge, double>> S)
        {
            double min = S[0].Item2;
            Edge e = null;
            foreach (var queue in S)
            {
                if (queue.Item2 < min)
                {
                    e = queue.Item1;
                    //itt ki is lehet törölni
                }
            }
            for (int i = 0; i < S.Count; i++)
            {
                if (S[i].Item1 == e)
                {
                    S.Remove(S[i]);
                }
            }
            return e;
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

using ConcurrentTrainSimulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route
{
    public class Dijsktra_v2
    {
        public Dictionary<int, Tuple<double, Edge, List<Edge>>> DijsktraShortestRoute_V2(double[,] matrix)
        {
            Dictionary<int, Tuple<double, Edge, List<Edge>>> LE = new Dictionary<int, Tuple<double, Edge, List<Edge>>>();

            List<Tuple<Edge, double>> S = new List<Tuple<Edge, double>>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    //if (matrix[i, j] != null)
                    //{
                    //    S.Add(new Tuple<Edge, double>(matrix[i, j], double.MaxValue));
                    //}
                }
            }

            //for (int i = 0; i < nodes; i++)
            //{
            //    LE.Add(i, new Tuple<double, Edge, List<Edge>>(double.MaxValue, null, null));
            //}

            Edge start = GetStartEdge();
            LE[start.Id] = new Tuple<double, Edge, List<Edge>>(0, start, new List<Edge>());
            S[start.Id] = new Tuple<Edge, double>(start, 0);

            while (S.Count != 0)
            {
                var u = GetMinValue(S);
                var allNeighbour = Neighbours(u, matrix);
                for (int i = 0; i < allNeighbour.Count; i++)
                {
                    Edge aktualNeighbour = allNeighbour[i];

                    //int uId = SearchEdge(LE, u);
                    //UpdateLE(LE, aktualNeighbourId);
                    //int aktualNeighbourId = SearchEdge(LE, aktualNeighbour);

                    //UpdateLE(LE, uId);


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
                //List<Edge> allNeighbour = Neighbours(k);
                //for (int i = 0; i < allNeighbour.Count; i++)
                //{
                //    if (!(F.Contains(allNeighbour[i])))
                //    {
                //        S.Enqueue(allNeighbour[i]);
                //        F.Add(allNeighbour[i]);
                //    }
                //}
            }
        }

        private void UpdateLE(Dictionary<int, Tuple<double, Edge, List<Edge>>> LE, int e)
        {
            int counter = 0;
            foreach (var item in LE)
            {
                if (item.Key == e)
                {
                    var Value = item.Value.Item1;
                    var Neighbours = item.Value.Item3;
                    LE[counter] = new Tuple<double, Edge, List<Edge>>(Value, LE[e].Item2, Neighbours);
                }
                counter++;
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
                    min = queue.Item2;
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


        private List<Edge> Neighbours(Edge e, double[,] matrix)
        {
            List<Edge> allNeighbour = new List<Edge>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                //if (matrix[e.Y, i] != e && matrix[e.Y, i] != null)
                //{
                //    Edge tmp = matrix[e.Y, i];
                //    allNeighbour.Add(tmp);
                //    //allNeighbour.Add(matrix[tmp.Y, tmp.X]);
                //}

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

            //for (int i = 0; i < matrix.GetLength(0); i++)
            //{
            //    if (matrix[rnd, i] != null)
            //        RandomEdge = matrix[rnd, i];
            //}
            return RandomEdge;
        }
    }
}

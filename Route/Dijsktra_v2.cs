//using ConcurrentTrainSimulation;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Route
//{
//    public class Dijsktra_v2
//    {
//        public Dictionary<int, Tuple<double, Station, List<Station>>> DijsktraShortestRoute_V2(double[,] matrix)
//        {
//            Dictionary<int, Tuple<double, Station, List<Station>>> LE = new Dictionary<int, Tuple<double, Station, List<Station>>>();

//            List<Tuple<Station, double>> S = new List<Tuple<Station, double>>();
//            for (int i = 0; i < matrix.GetLength(0); i++)
//            {
//                for (int j = 0; j < matrix.GetLength(1); j++)
//                {
//                    //if (matrix[i, j] != null)
//                    //{
//                    //    S.Add(new Tuple<Edge, double>(matrix[i, j], double.MaxValue));
//                    //}
//                }
//            }

//            //for (int i = 0; i < nodes; i++)
//            //{
//            //    LE.Add(i, new Tuple<double, Edge, List<Edge>>(double.MaxValue, null, null));
//            //}

//            Station start = GetStartEdge();
//            LE[start.Id] = new Tuple<double, Station, List<Station>>(0, start, new List<Station>());
//            S[start.Id] = new Tuple<Station, double>(start, 0);

//            while (S.Count != 0)
//            {
//                var u = GetMinValue(S);
//                var allNeighbour = Neighbours(u, matrix);
//                for (int i = 0; i < allNeighbour.Count; i++)
//                {
//                    Station aktualNeighbour = allNeighbour[i];

//                    //int uId = SearchEdge(LE, u);
//                    //UpdateLE(LE, aktualNeighbourId);
//                    //int aktualNeighbourId = SearchEdge(LE, aktualNeighbour);

//                    //UpdateLE(LE, uId);


//                    if (LE[u.Id].Item1 + aktualNeighbour.Value < LE[aktualNeighbour.Id].Item1)
//                    {
//                        var list = LE[u.Id].Item3;
//                        list.AddRange(list);
//                        LE[u.Id] = new Tuple<double, Station, List<Station>>(LE[u.Id].Item1 + aktualNeighbour.Value, u, list);
//                        for (int j = 0; j < S.Count; j++)
//                        {
//                            if (S[j].Item1 == aktualNeighbour)
//                            {
//                                S[j] = new Tuple<Station, double>(aktualNeighbour, LE[u.Id].Item1 + aktualNeighbour.Value);
//                            }
//                        }
//                    }
//                }
//            }

//            return LE;
//        }

//        public void VisitAllEdge()
//        {
//            Queue<Station> S = new Queue<Station>();
//            HashSet<Station> F = new HashSet<Station>();

//            Station start = GetStartEdge();
//            S.Enqueue(start);
//            F.Add(start);

//            while (S.Count != 0)
//            {
//                Station k = S.Dequeue();
//                Process(k);
//                //List<Edge> allNeighbour = Neighbours(k);
//                //for (int i = 0; i < allNeighbour.Count; i++)
//                //{
//                //    if (!(F.Contains(allNeighbour[i])))
//                //    {
//                //        S.Enqueue(allNeighbour[i]);
//                //        F.Add(allNeighbour[i]);
//                //    }
//                //}
//            }
//        }

//        private void UpdateLE(Dictionary<int, Tuple<double, Station, List<Station>>> LE, int e)
//        {
//            int counter = 0;
//            foreach (var item in LE)
//            {
//                if (item.Key == e)
//                {
//                    var Value = item.Value.Item1;
//                    var Neighbours = item.Value.Item3;
//                    LE[counter] = new Tuple<double, Station, List<Station>>(Value, LE[e].Item2, Neighbours);
//                }
//                counter++;
//            }
//        }

//        private int SearchEdge(Dictionary<int, Tuple<double, Station, List<Station>>> LE, Station e)
//        {
//            for (int i = 0; i < LE.Count; i++)
//            {
//                if (LE[i].Item2 == e)
//                {
//                    return i;
//                }
//            }
//            return 0;
//        }

//        private Station GetMinValue(List<Tuple<Station, double>> S)
//        {
//            double min = S[0].Item2;
//            Station e = null;
//            foreach (var queue in S)
//            {
//                if (queue.Item2 < min)
//                {
//                    e = queue.Item1;
//                    min = queue.Item2;
//                    //itt ki is lehet törölni
//                }
//            }
//            for (int i = 0; i < S.Count; i++)
//            {
//                if (S[i].Item1 == e)
//                {
//                    S.Remove(S[i]);
//                }
//            }
//            return e;
//        }


//        private List<Station> Neighbours(Station e, double[,] matrix)
//        {
//            List<Station> allNeighbour = new List<Station>();
//            for (int i = 0; i < matrix.GetLength(0); i++)
//            {
//                //if (matrix[e.Y, i] != e && matrix[e.Y, i] != null)
//                //{
//                //    Edge tmp = matrix[e.Y, i];
//                //    allNeighbour.Add(tmp);
//                //    //allNeighbour.Add(matrix[tmp.Y, tmp.X]);
//                //}

//            }

//            return allNeighbour;
//        }

//        private void Process(Station e)
//        {
//            e.Processed = true;
//        }

//        private Station GetStartEdge()
//        {
//            Station RandomEdge = null;
//            var rnd = new Random().Next(8);

//            //for (int i = 0; i < matrix.GetLength(0); i++)
//            //{
//            //    if (matrix[rnd, i] != null)
//            //        RandomEdge = matrix[rnd, i];
//            //}
//            return RandomEdge;
//        }
//    }
//}

using Route.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route
{
    public class Floyd_Warshall
    {
        public static List<Road> FloydWarshall(int[,] weights, int numVerticies)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            double[,] dist = new double[numVerticies, numVerticies];
            for (int i = 0; i < numVerticies; i++)
            {
                for (int j = 0; j < numVerticies; j++)
                {
                    dist[i, j] = double.PositiveInfinity;
                }
            }
            ;

            for (int i = 0; i < weights.GetLength(0); i++)
            {
                dist[weights[i, 0] - 1, weights[i, 1] - 1] = weights[i, 2];
            }
            ;

            int[,] next = new int[numVerticies, numVerticies];
            for (int i = 0; i < numVerticies; i++)
            {
                for (int j = 0; j < numVerticies; j++)
                {
                    if (i != j)
                    {
                        next[i, j] = j + 1;
                    }
                }
            }
            ;
            for (int k = 0; k < numVerticies; k++)
            {
                ;
                for (int i = 0; i < numVerticies; i++)
                {
                    for (int j = 0; j < numVerticies; j++)
                    {
                        if (dist[i, k] + dist[k, j] < dist[i, j])
                        {
                            dist[i, j] = dist[i, k] + dist[k, j];
                            next[i, j] = next[i, k];
                        }
                    }
                    ;
                }
                ;
            }
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            List<Road> tmp = GetResult(dist, next);
            return tmp;
        }

        private static List<Road> GetResult(double[,] dist, int[,] next)
        {
            List<Road> r = new List<Road>();
            for (int i = 0; i < next.GetLength(0); i++)
            {
                for (int j = 0; j < next.GetLength(1); j++)
                {
                    List<int> Path = new List<int>();
                    Road road = new Road();
                    if (i != j)
                    {
                        int u = i + 1;
                        int v = j + 1;

                        road.U = u;
                        road.V = v;
                        road.Dest = (int)dist[i, j];
                        Path.Add(u);
                        do
                        {
                            u = next[u - 1, v - 1];
                            Path.Add(u);
                        } while (u != v);
                        road.Path = Path;
                        r.Add(road);
                    }
                }
            }
            ;
            return r;
        }
    }
}
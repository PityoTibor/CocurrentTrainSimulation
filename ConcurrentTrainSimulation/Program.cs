    using ConcurrentTrainSimulation.Material;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    namespace ConcurrentTrainSimulation
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                //Source vertex
                int source = 0;
                int[][] adjacencyMatrix = new int[][]
                {
                    new int []{ 0,0,0,3,12 },
                    new int []{ 0,0,2,0,0 },
                    new int []{ 0,0,0,2,0 },
                    new int []{ 0,5,3,0,0 },
                    new int []{ 0,0,7,0,0 } 
                };

                int[][] adjacencyMatrix2 = new int[][]
                {
                    new int[] { 0, 1, 0, 2, 4, 0, 0 },
                    new int[] { 1, 0, 9, 2, 0, 0, 0 },
                    new int[] { 0, 9, 0, 5, 0, 1, 0 },
                    new int[] { 2, 2, 5, 0, 0, 3, 0 },
                    new int[] { 4, 0, 0, 0, 0, 0, 3 },
                    new int[] { 0, 0, 1, 3, 0, 0, 0 },
                    new int[] { 0, 0, 0, 0, 0, 3, 2 },
                    new int[] { 0, 0, 0, 0, 3, 0, 0 },
                };


            int numberOfVertex = adjacencyMatrix2[0].Length;
            int[] distance = Enumerable.Repeat(int.MaxValue, numberOfVertex).ToArray();
            int[] parent = Enumerable.Repeat(-1, numberOfVertex).ToArray();
            distance[source] = 0;
            //calling dijkstra  algorithm
            //Dijkstra(adjacencyMatrix2, numberOfVertex, distance, parent);
            //printing distance
            //PrintPath(0, 2, distance, parent);
            Console.ReadLine();


            Stations graph = new Stations();
                graph.InitMatrix(8);
                graph.CreateStations();

                //graph.DijsktraShortestRoute();


                Train t = new Train();
                t.Init();
                new Task(() =>
                {
                    t.OnTheGo();

                }, TaskCreationOptions.LongRunning).Start();

                new Task(() =>
                {
                    for (int i = 0; i < 4; i++)
                    {
                        Thread.Sleep(10000);
                        lock (t)
                        {
                            Monitor.Pulse(t);
                        }
                    }
                
               
                }, TaskCreationOptions.LongRunning).Start();
            
                Console.ReadKey();
            }
        }
    }

    using ConcurrentTrainSimulation.Material;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    namespace ConcurrentTrainSimulation
    {
        public class PriorityQueue<T>
        {
            class Node
            {
                public int Priority { get; set; }
                public T Object { get; set; }
            }

            //object array
            List<Node> queue = new List<Node>();
            int heapSize = -1;
            bool _isMinPriorityQueue;
            public int Count { get { return queue.Count; } }

            /// <summary>
            /// If min queue or max queue
            /// </summary>
            /// <param name="isMinPriorityQueue"></param>
            public PriorityQueue(bool isMinPriorityQueue = false)
            {
                _isMinPriorityQueue = isMinPriorityQueue;
            }


            /// <summary>
            /// Updating the priority of specific object
            /// </summary>
            /// <param name="obj"></param>
            /// <param name="priority"></param>
            public void UpdatePriority(T obj, int priority)
            {
                int i = 0;
                for (; i <= heapSize; i++)
                {
                    Node node = queue[i];
                    if (object.ReferenceEquals(node.Object, obj))
                    {
                        node.Priority = priority;
                        if (_isMinPriorityQueue)
                        {
                            BuildHeapMin(i);
                            MinHeapify(i);
                        }
                        else
                        {
                            BuildHeapMax(i);
                            MaxHeapify(i);
                        }
                    }
                }
            }
            /// <summary>
            /// Searching an object
            /// </summary>
            /// <param name="obj"></param>
            /// <returns></returns>
            public bool IsInQueue(T obj)
            {
                foreach (Node node in queue)
                    if (object.ReferenceEquals(node.Object, obj))
                        return true;
                return false;
            }

            /// <summary>
            /// Enqueue the object with priority
            /// </summary>
            /// <param name="priority"></param>
            /// <param name="obj"></param>
            public void Enqueue(int priority, T obj)
            {
                Node node = new Node() { Priority = priority, Object = obj };
                queue.Add(node);
                heapSize++;
                //Maintaining heap
                if (_isMinPriorityQueue)
                    BuildHeapMin(heapSize);
                else
                    BuildHeapMax(heapSize);
            }

            /// <summary>
            /// Dequeue the object
            /// </summary>
            /// <returns></returns>
            public T Dequeue()
            {
                if (heapSize > -1)
                {
                    var returnVal = queue[0].Object;
                    queue[0] = queue[heapSize];
                    queue.RemoveAt(heapSize);
                    heapSize--;
                    //Maintaining lowest or highest at root based on min or max queue
                    if (_isMinPriorityQueue)
                        MinHeapify(0);
                    else
                        MaxHeapify(0);
                    return returnVal;
                }
                else
                    throw new Exception("Queue is empty");
            }


            /// <summary>
            /// Maintain max heap
            /// </summary>
            /// <param name="i"></param>
            private void BuildHeapMax(int i)
            {
                while (i >= 0 && queue[(i - 1) / 2].Priority < queue[i].Priority)
                {
                    Swap(i, (i - 1) / 2);
                    i = (i - 1) / 2;
                }
            }
            /// <summary>
            /// Maintain min heap
            /// </summary>
            /// <param name="i"></param>
            private void BuildHeapMin(int i)
            {
                while (i >= 0 && queue[(i - 1) / 2].Priority > queue[i].Priority)
                {
                    Swap(i, (i - 1) / 2);
                    i = (i - 1) / 2;
                }
            }

            private void MaxHeapify(int i)
            {
                int left = ChildL(i);
                int right = ChildR(i);

                int heighst = i;

                if (left <= heapSize && queue[heighst].Priority < queue[left].Priority)
                    heighst = left;
                if (right <= heapSize && queue[heighst].Priority < queue[right].Priority)
                    heighst = right;

                if (heighst != i)
                {
                    Swap(heighst, i);
                    MaxHeapify(heighst);
                }
            }
            private void MinHeapify(int i)
            {
                int left = ChildL(i);
                int right = ChildR(i);

                int lowest = i;

                if (left <= heapSize && queue[lowest].Priority > queue[left].Priority)
                    lowest = left;
                if (right <= heapSize && queue[lowest].Priority > queue[right].Priority)
                    lowest = right;

                if (lowest != i)
                {
                    Swap(lowest, i);
                    MinHeapify(lowest);
                }
            }

            private void Swap(int i, int j)
            {
                var temp = queue[i];
                queue[i] = queue[j];
                queue[j] = temp;
            }
            private int ChildL(int i)
            {
                return i * 2 + 1;
            }
            private int ChildR(int i)
            {
                return i * 2 + 2;
            }
        }

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
            Dijkstra(adjacencyMatrix2, numberOfVertex, distance, parent);
            //printing distance
            PrintPath(0, 2, distance, parent);
            Console.ReadLine();


            Stations graph = new Stations();
                graph.InitMatrix(8);
                graph.CreateStations();

                graph.DijsktraShortestRoute();


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

            static void Relax(int u, int v, int weight, int[] distance, int[] parent)
            {
                if (distance[u] != int.MaxValue && distance[v] > distance[u] + weight)
                {
                    distance[v] = distance[u] + weight;
                    parent[v] = u;
                }
            }

            public static void Dijkstra(int[][] adjacencyMatrix, int numberOfVertex, int[] distance, int[] parent)
            {
                PriorityQueue<int> vertexQueue = new PriorityQueue<int>(true);
                //adding all vertex to priority queue
                for (int i = 0; i < numberOfVertex; i++)
                    vertexQueue.Enqueue(distance[i], i); // priority = distance, object = vertex

                //treversing to all vertices
                while (vertexQueue.Count > 0)
                {
                    var u = vertexQueue.Dequeue(); // vertax with least distance
                                                   //Traversing to all connecting edges
                    for (int v = 0; v < adjacencyMatrix[u].Length; v++)
                    {
                        if (adjacencyMatrix[u][v] > 0)
                        {
                            Relax(u, v, adjacencyMatrix[u][v], distance, parent);
                            //updating priority value since distance is changed
                            vertexQueue.UpdatePriority(v, distance[v]);
                        }
                    }
                }
                ;
            }

            public static void PrintPath(int u, int v, int[] distance, int[] parent)
            {
                if (v < 0 || u < 0)
                {
                    return;
                }
                if (v != u)
                {
                    PrintPath(u, parent[v], distance, parent);
                    Console.WriteLine("Vertax {0} weight: {1}", v, distance[v]);
                }
                else
                    Console.WriteLine("Vertax {0} weight: {1}", v, distance[v]);
            }
        }
    }

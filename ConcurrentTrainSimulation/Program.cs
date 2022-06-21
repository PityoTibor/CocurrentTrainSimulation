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
                TrafficManager manager = new TrafficManager();
                manager.GetAllShortestPath();
                var a = manager.Map_FloydWarshall;
    
                Train t = new Train(manager.Map_FloydWarshall);
                t.Init();
                t.OnTheGo();

            ;
                Train t2 = new Train(manager.Map_FloydWarshall);
                t2.Init();
                t2.OnTheGo();

            Console.ReadKey();
            }
        }
    }

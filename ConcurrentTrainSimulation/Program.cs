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
                Train t = new Train();
                t.Init();
                TrafficManager m = new TrafficManager();
                m.FillMap();
                Console.ReadKey();
            }
        }
    }

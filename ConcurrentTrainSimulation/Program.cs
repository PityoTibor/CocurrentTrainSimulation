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
            ;

                
                var trains = Enumerable.Range(0, 2).Select(x => new Train(manager.Map_FloydWarshall)).ToList();
                trains.ForEach(x => x.Init());

                foreach (var item in trains)
                {
                    foreach (var i in item.Timetable)
                    {
                        Console.WriteLine(i.Item1 + " " + i.Item2);
                    }
                }

            ;
                trains.Select(x => new Task(() => x.OnTheGo(), TaskCreationOptions.LongRunning)).ToList()
                .ForEach(x => x.Start());
           
                Console.ReadLine();
            }
        }
    }

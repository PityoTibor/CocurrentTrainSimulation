using ConcurrentTrainSimulation.Material;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrentTrainSimulation
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Stations graph = new Stations();
            graph.InitMatrix(8);
            graph.CreateStations();

            graph.VisitAllEdge();


            Queue<double> asd;

            ;

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

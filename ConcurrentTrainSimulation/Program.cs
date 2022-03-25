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

            Station graph = new Station();
            graph.InitMatrix(8);
            graph.ElFelvetel(0, 1);
            graph.ElFelvetel(0, 4);

            graph.ElFelvetel(1, 0);
            graph.ElFelvetel(1, 2);
            graph.ElFelvetel(1, 3);

            graph.ElFelvetel(2, 1);
            graph.ElFelvetel(2, 3);
            graph.ElFelvetel(2, 7);

            graph.ElFelvetel(3, 1);
            graph.ElFelvetel(3, 2);

            graph.ElFelvetel(4, 0);
            graph.ElFelvetel(4, 5);
            graph.ElFelvetel(4, 6);

            graph.ElFelvetel(5, 4);
            graph.ElFelvetel(5, 6);

            graph.ElFelvetel(6, 4);
            graph.ElFelvetel(6, 5);
            graph.ElFelvetel(6, 7);

            graph.ElFelvetel(7, 2);
            graph.ElFelvetel(7, 6);

            graph.ElFelvetel(7, 1   );


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

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

            graph.ElFelvetel(0, 1, 1.0);
            graph.ElFelvetel(0, 3, 2.0);
            graph.ElFelvetel(0, 4, 4.0);

            graph.ElFelvetel(1, 0, 1.0);
            graph.ElFelvetel(1, 2, 9.0);
            graph.ElFelvetel(1, 3, 2.0);
            
            graph.ElFelvetel(2, 1, 9.0);
            graph.ElFelvetel(2, 3, 5.0);
            graph.ElFelvetel(2, 5, 5.0);
            
            graph.ElFelvetel(3, 0, 2.0);
            graph.ElFelvetel(3, 1, 2.0);
            graph.ElFelvetel(3, 5, 3.0);
            graph.ElFelvetel(3, 2, 5.0);
            
            graph.ElFelvetel(4, 0, 4.0);
            graph.ElFelvetel(4, 7, 3.0);
            
            graph.ElFelvetel(5, 2, 1.0);
            graph.ElFelvetel(5, 3, 3.0);
            graph.ElFelvetel(5, 6, 3.0);

            graph.ElFelvetel(6, 5, 3.0);
            graph.ElFelvetel(6, 7, 2.0);

            graph.ElFelvetel(7, 4, 3.0);
            graph.ElFelvetel(7, 6, 2.0);

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

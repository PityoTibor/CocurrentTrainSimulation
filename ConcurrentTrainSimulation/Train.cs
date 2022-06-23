using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Route;
using Route.Utils;
using static ConcurrentTrainSimulation.TrafficManager;

namespace ConcurrentTrainSimulation
{
    public enum Phases { Init, P, Start, OnTheRoad, packed, OnPurpose, End }
    public class Train
    {
        static Random rnd = new Random();
        static int TrainId = 0;
        object lockobj = new object();

        List<ConcurrentStack<Fitting>> fittings;
        public List<Tuple<int, int>> Timetable;
        ShortestLineMapFloyd_Warshal FloydWarshall;


        public Phases Phase { get; set; }
        public Road Road { get; set; }
        public string Id { get; set; } = "#" + ++TrainId;
        public Train(ShortestLineMapFloyd_Warshal FloydWarshall)
        {
            fittings = new List<ConcurrentStack<Fitting>>();
            Timetable = new List<Tuple<int, int>>();
            this.FloydWarshall = FloydWarshall;
        }

        public void Init()
        {
            AddFitting();
            FillTimetable();
            Phase = Phases.Init;
        }

        public void OnTheGo(List<Packer> packers)
        {
            for (int i = 0; i < Timetable.Count; i++)
            {
                Phase = Phases.P;
                Road r = FloydWarshall.roads.Select(x => x).Where(x => x.U == Timetable[i].Item1 && x.V == Timetable[i].Item2).FirstOrDefault();
                
                Console.WriteLine(r.U_IsBusy ? "" : "" );
               
                while (r.U_IsBusy)
                    Thread.Sleep(10);
                
                lock (r.LockObj)
                {
                    r.U_IsBusy = true;
                    Phase = Phases.Start;
                    Console.WriteLine($"A {Id} vanat éppen a {r.U} állomásról indul!");
                    Thread.Sleep(10);
                    r.U_IsBusy = false;
                }

                foreach (Paths p in r.Path)
                {
                    lock (p.LockObj)
                    {
                        Console.WriteLine($"A {Id} vanat éppen a {p.Path} állomáson van");
                        p.IsBusy = true;

                        IEnumerable<Packer> FreePackers;
                        
                        lock (Packer.PackerLock)
                        {
                            FreePackers = packers.Where(x => x.Status != Packer.PackerStatus.Work);
                            if (FreePackers.Count() > 0)
                            {
                                foreach (Packer packer in FreePackers)
                                {
                                    packer.Status = Packer.PackerStatus.Work;
                                }
                            }
                        }

                        foreach (var fitting in fittings)
                        {
                            foreach (var item in fitting)
                            {
                                item.IsFilled = true;
                            }
                        }

                        //fittings.ForEach((x) => {
                        //x.ToList().ForEach(y => {
                        //    Console.WriteLine(y.W);
                        //});

                        while (fittings.ForEach((x) => x.ToList().ForEach(y => y.IsFilled)))
                        { 
                            
                        }

                        p.IsBusy = false;
                    }
                }

                while (r.V_IsBusy)
                    Thread.Sleep(10);

                lock (r.LockObj)
                {
                    r.V_IsBusy = true;
                    Phase = Phases.Start;
                    Console.WriteLine($"A {Id} vanat éppen a {r.V} végállomásra ért");
                    Thread.Sleep(10);
                    r.V_IsBusy = false;
                }
                Thread.Sleep(20);
            }
        }

        public override string ToString()
        {
            return $"{Phase}";
        }

        private void AddFitting()
        {


            fittings.AddRange(Enumerable.Range(1, 4).Select(x => new ConcurrentStack<Fitting>())); ;
        }

        private void FillTimetable()
        {

            Timetable.Add(new Tuple<int, int>(1, 8));
            Timetable.Add(new Tuple<int, int>(1, 7));
            //Timetable.AddRange(Enumerable.Range(1, 3).Select(x => new Tuple<int, int>(rnd.Next(1, 9), rnd.Next(1, 9))));
        }

    }

    public class Fitting
    {
        public int W { get; set; } = WArray[rnd.Next(0, 4)];
        
        private static Random rnd = new Random();
        private static int[] WArray = new int[] { 50, 80, 100 };
        public bool IsFilled { get; set; }
    }
}

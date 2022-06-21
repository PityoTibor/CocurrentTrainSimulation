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
    public enum Phases {Init, P, Start, OnTheRoad, OnPurpose, End }
    public class Train
    {
        static Random rnd = new Random();
        static int TrainId = 0;
        object lockobj = new object();

        List<ConcurrentStack<int>> fittings;
        List<Tuple<int, int>> Timetable;
        ShortestLineMapFloyd_Warshal FloydWarshall;


        public Phases Phase { get; set; }
        public Road Road { get; set; }
        public string Id { get; set; } = "# " + ++TrainId;
        public Train(ShortestLineMapFloyd_Warshal FloydWarshall)
        {
            fittings = new List<ConcurrentStack<int>>();
            Timetable = new List<Tuple<int, int>>();
            this.FloydWarshall = FloydWarshall;
        }

        public void Init()
        {
            AddFitting();
            FillTimetable();
            Phase = Phases.Init;
        }

        public void OnTheGo()
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
                }
                ;


            }
        }

        private void AddFitting()
        {
            fittings.AddRange(Enumerable.Range(1, 4).Select(x => new ConcurrentStack<int>()));
        }

        private void FillTimetable()
        {

            Timetable.AddRange(Enumerable.Range(1, 3).Select(x => new Tuple<int, int>(rnd.Next(1, 9), rnd.Next(1, 9))));
        }
    }
}

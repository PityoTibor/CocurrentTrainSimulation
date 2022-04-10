using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Route;


namespace ConcurrentTrainSimulation
{
    public enum Phases {Init, Start, OnTheRoad, End }
    public class Train
    {
        object lockobj = new object();
        List<ConcurrentStack<int>> fittings;
        public List<string> Citys = new List<string>()
        {
            "Abby", "Bobby", "Colly", "DownTown"
        };

        public Phases Phase { get; set; }

        public Train()
        {
            fittings = new List<ConcurrentStack<int>>();
        }

        public void Init()
        {
            AddFitting();
            Phase = Phases.Init;
        }

        public void OnTheGo()
        {
            
        }

        private void AddFitting()
        {
            fittings.AddRange(Enumerable.Range(1, 4).Select(x => new ConcurrentStack<int>()));
        }
    }
}

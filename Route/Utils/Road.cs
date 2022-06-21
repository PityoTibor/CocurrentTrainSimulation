using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.Utils
{
    public class Road
    {
        public int U { get; set; }
        public int V { get; set; }
        public int Dest { get; set; }
        public List<int> Path { get; set; }
        public object LockObj { get; set; }
        public bool U_IsBusy { get; set; }
        public bool V_IsBusy { get; set; }

        public Road()
        {
            LockObj = new object();
        }
    }


    class Paths
    {
        public int Path { get; set; }
    }
}

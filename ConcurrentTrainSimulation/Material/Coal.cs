using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentTrainSimulation.Material
{
    class Coal : RawMaterial
    {
        static Random rnd = new Random();
        public int Value { get; private set; }
        public Coal()
        {
            Value = rnd.Next(1, 6);
        }
    }
}

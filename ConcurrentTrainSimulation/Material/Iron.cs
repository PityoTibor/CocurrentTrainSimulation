using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentTrainSimulation.Material
{
    class Iron : RawMaterial
    {
        static Random rnd = new Random();
        public int Value { get; private set; }
        public Iron()
        {
            Value = rnd.Next(5, 16);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentTrainSimulation.Material
{
    class Gold : RawMaterial
    {
        static Random rnd = new Random();
        public int Value { get; private set; }
        public Gold()
        {
            Value = rnd.Next(20, 46);
        }

        
    }
}

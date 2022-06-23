using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentTrainSimulation.Material
{
    class Coal : RawMaterial
    {
        public int Value { get; private set; } = 60;
    }
}

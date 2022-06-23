using Route.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentTrainSimulation
{
    public class Packer
    {
        public static object PackerLock { get; set; } = new object();
        public enum PackerStatus { Rest, Work }
        private static Random rnd = new Random();

        public int Speed { get; set; } = rnd.Next(2, 5);
        public PackerStatus Status { get; set; } = PackerStatus.Rest;
        public Knapsack WorkMethod { get; set; }
    }
}


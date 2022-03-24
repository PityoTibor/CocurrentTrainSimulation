using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentTrainSimulation
{
    public class Station
    {
		int indexer = 0;
		public int[,] matrix;
		public void InitMatrix(int num)
		{
			matrix = new int[num, num];
		}

		public void ElFelvetel(int honnan, int hova)
		{
			matrix[honnan, hova] = 1;
		}
	}
}

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
		public double[,] matrix;
		public void InitMatrix(int num)
		{
			matrix = new double[num, num];
		}

		public void ElFelvetel(int honnan, int hova, double weight)
		{
			matrix[honnan, hova] = weight;
		}
	}
}

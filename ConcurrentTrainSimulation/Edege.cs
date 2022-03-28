using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentTrainSimulation
{
    public class Stations
    {
		int indexer = 0;
		public double[,] matrix;
		public void InitMatrix(int num)
		{
			matrix = new double[num, num];
		}

		public void CreateStations()
		{
            AddEdges(new Edege(1, 0, 1, 1.0));
            AddEdges(new Edege(2, 0, 3, 2.0));
            AddEdges(new Edege(3, 0, 4, 4.0));

            AddEdges(new Edege(4, 1, 0, 1.0));
            AddEdges(new Edege(5, 1, 2, 9.0));
            AddEdges(new Edege(6, 1, 3, 2.0));

            AddEdges(new Edege(7, 2, 1, 9.0));
            AddEdges(new Edege(8, 2, 3, 5.0));
            AddEdges(new Edege(9, 2, 5, 5.0));

            AddEdges(new Edege(10, 3, 0, 2.0));
            AddEdges(new Edege(11, 3, 5, 3.0));
            AddEdges(new Edege(12, 3, 2, 5.0));

            AddEdges(new Edege(13, 4, 0, 4.0));
            AddEdges(new Edege(14, 4, 7, 3.0));

            AddEdges(new Edege(15, 5, 2, 1.0));
            AddEdges(new Edege(16, 5, 3, 3.0));
            AddEdges(new Edege(17, 5, 6, 3.0));

            AddEdges(new Edege(18, 6, 5, 3.0));
            AddEdges(new Edege(19, 6, 7, 2.0));

            AddEdges(new Edege(20, 7, 4, 3.0));
            AddEdges(new Edege(21, 7, 6, 2.0));
        }

        void VisitAllEdge()
        {
            var rnd =  new Random().Next(9);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {

            }
        }

        private void GetRandomPoint()
        { 
                       
        }

        private void AddEdges( Edege station /*int honnan, int hova, double weight*/)
        {
            matrix[station.X, station.Y] = station.Value;
        }
    }

    class Edege
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public double Value { get; set; }

        public int MyProperty { get; set; }
        public Edege(int id, int x, int y, double value)
        {
            Id = id;
            X = x;
            Y = y;
            Value = value;
        }
    }
}

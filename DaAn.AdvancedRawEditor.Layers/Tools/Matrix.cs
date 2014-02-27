using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.Tools
{
    public class Matrix
    {
        private double[][] _Matrix;

        public Matrix(int x, int y)
        {
            this._Matrix = new double[x][];

            for (int i = 0; i < x; i++)
            {
                this._Matrix[i] = new double[y];
            }
        }

        public double Get(int x, int y)
        {
            return this._Matrix[x][y];
        }

        public void Set(int x, int y, double value)
        {
            this._Matrix[x][y] = value;
        }

        public static Matrix Ones(int size)
        {
            var matrix = new Matrix(size, size);

            for (int i = 0; i < size; i++)
            {
                matrix.Set(i, i, 1.0);
            }

            return matrix;
        }
    }
}

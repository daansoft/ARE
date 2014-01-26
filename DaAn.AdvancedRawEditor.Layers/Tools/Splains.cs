using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.Tools
{
    public class SplineInterpolation
    {
        private double[] ks;
        private double[][] A;
        private double[] Xs;
        private double[] Ys;

        public SplineInterpolation(double[] xs, double[] ys)
        {
            this.Xs = xs;
            this.Ys = ys;
        }

        public double EvalSpline(double x)
        {
            var i = 1;

            while (this.Xs[i] < x) i++;

            var t = (x - this.Xs[i - 1]) / (this.Xs[i] - this.Xs[i - 1]);

            var a = ks[i - 1] * (this.Xs[i] - this.Xs[i - 1]) - (this.Ys[i] - this.Ys[i - 1]);
            var b = -ks[i] * (this.Xs[i] - this.Xs[i - 1]) + (this.Ys[i] - this.Ys[i - 1]);

            var q = (1 - t) * this.Ys[i - 1] + t * this.Ys[i] + t * (1 - t) * (a * (1 - t) + b * t);
            return q;
        }

        public void GenerateData()
        {
            this.GenerateNeutralKs(this.Xs, this.Ys);
            this.Solve();
        }

        private void GenerateNeutralKs(double[] xs, double[] ys)	// in x values, in y values, out k values
        {
            var n = xs.Length - 1;
            CreateZeroMatrix(n + 1, n + 2);

            for (var i = 1; i < n; i++)	// rows
            {
                this.A[i][i - 1] = 1 / (xs[i] - xs[i - 1]);

                this.A[i][i] = 2 * (1 / (xs[i] - xs[i - 1]) + 1 / (xs[i + 1] - xs[i]));

                this.A[i][i + 1] = 1 / (xs[i + 1] - xs[i]);

                this.A[i][n + 1] = 3 * ((ys[i] - ys[i - 1]) / ((xs[i] - xs[i - 1]) * (xs[i] - xs[i - 1])) + (ys[i + 1] - ys[i]) / ((xs[i + 1] - xs[i]) * (xs[i + 1] - xs[i])));
            }

            this.A[0][0] = 2 / (xs[1] - xs[0]);
            this.A[0][1] = 1 / (xs[1] - xs[0]);
            this.A[0][n + 1] = 3 * (ys[1] - ys[0]) / ((xs[1] - xs[0]) * (xs[1] - xs[0]));

            this.A[n][n - 1] = 1 / (xs[n] - xs[n - 1]);
            this.A[n][n] = 2 / (xs[n] - xs[n - 1]);
            this.A[n][n + 1] = 3 * (ys[n] - ys[n - 1]) / ((xs[n] - xs[n - 1]) * (xs[n] - xs[n - 1]));
        }

        private void Solve()	// in Matrix, out solutions
        {
            var m = this.A.Length;

            ks = new double[m];

            for (var k = 0; k < m; k++)	// column
            {
                // pivot for column
                var i_max = 0; var vali = double.MinValue;
                for (var i = k; i < m; i++)
                    if (this.A[i][k] > vali)
                    {
                        i_max = i;
                        vali = this.A[i][k];
                    }

                SwapRows(k, i_max);

                //if(this.A[i_max][i] == 0) console.log("matrix is singular!");

                // for all rows below pivot
                for (var i = k + 1; i < m; i++)
                {
                    for (var j = k + 1; j < m + 1; j++)
                        this.A[i][j] = this.A[i][j] - this.A[k][j] * (this.A[i][k] / this.A[k][k]);
                    this.A[i][k] = 0;
                }
            }

            for (var i = m - 1; i >= 0; i--)	// rows = columns
            {
                var v = this.A[i][m] / this.A[i][i];
                ks[i] = v;
                for (var j = i - 1; j >= 0; j--)	// rows
                {
                    this.A[j][m] -= this.A[j][i] * v;
                    this.A[j][i] = 0;
                }
            }
        }

        public void CreateZeroMatrix(int r, int c)
        {
            this.A = new double[r][];

            for (var i = 0; i < r; i++)
            {
                this.A[i] = new double[c];
                for (var j = 0; j < c; j++)
                {
                    this.A[i][j] = 0;
                }
            };
        }

        private void SwapRows(int k, int l)
        {
            var p = this.A[k];
            this.A[k] = this.A[l];
            this.A[l] = p;
        }
    }
}

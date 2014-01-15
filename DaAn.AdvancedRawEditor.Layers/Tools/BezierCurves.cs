using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.Tools
{
    public class BezierCurves
    {
        private List<BezierCurvePoint> points;

        public BezierCurves()
        {
            this.points = new List<BezierCurvePoint>();

            this.InitializePoints();
        }

        public BezierCurvePoint First
        {
            get
            {
                return this.points[0];
            }
        }
        public BezierCurvePoint Last
        {
            get
            {
                return this.points[this.points.Count - 1];
            }
        }

        private void InitializePoints()
        {
            this.Add(BezierCurvePoint.CreateFull(Point.Zero, Point.CreateFromOneValue(-0.2), Point.CreateFromOneValue(0.2), 1.0, 1.0));
            this.Add(BezierCurvePoint.CreateFull(Point.One, Point.CreateFromOneValue(0.8), Point.CreateFromOneValue(1.2), 1.0, 1.0));
        }

        public void Add(BezierCurvePoint point)
        {
            this.points.Add(point);

            this.OrderPoints();
        }

        public void RemoveAt(int index)
        {
            if (this.CanRemove(index))
            {
                this.points.RemoveAt(index);
            }
        }

        public double Calculate(double x)
        {
            if (x <= this.First.P.X)
            {
                return this.First.P.Y;
            }

            if (x >= this.Last.P.X)
            {
                return this.Last.P.Y;
            }


            BezierCurvePoint firstPoint = this.First;
            BezierCurvePoint secondPoint = this.Last;

            for (int i = 0; i < this.points.Count - 1; i++)
            {
                if (x >= this.points[i].P.X && x <= this.points[i + 1].P.X)
                {
                    firstPoint = this.points[i];
                    secondPoint = this.points[i + 1];
                    break;
                }
            }

            return this.CalculateForPoints(firstPoint, secondPoint, x);
        }

        private double CalculateForPoints(BezierCurvePoint firstPoint, BezierCurvePoint secondPoint, double x)
        {
            double t = (x - firstPoint.P.X) / (secondPoint.P.X - firstPoint.P.X);

            return ((1 - t) * (1 - t) * (1 - t) * firstPoint.P.Y) +
                (3 * (1 - t) * (1 - t) * t * firstPoint.PP.Y) +
                (3 * (1 - t) * t * t * secondPoint.PL.Y) +
                (t * t * t * secondPoint.P.Y);

            //return (firstPoint.P.Y + t * (-firstPoint.P.Y * 3 + t * (3 * firstPoint.P.Y - firstPoint.P.Y * t))) + t * (3 * firstPoint.PP.Y + t * (-6 * firstPoint.PP.Y + firstPoint.PP.Y * 3 * t)) + t * t * (secondPoint.PL.Y * 3 - secondPoint.PL.Y * 3 * t) + secondPoint.P.Y * t * t * t;
        }

        private bool CanRemove(int index)
        {
            return this.points.Count > 2 && index < this.points.Count;
        }

        private void OrderPoints()
        {
            this.points = this.points.OrderBy(r => r.P.X).ToList();
        }
    }
}

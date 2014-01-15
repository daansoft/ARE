using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.Tools
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public static Point Zero
        {
            get
            {
                return new Point(0, 0);
            }
        }

        public static Point One
        {
            get
            {
                return new Point(1.0, 1.0);
            }
        }

        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public static Point Create(double x, double y)
        {
            return new Point(x, y);
        }

        public static Point CreateFromOneValue(double xy)
        {
            return new Point(xy, xy);
        }
    }
}

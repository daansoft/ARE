using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public class PixelValue
    {
        public static readonly double Min = 0.0;
        public static readonly double Max = 255.0;

        public static PixelValue Black
        {
            get
            {
                return new PixelValue(Min, Min, Min);
            }
        }

        public static PixelValue White
        {
            get
            {
                return new PixelValue(Max, Max, Max);
            }
        }

        public double R { get; set; }
        public double G { get; set; }
        public double B { get; set; }

        public PixelValue(double r, double g, double b)
        {
            this.R = r > Max ? Max : (r < Min ? Min : r);
            this.G = g > Max ? Max : (g < Min ? Min : g);
            this.B = b > Max ? Max : (b < Min ? Min : b);
        }

        public PixelValue Clone()
        {
            return new PixelValue(this.R, this.G, this.B);
        }

        public static implicit operator PixelValue(double v)  // explicit byte to digit conversion operator
        {
            return new PixelValue(v, v, v);
        }

        public static PixelValue operator *(PixelValue lhs, PixelValue rhs)
        {
            return new PixelValue(lhs.R * rhs.R, lhs.G * rhs.G, lhs.B * rhs.B);
        }

        public static PixelValue operator +(PixelValue lhs, PixelValue rhs)
        {
            return new PixelValue(lhs.R + rhs.R, lhs.G + rhs.G, lhs.B + rhs.B);
        }
    }
}

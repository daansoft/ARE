using System;
using System.Collections.Generic;
using System.Drawing;
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
            this.R = r;
            this.G = g;
            this.B = b;
        }

        public PixelValue Clone()
        {
            return new PixelValue(this.R, this.G, this.B);
        }

        public void Clip()
        {
            this.R = PixelValue.Cilp(this.R);
            this.G = PixelValue.Cilp(this.G);
            this.B = PixelValue.Cilp(this.B);
        }

        private static double Cilp(double value)
        {
            return value > PixelValue.Max ? PixelValue.Max : value < PixelValue.Min ? PixelValue.Min : value;
        }

        public static implicit operator PixelValue(double v)  // explicit byte to digit conversion operator
        {
            return new PixelValue(v, v, v);
        }

        public static implicit operator PixelValue(Color v)  // explicit byte to digit conversion operator
        {
            return new PixelValue(v.R, v.G, v.B);
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

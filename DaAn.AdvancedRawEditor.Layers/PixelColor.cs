using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public class PixelColor
    {
        public static readonly double Min = 0.0;
        public static readonly double Max = 1.0;

        public static long Count = 0;

        public static PixelColor Black
        {
            get
            {
                return PixelColor.FromNormalizedRGB(Min, Min, Min);
            }
        }

        public static PixelColor White
        {
            get
            {
                return PixelColor.FromNormalizedRGB(Max, Max, Max);
            }
        }

        public double R { get; set; }
        public double G { get; set; }
        public double B { get; set; }

        public PixelColor()
        {
            PixelColor.Count++;
        }

        public void Clip()
        {
            this.R = PixelColor.Cilp(this.R);
            this.G = PixelColor.Cilp(this.G);
            this.B = PixelColor.Cilp(this.B);
        }

        private static double Cilp(double value)
        {
            return value > PixelColor.Max ? PixelColor.Max : value < PixelColor.Min ? PixelColor.Min : value;
        }

        public static implicit operator PixelColor(Color v)  // explicit byte to digit conversion operator
        {
            return PixelColor.FromRGB(v.R, v.G, v.B);
        }

        public static PixelColor FromRGB(double r, double g, double b)
        {
            return new PixelColor() { R = r / 255.0, G = g / 255.0, B = b / 255.0 };
        }

        public static PixelColor FromNormalizedRGB(double rn, double gn, double bn)
        {
            return new PixelColor() { R = rn, G = gn, B = bn };
        }

        public static PixelColor FromNormalizedV(double vn)
        {
            return PixelColor.FromNormalizedRGB(vn, vn, vn);
        }
    }
}

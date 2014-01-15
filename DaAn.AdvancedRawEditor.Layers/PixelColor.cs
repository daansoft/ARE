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

        public double RN { get; set; }
        public double GN { get; set; }
        public double BN { get; set; }

        public double R
        {
            get
            {
                return this.RN * 255.0;
            }

            set
            {
                this.RN = value / 255.0;
            }
        }

        public double G
        {
            get
            {
                return this.GN * 255.0;
            }

            set
            {
                this.GN = value / 255.0;
            }
        }

        public double B
        {
            get
            {
                return this.BN * 255.0;
            }

            set
            {
                this.BN = value / 255.0;
            }
        }

        public PixelColor()
        {
            PixelColor.Count++;
        }

        public void Clip()
        {
            this.RN = PixelColor.Cilp(this.RN);
            this.GN = PixelColor.Cilp(this.GN);
            this.BN = PixelColor.Cilp(this.BN);
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
            return new PixelColor() { R = r, G = g, B = b };
        }

        public static PixelColor FromNormalizedRGB(double rn, double gn, double bn)
        {
            return new PixelColor() { RN = rn, GN = gn, BN = bn };
        }

        public static PixelColor FromNormalizedV(double vn)
        {
            return PixelColor.FromNormalizedRGB(vn, vn, vn);
        }
    }
}

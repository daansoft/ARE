using DaAn.AdvancedRawEditor.Layers.MVP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.EffectLayers
{
    public class HSLLayer : Layer
    {
        private double _RFactor;
        private double _GFactor;
        private double _BFactor;

        public HSLLayer(Guid identificator, double rFactor, double gFactor, double bFactor)
            : base(identificator, 1)
        {
            this.RFactor = rFactor;
            this.GFactor = gFactor;
            this.BFactor = bFactor;

            var hsl = RGB2HSLMM(2, 1, -1);

            var rgb = HSLMM2RGB(hsl[0], hsl[1], hsl[2], hsl[3], hsl[4]);

            rgb = rgb;

        }

        public HSLLayer(Guid identificator)
            : this(identificator, 0.0, 0.0, 0.0)
        {
        }

        public double RFactor
        {
            get
            {
                return this._RFactor;
            }

            set
            {
                this._RFactor = value;
                this.OnChange();
            }
        }

        public double GFactor
        {
            get
            {
                return this._GFactor;
            }

            set
            {
                this._GFactor = value;
                this.OnChange();
            }
        }



        public double BFactor
        {
            get
            {
                return this._BFactor;
            }

            set
            {
                this._BFactor = value;
                this.OnChange();
            }
        }

        public override PixelColor GetPixelColor(int x, int y)
        {
            try
            {
                var previousValue = this.Layers[0].GetPixelColor(x, y);

                double r = previousValue.R;
                double g = previousValue.G;
                double b = previousValue.B;

                var hsl = RGB2HSL(previousValue.R, previousValue.G, previousValue.B);

                hsl[0] += 0.0;
                hsl[1] *= 0.5;
                hsl[2] *= 0.5;

                var rgb = HSL2RGB(hsl[0], hsl[1], hsl[2]);


                return PixelColor.FromNormalizedRGB(rgb[0], rgb[1], rgb[2]);
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }

            return PixelColor.FromNormalizedRGB(1.0, 0, 0);
        }

        // Given a Color (RGB Struct) in range of 0-255
        // Return H,S,L in range of 0-1
        public static double[] RGB2HSL(double r, double g, double b)
        {
            double v;
            double m;
            double vm;
            double r2, g2, b2;

            double h = 0; // default to black
            double s = 0;
            double l = 0;
            v = Math.Max(r, g);
            v = Math.Max(v, b);
            m = Math.Min(r, g);
            m = Math.Min(m, b);
            l = (m + v) / 2.0;
            if (l <= 0.0)
            {
                return new double[] { h, s, l };
            }
            vm = v - m;
            s = vm;
            if (s > 0.0)
            {
                s /= (l <= 0.5) ? (v + m) : (2.0 - v - m);
            }
            else
            {
                return new double[] { h, s, l };
            }
            r2 = (v - r) / vm;
            g2 = (v - g) / vm;
            b2 = (v - b) / vm;
            if (r == v)
            {
                h = (g == m ? 5.0 + b2 : 1.0 - g2);
            }
            else if (g == v)
            {
                h = (b == m ? 1.0 + r2 : 3.0 - b2);
            }
            else
            {
                h = (r == m ? 3.0 + g2 : 5.0 - r2);
            }
            h /= 6.0;

            return new double[] { h, s, l };
        }

        // Given H,S,L in range of 0-1
        // Returns a Color (RGB struct) in range of 0-255
        public static double[] HSL2RGB(double h, double sl, double l)
        {
            double v;
            double r, g, b;

            r = l;   // default to gray
            g = l;
            b = l;
            v = (l <= 0.5) ? (l * (1.0 + sl)) : (l + sl - l * sl);
            if (v > 0)
            {
                double m;
                double sv;
                int sextant;
                double fract, vsf, mid1, mid2;

                m = l + l - v;
                sv = (v - m) / v;
                h *= 6.0;
                sextant = (int)h;
                fract = h - sextant;
                vsf = v * sv * fract;
                mid1 = m + vsf;
                mid2 = v - vsf;
                switch (sextant)
                {
                    case 0:
                        r = v;
                        g = mid1;
                        b = m;
                        break;
                    case 1:
                        r = mid2;
                        g = v;
                        b = m;
                        break;
                    case 2:
                        r = m;
                        g = v;
                        b = mid1;
                        break;
                    case 3:
                        r = m;
                        g = mid2;
                        b = v;
                        break;
                    case 4:
                        r = mid1;
                        g = m;
                        b = v;
                        break;
                    case 5:
                        r = v;
                        g = m;
                        b = mid2;
                        break;
                }
            }

            return new double[] { r, g, b };
        }



        // Given a Color (RGB Struct) in range of 0-255
        // Return H,S,L in range of 0-1
        public static double[] RGB2HSLMM(double r, double g, double b)
        {
            double cmax;
            double cmin;
            double r2, g2, b2;

            double h = 0; // default to black
            double s = 1;
            double l = 0.5;
            cmax = Math.Max(r, g);
            cmax = Math.Max(cmax, b);
            cmin = Math.Min(r, g);
            cmin = Math.Min(cmin, b);

            r2 = (cmax - r);
            g2 = (cmax - g);
            b2 = (cmax - b);
            if (r == cmax)
            {
                h = (g == cmin ? 5.0 + b2 : 1.0 - g2);
            }
            else if (g == cmax)
            {
                h = (b == cmin ? 1.0 + r2 : 3.0 - b2);
            }
            else
            {
                h = (r == cmin ? 3.0 + g2 : 5.0 - r2);
            }
            h /= 6.0;

            return new double[] { h, s, l, cmin, cmax };
        }



        // Given H,S,L in range of 0-1
        // Returns a Color (RGB struct) in range of 0-255
        public static double[] HSLMM2RGB(double h, double s, double l, double cmin, double cmax)
        {
            double r = 0, g = 0, b = 0;

            double c = (1 - Math.Abs(2 * l - 1)) * s;

            double x = c * (1 - Math.Abs((h / 60) % 2 - 1));

            double m = l - c / 2;

            switch ((int)(h / 60.0))
            {
                case 0:
                    r = c + m;
                    g = x + m;
                    b = 0 + m;
                    break;
                case 1:
                    r = x + m;
                    g = c + m;
                    b = 0 + m;
                    break;
                case 2:
                    r = 0 + m;
                    g = c + m;
                    b = x + m;
                    break;
                case 3:
                    r = 0 + m;
                    g = x + m;
                    b = c + m;
                    break;
                case 4:
                    r = x + m;
                    g = 0 + m;
                    b = c + m;
                    break;
                case 5:
                    r = c + m;
                    g = 0 + m;
                    b = x + m;
                    break;
            }

            r = r * (cmax - cmin) + cmin;
            g = g * (cmax - cmin) + cmin;
            b = b * (cmax - cmin) + cmin;

            return new double[] { r, g, b };
        }

        public override object GetLayerView()
        {
            return null;// LayerMVPSetting.LayerViewFactory.GetBWLayerView(this);
        }
    }
}

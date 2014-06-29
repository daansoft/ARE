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

                double cmax = Math.Max(Math.Max(previousValue.R, previousValue.G), previousValue.B);
                double cmin = Math.Min(Math.Min(previousValue.R, previousValue.G), previousValue.B);

                double d = cmax - cmin;

                double hue = 0;

                if (d != 0)
                {
                    if (cmax == previousValue.R)
                    {
                        hue = ((previousValue.G - previousValue.B) / d) % 6;
                    }
                    else if (cmax == previousValue.G)
                    {
                        hue = (previousValue.B - previousValue.R) / d + 2;
                    }
                    else
                    {
                        hue = (previousValue.R - previousValue.G) / d + 4;
                    }

                    hue *= 60;

                    if (hue < 0)
                    {
                        hue += 360;
                    }
                }

                double saturation = 0;
                double lightness = 0;

                lightness = (cmax + cmin) / 2;

                if (d != 0)
                {
                    /*if ((1.0 - Math.Abs(2.0 * lightness - 1.0)) == 0)
                    {

                        return PixelColor.FromNormalizedRGB(1.0, 0, 0);
                    }*/

                    saturation = lightness > 0.5 ? d / (2 - cmax - cmin) : d / (cmax + cmin);
                    //saturation = d / (1.0 - Math.Abs(2.0 * lightness - 1.0));
                }

                hue = (hue - 0 + 360) % 360;
                saturation += 0.0;
                lightness += 0.0;

                hue /= 360.0;
                var q = lightness < 0.5 ? lightness * (1.0 + saturation) : lightness + saturation - lightness * saturation;
                var p = 2.0 * lightness - q;

                return PixelColor.FromNormalizedRGB(hue2rgb(p, q, hue + 1.0 / 3.0), hue2rgb(p, q, hue), hue2rgb(p, q, hue - 1.0 / 3.0));

                /*double c = (1 - Math.Abs(2 * lightness - 1)) * saturation;

                double f = c * (1.0 - Math.Abs((hue / 60) % 2.0 - 1.0));

                double m = lightness - c / 2.0;

                if (0 <= hue && hue < 60)
                {
                    return PixelColor.FromNormalizedRGB(c + m, f + m, m);
                }
                else if (60 <= hue && hue < 120)
                {
                    return PixelColor.FromNormalizedRGB(f + m, c + m, m);
                }
                else if (120 <= hue && hue < 180)
                {
                    return PixelColor.FromNormalizedRGB(m, c + m, f + m);
                }
                else if (180 <= hue && hue < 240)
                {
                    return PixelColor.FromNormalizedRGB(m, f + m, c + m);
                }
                else if (240 <= hue && hue < 300)
                {
                    return PixelColor.FromNormalizedRGB(f + m, m, c + m);
                }
                else if (300 <= hue && hue < 360)
                {
                    return PixelColor.FromNormalizedRGB(c + m, m, f + m);
                }*/
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }

            return PixelColor.FromNormalizedRGB(1.0, 0, 0);
        }

        private double hue2rgb(double p, double q, double t)
        {
            if (t < 0) t += 1;
            if (t > 1) t -= 1;
            if (t < 1 / 6) return p + (q - p) * 6 * t;
            if (t < 1 / 2) return q;
            if (t < 2 / 3) return p + (q - p) * (2.0 / 3.0 - t) * 6;
            return p;
        }

        public override object GetLayerView()
        {
            return null;// LayerMVPSetting.LayerViewFactory.GetBWLayerView(this);
        }
    }
}

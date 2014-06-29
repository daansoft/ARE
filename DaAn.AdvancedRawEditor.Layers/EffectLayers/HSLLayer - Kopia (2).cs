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

                double r = previousValue.R;
                double g = previousValue.G;
                double b = previousValue.B;

                double max = (r > g && r > b) ? r : (g > b) ? g : b;
                double min = (r < g && r < b) ? r : (g < b) ? g : b;

                double h, s, l;
                h = s = l = (max + min) / 2.0;

                if (max == min)
                {
                    h = s = 0.0;
                }
                else
                {
                    double d = max - min;
                    s = (l > 0.5) ? d / (2.0 - max - min) : d / (max + min);

                    if (max == r)
                        h = (g - b) / d + (g < b ? 6.0 : 0.0);

                    else if (max == g)
                        h = (b - r) / d + 2.0;

                    else
                        h = (r - g) / d + 4.0;

                    h /= 6.0;
                }

                s += 0.25;


                if (s == 0.0)
                    r = g = b = l;

                else
                {
                    var q = l < 0.5 ? l * (1.0 + s) : l + s - l * s;
                    var p = 2.0 * l - q;
                    r = HueToRgb(p, q, h + 1.0 / 3.0);
                    g = HueToRgb(p, q, h);
                    b = HueToRgb(p, q, h - 1.0 / 3.0);
                }


                return PixelColor.FromNormalizedRGB(r, g, b);
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }

            return PixelColor.FromNormalizedRGB(1.0, 0, 0);
        }

        // Helper for HslToRgba
        private static double HueToRgb(double p, double q, double t)
        {
            if (t < 0.0) t += 1.0;
            if (t > 1.0) t -= 1.0;
            if (t < 1.0 / 6.0) return p + (q - p) * 6.0 * t;
            if (t < 1.0 / 2.0) return q;
            if (t < 2.0 / 3.0) return p + (q - p) * (2.0 / 3.0 - t) * 6.0;
            return p;
        }

        public override object GetLayerView()
        {
            return null;// LayerMVPSetting.LayerViewFactory.GetBWLayerView(this);
        }
    }
}

using DaAn.AdvancedRawEditor.Layers.MVP;
using System;

namespace DaAn.AdvancedRawEditor.Layers.EffectLayers
{
    public class ContrastLayer : Layer
    {
        public double _contrast;

        public ContrastLayer(Guid identificator, double contrast)
            : base(identificator, 1)
        {
            this.Contrast = contrast;
        }


        public double Contrast
        {
            get
            {
                return this._contrast;
            }

            set
            {
                this._contrast = value;
                this.OnChange();
            }
        }

        public override PixelColor GetPixelColor(int x, int y)
        {
            var previousValue = this.Layers[0].GetPixelColor(x, y);

            return PixelColor.FromNormalizedRGB(this.Function(previousValue.R),
                this.Function(previousValue.G),
                this.Function(previousValue.B));
        }

        private double Function(double value)
        {
            return ((value - 0.5) * this._contrast) + 0.5;

            //return (1.0 / (1 + Math.Exp(-this.Contrast * 2 * (value - 0.5))));

            /*double e2x = Math.Exp(-2.0 * value);

            return (1.0 - e2x) / (1.0 + e2x);*/

            //return (Math.Atan(this._contrast * 5.0 * (value - 0.5)) / Math.Atan(this._contrast * 5.0 * 0.5)) / 2.0 + 0.5;
        }

        public override object GetLayerView()
        {
            return LayerMVPSetting.LayerViewFactory.GetContrastLayerView(this);
        }
    }
}

using DaAn.AdvancedRawEditor.Layers.MVP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.EffectLayers
{
    public class SaturationLayer : Layer
    {
        public double _saturation;

        public SaturationLayer(Guid identificator, double saturation)
            : base(identificator, 1)
        {
            this.Saturation = saturation;
        }

        public double Saturation
        {
            get
            {
                return this._saturation;
            }

            set
            {
                this._saturation = value;
                this.OnChange();
            }
        }

        public override PixelColor GetPixelColor(int x, int y)
        {
            var previousValue = this.Layers[0].GetPixelColor(x, y);

            double gray = (previousValue.R * 0.3) + (previousValue.G * 0.59) + (previousValue.B * 0.11);

            return PixelColor.FromNormalizedRGB(gray * (1.0 - this._saturation) + previousValue.R * this._saturation,
                gray * (1.0 - this._saturation) + previousValue.G * this._saturation,
                gray * (1.0 - this._saturation) + previousValue.B * this._saturation);
        }

        public override object GetLayerView()
        {
            return LayerMVPSetting.LayerViewFactory.GetSaturationLayerView(this);
        }
    }
}

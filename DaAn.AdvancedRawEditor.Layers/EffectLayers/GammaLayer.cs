using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.EffectLayers
{
    public class GammaLayer : Layer
    {
        public double _gamma;
        public double _oneByGamma;

        public GammaLayer(Guid identificator, double gamma)
            : base(identificator, 1)
        {
            this.Gamma = gamma;
        }

        public double Gamma
        {
            get
            {
                return this._gamma;
            }

            set
            {
                if (value > 0)
                {
                    this._gamma = value;
                    this._oneByGamma = 1.0 / value;
                    this.OnChange();
                }
            }
        }

        public override PixelColor GetPixelColor(int x, int y)
        {
            var previousValue = this.Layers[0].GetPixelColor(x, y);

            return PixelColor.FromNormalizedRGB(Math.Pow(previousValue.R, this._oneByGamma),
                Math.Pow(previousValue.G, this._oneByGamma),
                Math.Pow(previousValue.B, this._oneByGamma));
        }

        public override object GetLayerView()
        {
            throw new NotImplementedException();
        }
    }
}

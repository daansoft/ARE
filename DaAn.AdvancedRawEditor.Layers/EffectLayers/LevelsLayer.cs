using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.EffectLayers
{
    public class LevelsLayer : Layer
    {
        public double Blacks;
        public double Whites;

        public LevelsLayer(Guid identificator)
            : base(identificator, 1)
        {
            this.Blacks = 0.0;
            this.Whites = 0.0;
        }

        public override PixelColor GetPixelColor(int x, int y)
        {
            var previousValue = this.Layers[0].GetPixelColor(x, y);

            if (this.Enabled)
            {
                return PixelColor.FromNormalizedRGB(this.Function(previousValue.R),
                    this.Function(previousValue.G),
                    this.Function(previousValue.B));
            }
            else
            {
                return previousValue; // TODO sprawdzić czy tak można przeyłać
            }
        }

        private double Function(double value)
        {
            return (value - this.Blacks) / (1.0 - this.Whites - this.Blacks);
        }

        public override object GetLayerView()
        {
            return null;
        }
    }
}

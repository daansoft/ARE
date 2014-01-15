using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.EffectLayers
{
    public class CurvesLayer : Layer
    {
        public CurvesLayer(Guid identificator)
            : base(identificator, 1)
        {
            this.Factor = 5;
        }

        public double Factor
        {
            get;
            set;
        }

        public override PixelColor GetPixelColor(int x, int y)
        {
            var previousValue = this.Layers[0].GetPixelColor(x, y);

            return PixelColor.FromNormalizedRGB(this.Function(previousValue.RN),
                this.Function(previousValue.GN),
                this.Function(previousValue.BN));
        }

        private double Function(double value)
        {
            return (1.0 / (1 + Math.Exp(-this.Factor * (value - 0.5))));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.MixLayerMethods
{
    public class WeightedAverageMixLayerMethod : IMixLayerMethod
    {
        public WeightedAverageMixLayerMethod(double weight)
        {
            this.Weight = weight;
        }

        public PixelColor MixValue(PixelColor firstValue, PixelColor secondValue)
        {
            return PixelColor.FromNormalizedRGB(firstValue.R * (1.0 - this.Weight) + secondValue.R * this.Weight,
                firstValue.G * (1.0 - this.Weight) + secondValue.G * this.Weight,
                firstValue.B * (1.0 - this.Weight) + secondValue.B * this.Weight);
        }

        public string Name
        {
            get;
            set;
        }

        public double Weight { get; set; }
    }
}

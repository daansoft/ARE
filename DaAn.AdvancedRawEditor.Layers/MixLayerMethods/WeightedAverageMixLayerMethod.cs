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
            return PixelColor.FromNormalizedRGB(firstValue.RN * (1.0 - this.Weight) + secondValue.RN * this.Weight,
                firstValue.GN * (1.0 - this.Weight) + secondValue.GN * this.Weight,
                firstValue.BN * (1.0 - this.Weight) + secondValue.BN * this.Weight);
        }

        public string Name
        {
            get;
            set;
        }

        public double Weight { get; set; }
    }
}

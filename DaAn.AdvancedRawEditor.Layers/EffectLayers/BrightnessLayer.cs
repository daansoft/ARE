using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.EffectLayers
{
    public class BrightnessLayer : OneInputLayer
    {
        private double brightness;

        public BrightnessLayer(double brightness)
        {
            this.brightness = brightness;
        }

        public override PixelValue GetPixelColor(int x, int y)
        {
            var previousValue = this.InputLayer.GetPixelColor(x, y);

            return previousValue * brightness;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.EffectLayers
{
    public class SolidColorLayer : OneInputLayer
    {
        public PixelValue Color { get; set; }

        public override PixelValue GetPixelColor(int x, int y)
        {
            return this.Color;
        }
    }
}

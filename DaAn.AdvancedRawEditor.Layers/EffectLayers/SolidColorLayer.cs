using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.EffectLayers
{
    public class SolidColorLayer : Layer
    {
        public SolidColorLayer(Guid identificator)
            : base(identificator, 1)
        {

        }

        public PixelColor Color { get; set; }

        public override PixelColor GetPixelColor(int x, int y)
        {
            return this.Color;
        }

        public override object GetLayerView()
        {
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public class MixLayer : Layer
    {
        public MixLayer(Guid identificator)
            : base(identificator, 2)
        {
        }

        public IMixLayerMethod MixLayerMethod { get; set; }

        public override PixelColor GetPixelColor(int x, int y)
        {
            return this.MixLayerMethod.MixValue(this.Layers[0].GetPixelColor(x, y), this.Layers[1].GetPixelColor(x, y));
        }
    }
}

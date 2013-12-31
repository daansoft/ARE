using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public class MixLayer : TwoInputLayer
    {
        public IMixLayerMethod MixMethod { get; set; }
        
        public override PixelValue GetPixelValue(int x, int y)
        {
            return this.MixMethod.MixValue(this.FirstInputLayer.GetPixelValue(x, y), this.SecondInputLayer.GetPixelValue(x, y));
        }
    }
}

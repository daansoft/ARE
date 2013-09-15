using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.EffectLayers
{
    public class SolidColorLayer : Layer
    {
        public PixelValue Color { get; set; }

        public override PixelValue GetPixelValue(int x, int y)
        {
            return this.Color;
        }

        public override void Initialize()
        {
            throw new NotImplementedException();
        }
        
        public override string GetName()
        {
            return string.Format("{0}\n[Solid color]", this.PreviousLayer.GetName());
        }
    }
}

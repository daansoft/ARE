using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.LayerMixes
{
    public class NormalLayerMix : ILayerMix
    {
        public PixelValue GetValue(PixelValue pl, PixelValue pr)
        {
            return pl + pl;
        }
    }
}

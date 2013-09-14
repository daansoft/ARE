using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public class LayerMask
    {

        public double GetValue(int x, int y)
        {
            return this.Mask[x][y];
        }
    }
}

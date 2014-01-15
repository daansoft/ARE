using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public class EmptyConnectionBuilder : IConnectionBuilder
    {
        public void Connect(Layer layer, int inputIndex)
        {
        }

        public void Disconnect(int inputIndex)
        {
        }
    }
}

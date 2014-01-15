using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public interface IConnectionBuilder
    {
        void Connect(Layer layer, int inputIndex);
        void Disconnect(int inputIndex);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public class LayerConnectionBuilder : IConnectionBuilder
    {
        Layer layer;

        public LayerConnectionBuilder(Layer layer)
        {
            this.layer = layer;
        }

        public void Connect(Layer layer, int inputIndex)
        {
            layer.Change += this.layer.RefreshAfterChangePrevoiusLayer;
            this.layer.Layers[inputIndex] = layer;

            this.layer.RefreshAfterChangePrevoiusLayer(null, null);
        }

        public void Disconnect(int inputIndex)
        {
            this.layer.Layers[inputIndex].Change -= this.layer.RefreshAfterChangePrevoiusLayer;
            this.layer.Layers[inputIndex] = null;

            this.layer.RefreshAfterChangePrevoiusLayer(null, null);
            //TODO event
        }
    }
}

using DaAn.AdvancedRawEditor.Layers.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public class LayerCollection
    {
        private List<Layer> layers;

        public LayerCollection()
        {
            this.layers = new List<Layer>();
        }

        public Layer InputLayer { get; private set; }

        public Layer OutputLayer { get; private set; }

        public Layer SelectedLayer { get; private set; }

        public void Add(Layer layer)
        {
            this.layers.Add(layer);
        }

        public void Connect(Guid sourceLayerIdentificator, Guid destinationLayerIdentificator, int inputIndex)
        {
            Layer sourceLayer = this.ReadLayer(sourceLayerIdentificator);
            Layer destinationLayer = this.ReadLayer(destinationLayerIdentificator);

            IConnectionBuilder connectionBuilder = destinationLayer.GetConnectionBuilder();

            connectionBuilder.Connect(sourceLayer, inputIndex);
        }

        public void Disconnect(Guid destinationLayerIdentificator)
        {
            Layer destinationLayer = this.ReadLayer(destinationLayerIdentificator);

            IConnectionBuilder connectionBuilder = destinationLayer.GetConnectionBuilder();

            connectionBuilder.Disconnect(0);
        }

        public Layer ReadLayer(Guid layerIdentificator)
        {
            return this.layers.SingleOrDefault(r => r.Identificator == layerIdentificator);
        }

        public void SetOutputLayer(Guid identificator)
        {
            this.OutputLayer = this.ReadLayer(identificator);
        }

        public void SetSelectedLayer(Guid identificator)
        {
            this.SelectedLayer = this.ReadLayer(identificator);
        }

        public void SetInputLayer(Guid identificator)
        {
            this.InputLayer = this.ReadLayer(identificator);
        }
    }
}

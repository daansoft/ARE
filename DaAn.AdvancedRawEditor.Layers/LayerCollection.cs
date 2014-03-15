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
        private Layer selectedLayer;

        public LayerCollection()
        {
            this.Layers = new List<Layer>();
        }

        public List<Layer> Layers { get; set; }

        public Layer InputLayer { get; private set; }

        public Layer OutputLayer { get; private set; }

        public Layer SelectedLayer
        {
            get
            {
                return this.selectedLayer;
            }
            private set
            {
                this.selectedLayer = value;
                this.OnSelect();
            }
        }

        public event LayerEventHandler Select;

        public event LayerEventHandler Change;

        public void Add(Layer layer)
        {
            this.Layers.Add(layer);
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
            return this.Layers.SingleOrDefault(r => r.Identificator == layerIdentificator);
        }

        public void SetOutputLayer(Guid identificator)
        {
            if (this.OutputLayer != null)
            {
                this.OutputLayer.Change -= this.layer_Change;
            }

            this.OutputLayer = this.ReadLayer(identificator);

            if (this.OutputLayer != null)
            {
                this.OutputLayer.Change += layer_Change;
            }
        }

        void layer_Change(object sender, EventArgs e)
        {
            if (this.Change != null)
            {
                this.Change(sender, e);
            }
        }

        public void SetSelectedLayer(Guid identificator)
        {
            this.SelectedLayer = this.ReadLayer(identificator);
        }

        public void SetInputLayer(Guid identificator)
        {
            this.InputLayer = this.ReadLayer(identificator);
        }

        public virtual void OnSelect()
        {
            if (this.Select != null)
            {
                this.Select(this.selectedLayer, new EventArgs());
            }
        }
    }
}

using DaAn.AdvancedRawEditor.Layers.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public class BatchProcess
    {
        private LayerCollection layers;
        private List<string> files;

        public BatchProcess(LayerCollection layers, List<string> files)
        {
            this.layers = layers;
            this.files = files;
        }

        public void Start()
        {
            IInputLayer inputLayer = this.layers.InputLayer as IInputLayer;

            RenderLayer renderLayer = new RenderLayer(this.layers.OutputLayer);

            if (inputLayer == null)
            {
                throw new Exception("Incorrect layer");
            }

            foreach (var fileName in this.files)
            {
                inputLayer.SetInputData(fileName);

                renderLayer.GetImage().Save("PPPP" + fileName);
            }
        }

    }
}

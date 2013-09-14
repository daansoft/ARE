using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.EffectLayers
{
    public class BWLayer : ILayer
    {
        public ILayer PreviousLayer { get; set; }
        public ILayer NextLayer { get; set; }

        public PixelValue GetPixelValue(int x, int y)
        {
            var previousValue = this.PreviousLayer.GetPixelValue(x, y);

            var bw = (previousValue.R + previousValue.G + previousValue.B) / 3.0;

            return bw;
        }

        public int GetWidth()
        {
            return this.PreviousLayer.GetWidth();
        }

        public int GetHeigth()
        {
            return this.PreviousLayer.GetHeigth();
        }


        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void AddForLayer(ILayer layer)
        {
            this.PreviousLayer = layer;
            this.NextLayer = layer.NextLayer;
            layer.PreviousLayer.NextLayer = this;
        }

        public void DeleteCurrentLayer()
        {
            throw new NotImplementedException();
        }
    }
}

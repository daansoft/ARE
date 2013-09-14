using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public class MixLayer : ILayer
    {
        public ILayer PreviousLayer { get; set; }
        public ILayer CurrentLayer { get; set; }
        public ILayer NextLayer { get; set; }
        public LayerMixMethod MixMethod { get; set; }

        public PixelValue GetPixelValue(int x, int y)
        {
            switch (this.MixMethod)
            {
                case LayerMixMethod.Normal:
                    return this.MixNormal(x, y);
                default:
                    return this.MixNormal(x, y);
            }
        }

        private PixelValue MixNormal(int x, int y)
        {
            return this.PreviousLayer.GetPixelValue(x, y) + this.CurrentLayer.GetPixelValue(x, y);
        }

        public void Initialize()
        {
            this.MixMethod = LayerMixMethod.Normal;
        }

        public int GetWidth()
        {
            return this.PreviousLayer.GetWidth();
        }

        public int GetHeigth()
        {
            return this.PreviousLayer.GetHeigth();
        }


        public void AddForLayer(ILayer layer)
        {
            this.PreviousLayer = layer.PreviousLayer;
            this.CurrentLayer = layer;
            this.NextLayer = layer.NextLayer;
            layer.NextLayer.PreviousLayer = this;
        }


        public void DeleteCurrentLayer()
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            return string.Format("Mix layer for {0}", this.CurrentLayer.GetName());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public class MixLayer : Layer
    {
        public Layer CurrentLayer { get; set; }
        public MixLayerMethod MixMethod { get; set; }

        public override PixelValue GetPixelValue(int x, int y)
        {
            switch (this.MixMethod)
            {
                case MixLayerMethod.Normal:
                    return this.MixNormal(x, y);
                default:
                    return this.MixNormal(x, y);
            }
        }

        private PixelValue MixNormal(int x, int y)
        {
            return this.PreviousLayer.GetPixelValue(x, y) + this.CurrentLayer.GetPixelValue(x, y);
        }

        public override void Initialize()
        {
            this.MixMethod = MixLayerMethod.Normal;
        }

        public override string GetName()
        {
            return string.Format("[Mix layer for {0}]", this.CurrentLayer.GetName());
        }

        public override void AddInside(Layer layer)
        {
            layer.PreviousLayer = this.PreviousLayer;
            layer.ParentLayer = this;
            this.CurrentLayer = layer;
        }

        public override void Wrap(Layer layer)
        {
            this.PreviousLayer = layer.PreviousLayer;
            this.CurrentLayer = layer;
            layer.ParentLayer = this;
        }
    }
}

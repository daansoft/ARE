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

        public MixLayer()
        {
            this.MixMethod = MixLayerMethod.Normal;
        }

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

        public override string GetName()
        {
            return string.Format("[Mix layer for:\n{0}]", this.CurrentLayer.GetName());
        }

        public override void Add(Layer beginLayer, Layer endLayer)
        {
            beginLayer.PreviousLayer = this.PreviousLayer;
            beginLayer.ParentLayer = this;
            this.CurrentLayer = endLayer;
        }

        public override void Wrap(Layer beginLayer, Layer endLayer)
        {
            this.PreviousLayer = beginLayer.PreviousLayer;
            this.CurrentLayer = endLayer;
            beginLayer.ParentLayer = this;
        }
    }
}

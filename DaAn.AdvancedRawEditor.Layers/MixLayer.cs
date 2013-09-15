using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public class MixLayer : BaseLayer
    {
        public ILayer CurrentLayer { get; set; }
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
            return string.Format("{0}\n[Mix layer for {0}]", this.PreviousLayer.GetName(), this.CurrentLayer.GetName());
        }
    }
}

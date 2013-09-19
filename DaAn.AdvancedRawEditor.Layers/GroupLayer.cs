using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public class GroupLayer : Layer
    {
        private static AddLayerMethod[] AllowedMethod = new AddLayerMethod[] { AddLayerMethod.Next, AddLayerMethod.Wrap };

        private CacheLayer CacheLayer;
        private List<Layer> Layers;

        public GroupLayer()
        {

            this.Layers = new List<Layer>();
        }

        public override PixelValue GetPixelValue(int x, int y)
        {
            var parentValue = this.PreviousLayer.GetPixelValue(x, y);

            throw new NotImplementedException();
        }

        public override void Initialize()
        {
            this.Layers = new List<Layer>();
        }

        public override string GetName()
        {
            return string.Format("[Group layer for {0}]", string.Join(", ", this.Layers.Select(r => r.GetName())));
        }

        public override AddLayerMethod[] GetAddLayerMethods()
        {
            return GroupLayer.AllowedMethod;
        }

        public override void AddAfter(Layer layer)
        {
            this.CacheLayer = new CacheLayer();

            this.CacheLayer.PreviousLayer = layer;

            base.AddAfter(layer);
        }

        public override void AddInside(Layer beginLayer, Layer endLayer)
        {
            beginLayer.PreviousLayer = this.CacheLayer;
            beginLayer.ParentLayer = this;

            this.Layers.Add(endLayer);
        }

        public override void Wrap(Layer beginLayer, Layer endLayer)
        {
        }

        protected override void DeleteSubLayer(Layer layer)
        {
        }
    }
}

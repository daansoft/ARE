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

        public override void After(Layer layer)
        {
            this.CacheLayer = new CacheLayer();

            this.CacheLayer.PreviousLayer = layer;
        }

        public override void Add(Layer beginLayer, Layer endLayer)
        {
            /*if (beginLayer.PreviousLayer != null)
            {
                beginLayer.PreviousLayer.NextLayer = this;
            }

            beginLayer.PreviousLayer = this.CacheLayer;
            beginLayer.ParentLayer = this;

            if (endLayer.NextLayer != null)
            {
                endLayer.NextLayer.PreviousLayer = null;
            }

            endLayer.NextLayer = null;

            this.Layers.Add(endLayer);*/
        }

        public override void Wrap(Layer beginLayer, Layer endLayer)
        {
            this.CacheLayer = new CacheLayer();
            this.CacheLayer.PreviousLayer = beginLayer.PreviousLayer;

            this.PreviousLayer = beginLayer.PreviousLayer;
            if (beginLayer.PreviousLayer != null)
            {
                beginLayer.PreviousLayer.NextLayer = this;
            }

            beginLayer.PreviousLayer = this.CacheLayer;
            beginLayer.ParentLayer = this;

            this.NextLayer = endLayer.NextLayer;
            if (endLayer.NextLayer != null)
            {
                endLayer.NextLayer.PreviousLayer = this;
            }

            endLayer.NextLayer = null;

            this.Layers.Add(endLayer);
        }

        public override Layer PreviousLayer
        {
            get
            {
                return base.PreviousLayer;
            }
            set
            {
                if (this.CacheLayer != null)
                {
                    this.CacheLayer.PreviousLayer = value;
                }

                base.PreviousLayer = value;
            }
        }

        protected override void DeleteSubLayer(Layer layer)
        {
        }
    }
}

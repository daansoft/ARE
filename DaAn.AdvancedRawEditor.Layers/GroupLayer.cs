using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public class GroupLayer : BaseLayer
    {
        private static AddLayerMethod[] AllowedMethod = new AddLayerMethod[] { AddLayerMethod.AsNext, AddLayerMethod.IncludeCurrent };

        private List<ILayer> Layers;

        public override PixelValue GetPixelValue(int x, int y)
        {
            var parentValue = this.PreviousLayer.GetPixelValue(x, y);

            throw new NotImplementedException();
        }

        public override void Initialize()
        {
            this.Layers = new List<ILayer>();
        }

        public override string GetName()
        {
            return string.Format("[Group layer for {0}]", string.Join(", ", this.Layers.Select(r => r.GetName())));
        }

        public override AddLayerMethod[] GetAddLayerMethods()
        {
            return GroupLayer.AllowedMethod;
        }

        protected override void AddInside(ILayer layer)
        {
            layer.PreviousLayer = this.PreviousLayer;
            this.Layers.Add(layer);
        }

        protected override void AddAndIncludeCurrent(ILayer layer)
        {
            base.AddAndIncludeCurrent(layer);
        }
    }
}

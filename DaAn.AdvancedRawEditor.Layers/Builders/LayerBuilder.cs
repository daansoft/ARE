using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.Builders
{
    public class LayerBuilder
    {

        /*private static AddLayerMethod[] AllowedMethod = new AddLayerMethod[] { AddLayerMethod.Next };

        public virtual void Delete()
        {
            if (this.ParentLayer == null)
            {
                this.NextLayer.PreviousLayer = this.PreviousLayer;
                this.PreviousLayer.NextLayer = this.NextLayer;
            }
            else
            {
                this.ParentLayer.DeleteSubLayer(this);
            }
        }

        protected virtual void DeleteSubLayer(Layer layer)
        {
            throw new NotImplementedException();
        }

        public virtual AddLayerMethod[] GetAddLayerMethods()
        {
            return Layer.AllowedMethod;
        }



        public virtual void After(Layer layer)
        {
            this.NextLayer = layer.NextLayer;
            if (layer.NextLayer != null)
            {
                layer.NextLayer.PreviousLayer = this;
            }

            layer.NextLayer = this;
            this.PreviousLayer = layer;
        }

        public virtual void Wrap(Layer beginLayer, Layer endLayer)
        {
            throw new Exception("Override Wrap");
        }

        public virtual void Add(Layer beginLayer, Layer endLayer)
        {
            throw new Exception("Override AddInside");
        }*/

    }
}

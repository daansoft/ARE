using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public abstract class Layer
    {
        private static AddLayerMethod[] AllowedMethod = new AddLayerMethod[] { AddLayerMethod.Next };

        public virtual Layer ParentLayer { get; set; }
        public virtual Layer PreviousLayer { get; set; }
        public virtual Layer NextLayer { get; set; }

        public virtual int GetWidth()
        {
            if (this.PreviousLayer == null)
            {
                throw new Exception("Override GetWidth");
            }

            return this.PreviousLayer.GetWidth();
        }

        public virtual int GetHeigth()
        {
            if (this.PreviousLayer == null)
            {
                throw new Exception("Override GetHeigth");
            }

            return this.PreviousLayer.GetHeigth();
        }

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

        protected virtual string GetPreviousLayerName()
        {
            return this.PreviousLayer == null ? string.Empty : string.Format("{0}\n", this.PreviousLayer.GetName());
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
        }

        public abstract PixelValue GetPixelValue(int x, int y);
        public abstract string GetName();
        public abstract void Initialize();
    }
}

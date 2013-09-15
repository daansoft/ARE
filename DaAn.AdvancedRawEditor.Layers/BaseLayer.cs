using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public abstract class BaseLayer : ILayer
    {
        private static AddLayerMethod[] AllowedMethod = new AddLayerMethod[] { AddLayerMethod.AsNext };

        public ILayer PreviousLayer { get; set; }
        public ILayer NextLayer { get; set; }

        public abstract void Initialize();

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

        public virtual void AddLayer(ILayer layer, AddLayerMethod method)
        {
            switch (method)
            {
                case AddLayerMethod.AsNext:
                    this.AddNext(layer);
                    return;
                case AddLayerMethod.IncludeCurrent:
                    this.AddAndIncludeCurrent(layer);
                    return;
                case AddLayerMethod.Inside:
                    this.AddInside(layer);
                    return;
                default:
                    throw new Exception("Unknown AddLayerMethod");
            }
        }

        public virtual void DeleteCurrentLayer()
        {
            this.NextLayer.PreviousLayer = this.PreviousLayer;
            this.PreviousLayer.NextLayer = this.NextLayer;
        }

        public virtual AddLayerMethod[] GetAddLayerMethods()
        {
            return BaseLayer.AllowedMethod;
        }

        public abstract PixelValue GetPixelValue(int x, int y);
        public abstract string GetName();

        protected string GetPreviousLayerName()
        {
            return this.PreviousLayer == null ? string.Empty : string.Format("{0}\n", this.PreviousLayer.GetName());
        }

        protected virtual void AddNext(ILayer layer)
        {
            layer.PreviousLayer = this;
            layer.NextLayer = this.NextLayer;

            this.NextLayer.PreviousLayer = layer;
            this.PreviousLayer.NextLayer = layer;
        }

        protected virtual void AddAndIncludeCurrent(ILayer layer)
        {
            throw new Exception("Override AddAndIncludeCurrent");
        }

        protected virtual void AddInside(ILayer layer)
        {
            throw new Exception("Override AddInside");
        }
    }
}

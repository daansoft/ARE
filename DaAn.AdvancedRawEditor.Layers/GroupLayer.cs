using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public class GroupLayer : ILayer
    {
        public ILayer PreviousLayer { get; set; }
        public ILayer NextLayer { get; set; }

        private List<ILayer> Layers;

        public PixelValue GetPixelValue(int x, int y)
        {
            var parentValue = this.PreviousLayer.GetPixelValue(x, y);

            throw new NotImplementedException();
        }

        public int GetWidth()
        {
            return this.PreviousLayer.GetWidth();
        }

        public int GetHeigth()
        {
            return this.PreviousLayer.GetHeigth();
        }

        public void Add(ILayer layer)
        {
            layer.PreviousLayer = this.PreviousLayer;
            this.Layers.Add(layer);
        }

        public void Initialize()
        {
            this.Layers = new List<ILayer>();
        }


        public void AddForLayer(ILayer layer)
        {
            throw new NotImplementedException();
        }


        public void DeleteCurrentLayer()
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            return string.Format("Group layer for [{0}]", string.Join(", ", this.Layers.Select(r=>r.GetName())));
        }
    }
}

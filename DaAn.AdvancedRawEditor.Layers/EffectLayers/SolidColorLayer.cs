using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.EffectLayers
{
    public class SolidColorLayer : ILayer
    {
        public ILayer PreviousLayer { get; set; }
        public ILayer NextLayer { get; set; }

        public PixelValue Color { get; set; }

        public PixelValue GetPixelValue(int x, int y)
        {
            return this.Color;
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public int GetWidth()
        {
            throw new NotImplementedException();
        }

        public int GetHeigth()
        {
            throw new NotImplementedException();
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
            return "Solid color";
        }
    }
}

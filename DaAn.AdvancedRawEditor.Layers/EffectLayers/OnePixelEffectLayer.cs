using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.EffectLayers
{
    public abstract class OnePixelEffectLayer : ILayer, IMask
    {
        public ILayer PreviousLayer { get; set; }
        public ILayer NextLayer { get; set; }
        public double[][] Mask { get; set; }

        public abstract PixelValue GetPixelValue(int x, int y);

        public int GetWidth()
        {
            return this.PreviousLayer.GetWidth();
        }

        public int GetHeigth()
        {
            return this.PreviousLayer.GetHeigth();
        }


        public void Initialize()
        {
            this.Mask = new double[100][];
        }
    }
}

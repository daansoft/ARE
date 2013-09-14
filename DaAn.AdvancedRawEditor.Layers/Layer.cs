using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public abstract class Layer
    {
        public Layer PreviousLayer { get; set; }
        public Layer NextLayer { get; set; }
        public ILayerMix LayerMix { get; set; }

        public double[][] Mask { get; set; }
        private PixelValue[][] Cache;

        public PixelValue GetPixelValue(int x, int y)
        {
            if (this.Cache == null)
            {

            }

            return this.Cache[x][y];
        }

        public void RefreshCache()
        {
            for (int x = 0; x < this.PreviousLayer.GetWidth(); x++)
            {
                for (int y = 0; y < this.PreviousLayer.GetHeigth(); y++)
                {
                    this.Cache[x][y] = this.PreviousLayer.GetPixelValue(x, y);
                }
            }
        }

        /*public static PixelValue GetMaskedPixelValue(Layer previousLayer, double[][] mask, ILayerMix layerMix, Func<PixelValue, int, int, PixelValue> applyFilter)
        {
            PixelValue maskedInputValue = PixelValue.One;
            PixelValue maskedOutputValue = PixelValue.One;
            double maskValue = 1;

            if (mask != null)
            {
                maskValue = mask[x][y];
            }

            PixelValue inputValue = PixelValue.One;

            if (previousLayer != null)
            {
                inputValue = previousLayer.GetPixelValue(x, y);

                if (maskValue < 1.0)
                {
                    maskedInputValue = inputValue * (1 - maskValue);
                }
            }

            if (maskValue > 0.0)
            {
                maskedOutputValue = applyFilter(inputValue, x, y) * maskValue;
            }

            return layerMix.GetValue(maskedInputValue, maskedOutputValue);
        }*/

        protected PixelValue ApplyFilter(PixelValue value, int x, int y)
        {
            return value;
        }

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
    }
}

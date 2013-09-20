using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public class CacheLayer : Layer
    {
        //TODO cache for width and height
        private PixelValue[][] CacheData;

        public override PixelValue GetPixelValue(int x, int y)
        {
            return this.CacheData[x][y];
        }

        public void RefreshCache()
        {
            for (int x = 0; x < this.PreviousLayer.GetWidth(); x++)
            {
                for (int y = 0; y < this.PreviousLayer.GetHeigth(); y++)
                {
                    this.CacheData[x][y] = this.PreviousLayer.GetPixelValue(x, y);
                }
            }
        }

        public void Initialize()
        {
            this.CacheData = new PixelValue[this.PreviousLayer.GetWidth()][];

            var height = this.PreviousLayer.GetHeigth();
            for (int i = 0; i < this.PreviousLayer.GetWidth(); i++)
            {
                this.CacheData[i] = new PixelValue[height];
            }
        }

        public override string GetName()
        {
            return "[Cache layer]";
        }
    }
}

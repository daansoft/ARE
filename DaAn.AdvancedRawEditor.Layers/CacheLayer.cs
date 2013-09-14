using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public class CacheLayer : ILayer
    {
        public ILayer PreviousLayer { get; set; }
        public ILayer NextLayer { get; set; }

        private PixelValue[][] CacheData;

        public PixelValue GetPixelValue(int x, int y)
        {
            return this.CacheData[x][y];
        }

        public int GetWidth()
        {
            return this.PreviousLayer.GetWidth();
        }

        public int GetHeigth()
        {
            return this.PreviousLayer.GetHeigth();
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
            this.CacheData = new PixelValue[10][];
        }
    }
}

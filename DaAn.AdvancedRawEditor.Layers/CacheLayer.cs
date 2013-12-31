using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public class CacheLayer : OneInputLayer
    {
        private int cachedWidth;
        private int cachedHeight;

        private PixelValue[] cachedData;

        public override PixelValue GetPixelValue(int x, int y)
        {
            return this.cachedData[y * this.cachedWidth + x];
        }

        public void RefreshCache()
        {
            for (int i = 0; i < this.cachedData.Length; i++)
            {
                this.cachedData[i] = this.InputLayer.GetPixelValue(i % this.cachedWidth, i / this.cachedWidth);
            }
        }

        public void Initialize()
        {
            this.cachedWidth = this.InputLayer.Width;
            this.cachedHeight = this.InputLayer.Height;

            this.cachedData = new PixelValue[this.cachedWidth * this.cachedHeight];
        }
    }
}

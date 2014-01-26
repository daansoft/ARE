using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public class CacheLayer : Layer
    {
        private int cachedWidth;
        private int cachedHeight;

        private PixelColor[] cachedData;

        public CacheLayer(Guid identificator)
            : base(identificator, 1)
        {

        }

        public override PixelColor GetPixelColor(int x, int y)
        {
            return this.cachedData[y * this.cachedWidth + x];
        }

        public void RefreshCache()
        {
            for (int i = 0; i < this.cachedData.Length; i++)
            {
                this.cachedData[i] = this.Layers[0].GetPixelColor(i % this.cachedWidth, i / this.cachedWidth);
            }
        }

        public void Initialize()
        {
            this.cachedWidth = this.Layers[0].Width;
            this.cachedHeight = this.Layers[0].Height;

            this.cachedData = new PixelColor[this.cachedWidth * this.cachedHeight];
        }

        public override void RefreshAfterChangePrevoiusLayer(object sender, EventArgs e)
        {
            this.Initialize();
            this.RefreshCache();
            base.RefreshAfterChangePrevoiusLayer(sender, e);
        }
    }
}

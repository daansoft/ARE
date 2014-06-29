using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.Layers
{
    public class SamplingLayer : Layer
    {
        private double width;
        private double height;

        private double sampling;
        private double invertSampling;

        public SamplingLayer(Guid identificator, double width, double height)
            : base(identificator, 1)
        {
            this.width = width;
            this.height = height;
        }

        public override int Width
        {
            get
            {
                return (int)(base.Width * this.sampling);
            }
        }

        public override int Height
        {
            get
            {
                return (int)(base.Height * this.sampling);
            }
        }

        public override PixelColor GetPixelColor(int x, int y)
        {
            return this.Layers[0].GetPixelColor((int)(x * invertSampling), (int)(y * invertSampling));
        }

        public override void RefreshAfterChangePrevoiusLayer(object sender, EventArgs e)
        {
            base.RefreshAfterChangePrevoiusLayer(sender, e);
            this.GetSampling();
        }

        private void GetSampling()
        {
            var s1 = this.width / base.Width;
            var s2 = this.height / base.Height;

            this.sampling = Math.Min(s1, s2);

            this.invertSampling = 1.0 / this.sampling;
        }

        public override object GetLayerView()
        {
            return null;
        }
    }
}

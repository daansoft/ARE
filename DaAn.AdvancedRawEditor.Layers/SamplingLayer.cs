using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public class SamplingLayer : OneInputLayer
    {
        private double sampling;
        private double invertSampling;

        public SamplingLayer(double sampling)
        {
            this.sampling = sampling;
            this.invertSampling = 1.0 / this.sampling;
        }

        public override int Width
        {
            get
            {
                return (int)(base.Width * sampling);
            }
        }

        public override int Height
        {
            get
            {
                return (int)(base.Height * sampling);
            }
        }

        public override PixelValue GetPixelColor(int x, int y)
        {
            return this.InputLayer.GetPixelColor((int)(x * invertSampling), (int)(y * invertSampling));
        }
    }
}

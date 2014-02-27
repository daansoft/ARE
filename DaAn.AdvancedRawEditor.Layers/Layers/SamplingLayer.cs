using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.Layers
{
    public class SamplingLayer : Layer
    {
        private double sampling;
        private double invertSampling;

        public SamplingLayer(Guid identificator, double sampling)
            : base(identificator, 1)
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

        public override PixelColor GetPixelColor(int x, int y)
        {
            return this.Layers[0].GetPixelColor((int)(x * invertSampling), (int)(y * invertSampling));
        }

        public override object GetLayerView()
        {
            throw new NotImplementedException();
        }
    }
}

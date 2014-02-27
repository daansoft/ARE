using DaAn.AdvancedRawEditor.Layers.MVP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.EffectLayers
{
    public class ExposureLayer : Layer
    {
        private double powExposure;
        private double exposure;

        public ExposureLayer(Guid identificator, double exposure)
            : base(identificator, 1)
        {
            this.Exposure = exposure;
        }

        public double Exposure
        {
            get
            {
                return this.exposure;
            }
            set
            {
                this.exposure = value;
                this.powExposure = Math.Pow(2, value);
                this.OnChange();
            }
        }

        public override PixelColor GetPixelColor(int x, int y)
        {
            var previousValue = this.Layers[0].GetPixelColor(x, y);

            return PixelColor.FromNormalizedRGB(previousValue.RN * this.powExposure,
                previousValue.GN * this.powExposure,
                previousValue.BN * this.powExposure);
        }

        public override object GetLayerView()
        {
            return LayerMVPSetting.LayerViewFactory.GetExposureLayerView(this);
        }
    }
}

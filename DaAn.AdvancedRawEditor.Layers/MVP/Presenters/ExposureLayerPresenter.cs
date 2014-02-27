using DaAn.AdvancedRawEditor.Layers.EffectLayers;
using DaAn.AdvancedRawEditor.Layers.MVP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.MVP.Presenters
{
    public class ExposureLayerPresenter
    {
        private ExposureLayer exposureLayer;

        public ExposureLayerPresenter(ExposureLayer exposureLayer)
        {
            this.exposureLayer = exposureLayer;
        }

        public IExposureLayerView ExposureLayerView { get; set; }

        public void Initialize()
        {
        }

        public double Exposure
        {
            get
            {
                return this.exposureLayer.Exposure;
            }
            set
            {
                this.exposureLayer.Exposure = value;
            }
        }
    }
}

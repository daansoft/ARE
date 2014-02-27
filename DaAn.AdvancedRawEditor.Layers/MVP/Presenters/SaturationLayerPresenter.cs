using DaAn.AdvancedRawEditor.Layers.EffectLayers;
using DaAn.AdvancedRawEditor.Layers.MVP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.MVP.Presenters
{
    public class SaturationLayerPresenter
    {
        private SaturationLayer saturationLayer;

        public SaturationLayerPresenter(SaturationLayer saturationLayer)
        {
            this.saturationLayer = saturationLayer;
        }

        public ISaturationLayerView SaturationLayerView { get; set; }

        public void Initialize()
        {
        }

        public double Saturation
        {
            get
            {
                return this.saturationLayer.Saturation;
            }
            set
            {
                this.saturationLayer.Saturation = value;
            }
        }
    }
}

using DaAn.AdvancedRawEditor.Controls.Layers;
using DaAn.AdvancedRawEditor.Layers.EffectLayers;
using DaAn.AdvancedRawEditor.Layers.MVP;
using DaAn.AdvancedRawEditor.Layers.MVP.Presenters;
using DaAn.AdvancedRawEditor.Layers.MVP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Controls
{
    public class ControlLayerViewFactory : ILayerViewFactory
    {
        public IExposureLayerView GetExposureLayerView(ExposureLayer exposureLayer)
        {
            return new ExposureLayerControl(new ExposureLayerPresenter(exposureLayer));
        }

        public IBWLayerView GetBWLayerView(BWLayer bwLayer)
        {
            return new BWLayerControl(new BWLayerPresenter(bwLayer));
        }

        public ISaturationLayerView GetSaturationLayerView(SaturationLayer saturationLayer)
        {
            return new SaturationLayerControl(new SaturationLayerPresenter(saturationLayer));
        }
    }
}

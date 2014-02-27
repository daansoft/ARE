using DaAn.AdvancedRawEditor.Layers.EffectLayers;
using DaAn.AdvancedRawEditor.Layers.MVP.Presenters;
using DaAn.AdvancedRawEditor.Layers.MVP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.MVP
{
    public class LayerPresenterFactory
    {
        public ExposureLayerPresenter GetExposureLayerPresenter(ExposureLayer exposureLayer)
        {
            return new ExposureLayerPresenter(exposureLayer);
        }

        public BWLayer GetBWLayerPresenter(BWLayer bWLayer)
        {
            throw new NotImplementedException();
        }
    }
}

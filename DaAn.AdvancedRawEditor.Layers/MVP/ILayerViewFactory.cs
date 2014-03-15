using DaAn.AdvancedRawEditor.Layers.EffectLayers;
using DaAn.AdvancedRawEditor.Layers.MVP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.MVP
{
    public interface ILayerViewFactory
    {
        IExposureLayerView GetExposureLayerView(ExposureLayer exposureLayer);

        IBWLayerView GetBWLayerView(BWLayer bwLayer);

        ISaturationLayerView GetSaturationLayerView(SaturationLayer saturationLayer);

        IContrastLayerView GetContrastLayerView(ContrastLayer contrastLayer);

        IRGBMatrixLayerView GetRGBMatrixLayerView(RGBMatrixLayer rgbMatrixLayer);
    }
}

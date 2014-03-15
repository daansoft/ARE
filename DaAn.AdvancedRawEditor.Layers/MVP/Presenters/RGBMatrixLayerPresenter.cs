using DaAn.AdvancedRawEditor.Layers.EffectLayers;
using DaAn.AdvancedRawEditor.Layers.MVP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.MVP.Presenters
{
    public class RGBMatrixLayerPresenter
    {
        private RGBMatrixLayer rgbMatrixLayer;

        public RGBMatrixLayerPresenter(RGBMatrixLayer rgbMatrixLayer)
        {
            this.rgbMatrixLayer = rgbMatrixLayer;
        }

        public IRGBMatrixLayerView RGBMatrixLayerView { get; set; }

        public void Initialize()
        {
            this.RGBMatrixLayerView.Value00 = rgbMatrixLayer.Get(0, 0);
            this.RGBMatrixLayerView.Value01 = rgbMatrixLayer.Get(0, 1);
            this.RGBMatrixLayerView.Value02 = rgbMatrixLayer.Get(0, 2);
            this.RGBMatrixLayerView.Value10 = rgbMatrixLayer.Get(1, 0);
            this.RGBMatrixLayerView.Value11 = rgbMatrixLayer.Get(1, 1);
            this.RGBMatrixLayerView.Value12 = rgbMatrixLayer.Get(1, 2);
            this.RGBMatrixLayerView.Value20 = rgbMatrixLayer.Get(2, 0);
            this.RGBMatrixLayerView.Value21 = rgbMatrixLayer.Get(2, 1);
            this.RGBMatrixLayerView.Value22 = rgbMatrixLayer.Get(2, 2);
        }

        public void Refresh()
        {
            this.rgbMatrixLayer.Set(0, 0, this.RGBMatrixLayerView.Value00);
            this.rgbMatrixLayer.Set(0, 1, this.RGBMatrixLayerView.Value01);
            this.rgbMatrixLayer.Set(0, 2, this.RGBMatrixLayerView.Value02);
            this.rgbMatrixLayer.Set(1, 0, this.RGBMatrixLayerView.Value10);
            this.rgbMatrixLayer.Set(1, 1, this.RGBMatrixLayerView.Value11);
            this.rgbMatrixLayer.Set(1, 2, this.RGBMatrixLayerView.Value12);
            this.rgbMatrixLayer.Set(2, 0, this.RGBMatrixLayerView.Value20);
            this.rgbMatrixLayer.Set(2, 1, this.RGBMatrixLayerView.Value21);
            this.rgbMatrixLayer.Set(2, 2, this.RGBMatrixLayerView.Value22);

            this.rgbMatrixLayer.OnChange();
        }
    }
}

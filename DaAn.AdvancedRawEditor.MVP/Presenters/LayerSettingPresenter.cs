using DaAn.AdvancedRawEditor.Layers;
using DaAn.AdvancedRawEditor.Layers.EffectLayers;
using DaAn.AdvancedRawEditor.MVP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.MVP.Presenters
{
    public class LayerSettingPresenter
    {
        public ILayerSettingView LayerSettingView;

        public void SetLayerView(Layer layer)
        {
            this.LayerSettingView.Add(layer.GetLayerView());
        }


        public void SetLayersView(List<Layer> layers)
        {
            foreach (var layer in layers)
            {
                this.LayerSettingView.Add(layer.GetLayerView());
            }
        }
    }
}

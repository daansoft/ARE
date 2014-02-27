using DaAn.AdvancedRawEditor.Layers.EffectLayers;
using DaAn.AdvancedRawEditor.MVP.Presenters;
using DaAn.AdvancedRawEditor.MVP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.MVP
{
    public class PresenterFactory
    {
        public IViewFactory ViewFactory { get; set; }

        public MainPresenter GetMainPresenter()
        {
            return new MainPresenter();
        }

        public DesignerPresenter GetDesignerPresenter()
        {
            return new DesignerPresenter();
        }

        public LayerSettingPresenter GetLayerSettingPresenter()
        {
            return new LayerSettingPresenter();
        }
    }
}

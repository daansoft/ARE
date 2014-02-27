using DaAn.AdvancedRawEditor.Controls;
using DaAn.AdvancedRawEditor.Layers.EffectLayers;
using DaAn.AdvancedRawEditor.MVP;
using DaAn.AdvancedRawEditor.MVP.Presenters;
using DaAn.AdvancedRawEditor.MVP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor
{
    public class WinFormsViewFactory : IViewFactory
    {
        public IMainView GetMainView()
        {
            return new MainForm(MVPSetting.PresenterFactory.GetMainPresenter(),
                MVPSetting.PresenterFactory.GetDesignerPresenter(),
                MVPSetting.PresenterFactory.GetLayerSettingPresenter());
        }
    }
}

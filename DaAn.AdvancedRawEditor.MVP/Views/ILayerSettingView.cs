using DaAn.AdvancedRawEditor.MVP.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.MVP.Views
{
    public interface ILayerSettingView
    {
        LayerSettingPresenter LayerSettingPresenter { get; set; }

        void Add(object setting);
    }
}

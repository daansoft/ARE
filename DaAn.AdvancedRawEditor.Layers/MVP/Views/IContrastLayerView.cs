using DaAn.AdvancedRawEditor.Layers.MVP.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.MVP.Views
{
    public interface IContrastLayerView
    {
        ContrastLayerPresenter ContrastLayerPresenter { get; set; }
    }
}

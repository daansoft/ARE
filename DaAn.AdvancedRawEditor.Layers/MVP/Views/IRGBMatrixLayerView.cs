using DaAn.AdvancedRawEditor.Layers.MVP.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.MVP.Views
{
    public interface IRGBMatrixLayerView
    {
        RGBMatrixLayerPresenter RGBMatrixLayerPresenter { get; set; }

        void SendMessage(string message);

        double Value00 { get; set; }
        double Value01 { get; set; }
        double Value02 { get; set; }
        double Value10 { get; set; }
        double Value11 { get; set; }
        double Value12 { get; set; }
        double Value20 { get; set; }
        double Value21 { get; set; }
        double Value22 { get; set; }
    }
}

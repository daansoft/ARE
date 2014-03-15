using DaAn.AdvancedRawEditor.Layers;
using DaAn.AdvancedRawEditor.MVP.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.MVP.Views
{
    public interface IDesignerView
    {
        DesignerPresenter DesignerPresenter { get; set; }

        void SetSelectedLayer(Layer layer);

        void SendMessage(string message);

        void RefreshImageView();

        void SetSelectedLayers(List<Layer> layers);
    }
}

using DaAn.AdvancedRawEditor.Layers;
using DaAn.AdvancedRawEditor.MVP.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.MVP.Views
{
    public interface IMainView
    {
        MainPresenter MainPresenter { get; set; }

        void ShowView();
        void SendMessage(string message);
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DaAn.AdvancedRawEditor.MVP.Views;
using DaAn.AdvancedRawEditor.Layers;
using DaAn.AdvancedRawEditor.MVP.Presenters;

namespace DaAn.AdvancedRawEditor.Controls
{
    public partial class DesignerControl : UserControl, IDesignerView
    {
        public DesignerControl()
        {
            InitializeComponent();
        }

        public DesignerPresenter DesignerPresenter { get; set; }

        public void SetSelectedLayer(Layer layer)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(string message)
        {
            throw new NotImplementedException();
        }

        public void RefreshImageView()
        {
            throw new NotImplementedException();
        }
    }
}

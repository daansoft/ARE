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
using DaAn.AdvancedRawEditor.MVP.Presenters;
using DaAn.AdvancedRawEditor.Layers.MVP.Views;
using DaAn.AdvancedRawEditor.Layers.MVP.Presenters;

namespace DaAn.AdvancedRawEditor.Controls.Layers
{
    public partial class ContrastLayerControl : UserControl, IContrastLayerView
    {
        public ContrastLayerControl(ContrastLayerPresenter contrastLayerPresenter)
        {
            InitializeComponent();

            this.ContrastLayerPresenter = contrastLayerPresenter;
            this.ContrastLayerPresenter.ContrastLayerView = this;

            this.Initialize();
        }

        public void Initialize()
        {
            this.contrastTB.Value = (int)(this.ContrastLayerPresenter.Contrast * 100);
        }

        public ContrastLayerPresenter ContrastLayerPresenter { get; set; }

        public void SendMessage(string message)
        {
            throw new NotImplementedException();
        }

        private void contrastTB_MouseCaptureChanged(object sender, EventArgs e)
        {
            this.ContrastLayerPresenter.Contrast = this.contrastTB.Value / 100.0;
        }

        private void enabledCB_CheckedChanged(object sender, EventArgs e)
        {
            //this.ContrastLayerPresenter.LayerEnabled = this.enabledCB.Checked;
        }
    }
}

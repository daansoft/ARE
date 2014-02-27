using DaAn.AdvancedRawEditor.Layers.MVP.Presenters;
using DaAn.AdvancedRawEditor.Layers.MVP.Views;
using System;
using System.Windows.Forms;

namespace DaAn.AdvancedRawEditor.Controls.Layers
{
    public partial class BWLayerControl : UserControl, IBWLayerView
    {
        public BWLayerControl(BWLayerPresenter bwLayerPresenter)
        {
            InitializeComponent();

            this.BWLayerPresenter = bwLayerPresenter;
            this.BWLayerPresenter.BWLayerView = this;
        }

        public BWLayerPresenter BWLayerPresenter { get; set; }

        public void SendMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void redTB_MouseCaptureChanged(object sender, EventArgs e)
        {
            this.BWLayerPresenter.RFactor = this.redTB.Value / 100.0;
        }

        private void greenTB_MouseCaptureChanged(object sender, EventArgs e)
        {
            this.BWLayerPresenter.GFactor = this.greenTB.Value / 100.0;
        }

        private void blueTB_MouseCaptureChanged(object sender, EventArgs e)
        {
            this.BWLayerPresenter.BFactor = this.blueTB.Value / 100.0;
        }
    }
}

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
    public partial class SaturationLayerControl : UserControl, ISaturationLayerView
    {
        public SaturationLayerControl(SaturationLayerPresenter saturationLayerPresenter)
        {
            InitializeComponent();

            this.SaturationLayerPresenter = saturationLayerPresenter;
            this.SaturationLayerPresenter.SaturationLayerView = this;

            this.Initialize();
        }

        public void Initialize()
        {
            this.saturationTB.Value = (int)(this.SaturationLayerPresenter.Saturation * 100);
        }

        public SaturationLayerPresenter SaturationLayerPresenter { get; set; }

        public void SendMessage(string message)
        {
            throw new NotImplementedException();
        }

        private void saturationTB_MouseCaptureChanged(object sender, EventArgs e)
        {
            this.SaturationLayerPresenter.Saturation = this.saturationTB.Value / 100.0;
        }
    }
}

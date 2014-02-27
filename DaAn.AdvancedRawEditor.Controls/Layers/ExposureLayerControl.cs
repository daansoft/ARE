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
    public partial class ExposureLayerControl : UserControl, IExposureLayerView
    {
        public ExposureLayerControl(ExposureLayerPresenter exposureLayerPresenter)
        {
            InitializeComponent();

            this.ExposureLayerPresenter = exposureLayerPresenter;
            this.ExposureLayerPresenter.ExposureLayerView = this;

            this.Initialize();
        }

        public void Initialize()
        {
            this.exposureTB.Value = (int)(this.ExposureLayerPresenter.Exposure * 100);
        }

        public ExposureLayerPresenter ExposureLayerPresenter { get; set; }

        public void SendMessage(string message)
        {
            throw new NotImplementedException();
        }

        private void exposureTB_MouseCaptureChanged(object sender, EventArgs e)
        {
            this.ExposureLayerPresenter.Exposure = this.exposureTB.Value / 100.0;
        }
    }
}

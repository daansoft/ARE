using DaAn.AdvancedRawEditor.Layers.MVP.Presenters;
using DaAn.AdvancedRawEditor.Layers.MVP.Views;
using System;
using System.Windows.Forms;

namespace DaAn.AdvancedRawEditor.Controls.Layers
{
    public partial class RGBMatrixLayerControl : UserControl, IRGBMatrixLayerView
    {
        public RGBMatrixLayerControl(RGBMatrixLayerPresenter rgbMatrixLayerPresenter)
        {
            InitializeComponent();

            this.RGBMatrixLayerPresenter = rgbMatrixLayerPresenter;
            this.RGBMatrixLayerPresenter.RGBMatrixLayerView = this;
            this.RGBMatrixLayerPresenter.Initialize();
        }

        public RGBMatrixLayerPresenter RGBMatrixLayerPresenter { get; set; }

        public void SendMessage(string message)
        {
            MessageBox.Show(message);
        }

        public double Value00
        {
            get
            {
                return this.GetValue(this.value00TB.Text);
            }
            set
            {
                this.value00TB.Text = this.ValueToString(value);
            }
        }

        public double Value01
        {
            get
            {
                return this.GetValue(this.value01TB.Text);
            }
            set
            {
                this.value01TB.Text = this.ValueToString(value);
            }
        }

        public double Value02
        {
            get
            {
                return this.GetValue(this.value02TB.Text);
            }
            set
            {
                this.value02TB.Text = this.ValueToString(value);
            }
        }

        public double Value10
        {
            get
            {
                return this.GetValue(this.value10TB.Text);
            }
            set
            {
                this.value10TB.Text = this.ValueToString(value);
            }
        }

        public double Value11
        {
            get
            {
                return this.GetValue(this.value11TB.Text);
            }
            set
            {
                this.value11TB.Text = this.ValueToString(value);
            }
        }

        public double Value12
        {
            get
            {
                return this.GetValue(this.value12TB.Text);
            }
            set
            {
                this.value12TB.Text = this.ValueToString(value);
            }
        }

        public double Value20
        {
            get
            {
                return this.GetValue(this.value20TB.Text);
            }
            set
            {
                this.value20TB.Text = this.ValueToString(value);
            }
        }

        public double Value21
        {
            get
            {
                return this.GetValue(this.value21TB.Text);
            }
            set
            {
                this.value21TB.Text = this.ValueToString(value);
            }
        }

        public double Value22
        {
            get
            {
                return this.GetValue(this.value22TB.Text);
            }
            set
            {
                this.value22TB.Text = this.ValueToString(value);
            }
        }

        private double GetValue(string value)
        {
            try
            {
                return Convert.ToDouble(value);
            }
            catch
            {
                return 0;
            }
        }

        private string ValueToString(double value)
        {
            return value.ToString();
        }

        private void ValueChanged(object sender, EventArgs e)
        {
        }

        private void ValueUp(object sender, KeyEventArgs e)
        {

        }

        private void ValueDown(object sender, KeyEventArgs e)
        {

        }

        private void refreshBT_Click(object sender, EventArgs e)
        {
            this.RGBMatrixLayerPresenter.Refresh();
        }
    }
}

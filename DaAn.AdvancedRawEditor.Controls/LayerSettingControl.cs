using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DaAn.AdvancedRawEditor.Layers;
using DaAn.AdvancedRawEditor.MVP.Views;
using DaAn.AdvancedRawEditor.MVP.Presenters;

namespace DaAn.AdvancedRawEditor.Controls
{
    public partial class LayerSettingControl : UserControl, ILayerSettingView
    {
        public LayerSettingControl()
        {
            InitializeComponent();
        }

        public LayerSettingPresenter LayerSettingPresenter
        {
            get;
            set;
        }


        public void Add(object setting)
        {
            this.flowLayoutPanel1.Controls.Add((Control)setting);
        }
    }
}

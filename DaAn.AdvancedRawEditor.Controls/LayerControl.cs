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

namespace DaAn.AdvancedRawEditor.Controls
{
    public partial class LayerControl : UserControl
    {
        private ILayer layer;

        public LayerControl()
        {
            InitializeComponent();
        }
    }
}

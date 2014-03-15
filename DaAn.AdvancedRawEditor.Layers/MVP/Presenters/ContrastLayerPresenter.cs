using DaAn.AdvancedRawEditor.Layers.EffectLayers;
using DaAn.AdvancedRawEditor.Layers.MVP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.MVP.Presenters
{
    public class ContrastLayerPresenter
    {
        private ContrastLayer contrastLayer;

        public ContrastLayerPresenter(ContrastLayer contrastLayer)
        {
            this.contrastLayer = contrastLayer;
        }

        public IContrastLayerView ContrastLayerView { get; set; }

        public void Initialize()
        {
        }

        public double Contrast
        {
            get
            {
                return this.contrastLayer.Contrast;
            }
            set
            {
                this.contrastLayer.Contrast = value;
            }
        }
    }
}

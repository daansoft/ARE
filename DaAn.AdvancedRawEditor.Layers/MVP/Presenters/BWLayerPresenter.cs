using DaAn.AdvancedRawEditor.Layers.EffectLayers;
using DaAn.AdvancedRawEditor.Layers.MVP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.MVP.Presenters
{
    public class BWLayerPresenter
    {
        private BWLayer bwLayer;

        public BWLayerPresenter(BWLayer bwLayer)
        {
            this.bwLayer = bwLayer;
        }

        public IBWLayerView BWLayerView { get; set; }

        public void Initialize()
        {
        }

        public double RFactor
        {
            get
            {
                return this.bwLayer.RFactor;
            }
            set
            {
                this.bwLayer.RFactor = value;
            }
        }

        public double GFactor
        {
            get
            {
                return this.bwLayer.GFactor;
            }
            set
            {
                this.bwLayer.GFactor = value;
            }
        }

        public double BFactor
        {
            get
            {
                return this.bwLayer.BFactor;
            }
            set
            {
                this.bwLayer.BFactor = value;
            }
        }
    }
}

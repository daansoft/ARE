using DaAn.AdvancedRawEditor.Layers.MVP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.EffectLayers
{
    public class BWLayer : Layer
    {
        private double _RFactor;
        private double _GFactor;
        private double _BFactor;

        public BWLayer(Guid identificator, double rFactor, double gFactor, double bFactor)
            : base(identificator, 1)
        {
            this.RFactor = rFactor;
            this.GFactor = gFactor;
            this.BFactor = bFactor;
        }

        public BWLayer(Guid identificator)
            : this(identificator, 1.0, 1.0, 1.0)
        {
        }

        public double RFactor
        {
            get
            {
                return this._RFactor;
            }

            set
            {
                this._RFactor = value;
                this.OnChange();
            }
        }

        public double GFactor
        {
            get
            {
                return this._GFactor;
            }

            set
            {
                this._GFactor = value;
                this.OnChange();
            }
        }



        public double BFactor
        {
            get
            {
                return this._BFactor;
            }

            set
            {
                this._BFactor = value;
                this.OnChange();
            }
        }

        public override PixelColor GetPixelColor(int x, int y)
        {
            var previousValue = this.Layers[0].GetPixelColor(x, y);

            double totalFactor = this._RFactor + this._GFactor + this._BFactor;

            return PixelColor.FromNormalizedV((previousValue.RN * this._RFactor + previousValue.GN * this._GFactor + previousValue.BN * this._BFactor) / totalFactor);
        }

        public override object GetLayerView()
        {
            return LayerMVPSetting.LayerViewFactory.GetBWLayerView(this);
        }
    }
}

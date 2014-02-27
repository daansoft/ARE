using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.EffectLayers
{
    public class WhiteBalanceLayer : Layer
    {
        /*X=0.4124240*R+0.3575790*G+0.1804640*B
Y=0.212656*R+0.715158*G+0.0721856*B
Z=0.0193324*R+0.1191930*G+0.9504440*B*/

        private double _RFactor;
        private double _GFactor;
        private double _BFactor;

        public WhiteBalanceLayer(Guid identificator, double rFactor, double gFactor)
            : base(identificator, 1)
        {
            this.RFactor = rFactor;
            this.GFactor = gFactor;
        }

        public WhiteBalanceLayer(Guid identificator)
            : this(identificator, 1.0, 1.0)
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

        public override PixelColor GetPixelColor(int x, int y)
        {
            var previousValue = this.Layers[0].GetPixelColor(x, y);

            return PixelColor.FromNormalizedRGB(0.95 * previousValue.RN + 0.0 * previousValue.GN + 0.0 * previousValue.BN,
                0.15 * previousValue.RN + 0.80 * previousValue.GN + 0.0 * previousValue.BN,
                0.0 * previousValue.RN + 0.0 * previousValue.GN + 0.95 * previousValue.BN
                );
        }

        public override object GetLayerView()
        {
            throw new NotImplementedException();
        }
    }
}

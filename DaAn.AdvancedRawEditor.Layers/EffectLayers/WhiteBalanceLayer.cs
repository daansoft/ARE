using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.EffectLayers
{
    public class WhiteBalanceLayer : Layer
    {
        private double[][] matrix = new double[][] { 
            new double[]{ 1.0, 0.0, 0.0 }, 
            new double[]{ 0.0, 0.0, 0.0 },
            new double[]{ 0.0, 0.0, 0.0 }
        };
        /*
         * 
        private double[][] matrix = new double[][] { 
            new double[]{ 0.4124240, 0.3575790, 0.1804640 }, 
            new double[]{ 0.212656, 0.715158, 0.0721856 },
            new double[]{ 0.0193324, 0.1191930, 0.9504440 }
        };
         * X=0.4124240*R+0.3575790*G+0.1804640*B
Y=0.212656*R+0.715158*G+0.0721856*B
Z=0.0193324*R+0.1191930*G+0.9504440*B*/

        public WhiteBalanceLayer(Guid identificator)
            : base(identificator, 1)
        {
        }

        public override PixelColor GetPixelColor(int x, int y)
        {
            var previousValue = this.Layers[0].GetPixelColor(x, y);

            /*return PixelColor.FromNormalizedRGB(this.matrix[0][0] * previousValue.RN + this.matrix[0][1] * previousValue.GN + this.matrix[0][2] * previousValue.BN,
                this.matrix[1][0] * previousValue.RN + this.matrix[1][1] * previousValue.GN + this.matrix[1][2] * previousValue.BN,
                this.matrix[2][0] * previousValue.RN + this.matrix[2][1] * previousValue.GN + this.matrix[2][2] * previousValue.BN
                );*/

            return PixelColor.FromNormalizedRGB(1, 0, 0);
        }

        public override object GetLayerView()
        {
            //throw new NotImplementedException();
            return null;
        }
    }
}

using DaAn.AdvancedRawEditor.Layers.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.EffectLayers
{
    public class RGBMatrixLayer : Layer
    {
        private Matrix _matrix;

        public RGBMatrixLayer(Guid identificator, Matrix matrix)
            : base(identificator, 1)
        {
            this.Matrix = matrix;
        }

        public RGBMatrixLayer(Guid identificator)
            : this(identificator, Matrix.Ones(3))
        {
        }

        public Matrix Matrix
        {
            get
            {
                return this._matrix;
            }

            set
            {
                this._matrix = value;
                this.OnChange();
            }
        }

        public override PixelColor GetPixelColor(int x, int y)
        {
            var previousValue = this.Layers[0].GetPixelColor(x, y);

            return PixelColor.FromNormalizedRGB(this._matrix.Get(0, 0) * previousValue.RN + this._matrix.Get(0, 1) * previousValue.GN + this._matrix.Get(0, 2) * previousValue.BN,
                this._matrix.Get(1, 0) * previousValue.RN + this._matrix.Get(1, 1) * previousValue.GN + this._matrix.Get(1, 2) * previousValue.BN,
                this._matrix.Get(2, 0) * previousValue.RN + this._matrix.Get(2, 1) * previousValue.GN + this._matrix.Get(2, 2) * previousValue.BN
                );
        }

        public override object GetLayerView()
        {
            throw new NotImplementedException();
        }
    }
}

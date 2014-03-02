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
            this._matrix.Set(0, 0, 0.6);
            this._matrix.Set(1, 1, 0.8);
            this._matrix.Set(2, 2, 1.0);
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
            //return PixelColor.FromNormalizedRGB(0.5, 0, 0);
            return PixelColor.FromNormalizedRGB(this._matrix.Get(0, 0) * previousValue.R + this._matrix.Get(0, 1) * previousValue.G + this._matrix.Get(0, 2) * previousValue.B,
                this._matrix.Get(1, 0) * previousValue.R + this._matrix.Get(1, 1) * previousValue.G + this._matrix.Get(1, 2) * previousValue.B,
                this._matrix.Get(2, 0) * previousValue.R + this._matrix.Get(2, 1) * previousValue.G + this._matrix.Get(2, 2) * previousValue.B
                );
        }

        public override object GetLayerView()
        {
            return null;
        }
    }
}

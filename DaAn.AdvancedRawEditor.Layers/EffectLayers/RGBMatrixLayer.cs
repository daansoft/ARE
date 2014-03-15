using DaAn.AdvancedRawEditor.Layers.MVP;
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
            this._matrix = matrix;
            this.OnChange();
        }

        public RGBMatrixLayer(Guid identificator)
            : this(identificator, Matrix.Ones(3))
        {
        }

        public double Get(int x, int y)
        {
            return this._matrix[x][y];
        }

        public void Set(int x, int y, double value)
        {
            this._matrix[x][y] = value;
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
            return LayerMVPSetting.LayerViewFactory.GetRGBMatrixLayerView(this);
        }
    }
}

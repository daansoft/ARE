using System;

namespace DaAn.AdvancedRawEditor.Layers.EffectLayers
{
    public class ContrastLayer : Layer
    {
        public double _contrast;

        public ContrastLayer(Guid identificator, double contrast)
            : base(identificator, 1)
        {
            this.Contrast = contrast;
        }


        public double Contrast
        {
            get
            {
                return this._contrast;
            }

            set
            {
                this._contrast = value;
                this.OnChange();
            }
        }

        public override PixelColor GetPixelColor(int x, int y)
        {
            var previousValue = this.Layers[0].GetPixelColor(x, y);

            return PixelColor.FromNormalizedRGB(((previousValue.RN - 0.5) * this._contrast) + 0.5,
                ((previousValue.GN - 0.5) * this._contrast) + 0.5,
                ((previousValue.BN - 0.5) * this._contrast) + 0.5);
        }
    }
}

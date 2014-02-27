using System;

namespace DaAn.AdvancedRawEditor.Layers.EffectLayers
{
    public class InvertLayer : Layer
    {
        public InvertLayer(Guid identificator)
            : base(identificator, 1)
        {
        }

        public override PixelColor GetPixelColor(int x, int y)
        {
            var previousValue = this.Layers[0].GetPixelColor(x, y);

            return PixelColor.FromNormalizedRGB(-previousValue.RN + 1.0, -previousValue.GN + 1.0, -previousValue.BN + 1.0);
        }

        public override object GetLayerView()
        {
            throw new NotImplementedException();
        }
    }
}

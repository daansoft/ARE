﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.EffectLayers
{
    public class BrightnessLayer : Layer
    {
        public double _brightness;

        public BrightnessLayer(Guid identificator, double brightness)
            : base(identificator, 1)
        {
            this.Brightness = brightness;
        }

        public double Brightness
        {
            get
            {
                return this._brightness;
            }

            set
            {
                this._brightness = value;
                this.OnChange();
            }
        }

        public override PixelColor GetPixelColor(int x, int y)
        {
            var previousValue = this.Layers[0].GetPixelColor(x, y);

            return PixelColor.FromNormalizedRGB(previousValue.RN * this._brightness,
                previousValue.GN * this._brightness,
                previousValue.BN * this._brightness);
        }
    }
}

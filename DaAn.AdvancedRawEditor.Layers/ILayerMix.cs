﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public interface ILayerMix
    {
        PixelValue GetValue(PixelValue pl, PixelValue pr);
    }
}

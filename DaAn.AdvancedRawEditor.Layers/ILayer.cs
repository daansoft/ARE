using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public interface ILayer
    {
        int Width { get; }
        int Height { get; }
        string Name { get; set; }

        PixelValue GetPixelColor(int x, int y);
    }
}

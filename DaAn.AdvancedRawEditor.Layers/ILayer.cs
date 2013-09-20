using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public interface ILayer
    {
        int GetWidth();
        int GetHeigth();

        void Delete();
        void DeleteSubLayer(Layer layer);

        AddLayerMethod[] GetAddLayerMethods();
        void After(Layer layer);
        void Wrap(Layer beginLayer, Layer endLayer);
        void Add(Layer beginLayer, Layer endLayer);

        PixelValue GetPixelValue(int x, int y);
        string GetName();
    }
}

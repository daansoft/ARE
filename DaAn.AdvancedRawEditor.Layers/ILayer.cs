using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public interface ILayer
    {
        ILayer PreviousLayer { get; set; }
        ILayer NextLayer { get; set; }
        PixelValue GetPixelValue(int x, int y);
        void Initialize();
        int GetWidth();
        int GetHeigth();
        void AddLayer(ILayer layer, AddLayerMethod method);
        AddLayerMethod[] GetAddLayerMethods();
        void DeleteCurrentLayer();
        string GetName();
    }
}

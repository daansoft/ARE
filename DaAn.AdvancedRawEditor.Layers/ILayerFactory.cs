using DaAn.AdvancedRawEditor.Layers.FileLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public interface ILayerFactory
    {
        JpgFileLayer CreateJpgFileLayer(Guid identificator, string fileName);

    }
}

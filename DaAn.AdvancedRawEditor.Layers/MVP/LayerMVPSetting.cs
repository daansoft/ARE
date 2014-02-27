using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.MVP
{
    public class LayerMVPSetting
    {
        public static LayerPresenterFactory LayerPresenterFactory;
        public static ILayerViewFactory LayerViewFactory;

        static LayerMVPSetting()
        {
            LayerMVPSetting.LayerPresenterFactory = new LayerPresenterFactory();
        }
    }
}

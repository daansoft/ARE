using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public class GroupSubLayer : Layer
    {
        private GroupLayer GroupLayer;

        public override PixelValue GetPixelValue(int x, int y)
        {
            var parentValue = this.GroupLayer.PreviousLayer.GetPixelValue(x, y);

            throw new NotImplementedException();
        }

        public override void Initialize()
        {
        }

        public override string GetName()
        {
            return "";// string.Format("[Group layer for {0}]", string.Join(", ", this.Layers.Select(r => r.GetName())));
        }
    }
}

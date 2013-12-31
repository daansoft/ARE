using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public abstract class TwoInputLayer : ILayer
    {
        public ILayer FirstInputLayer
        {
            get;
            set;
        }

        public ILayer SecondInputLayer
        {
            get;
            set;
        }

        public int Width
        {
            get
            {
                return this.FirstInputLayer.Width;
            }
        }

        public int Height
        {
            get
            {
                return this.FirstInputLayer.Height;
            }
        }

        public string Name
        {
            get;
            set;
        }

        public abstract PixelValue GetPixelValue(int x, int y);
    }
}

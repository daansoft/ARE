using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public abstract class OneInputLayer : ILayer
    {
        public ILayer InputLayer
        {
            get;
            set;
        }

        public virtual int Width
        {
            get
            {
                return this.InputLayer.Width;
            }
        }

        public virtual int Height
        {
            get
            {
                return this.InputLayer.Height;
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

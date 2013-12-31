using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public class SourceLayer : ILayer
    {
        protected PixelValue[][] source;
        
        public int Width
        {
            get
            {
                if(this.source == null)
                {
                    return 0;
                }

                return this.source.Length;
            }
        }

        public int Height
        {
            get
            {
                if(this.source == null || !this.source.Any())
                {
                    return 0;
                }

                return this.source[0].Length;
            }
        }

        public string Name
        {
            get;
            set;
        }

        public PixelValue GetPixelValue(int x, int y)
        {
            return this.source[x][y];
        }
    }
}

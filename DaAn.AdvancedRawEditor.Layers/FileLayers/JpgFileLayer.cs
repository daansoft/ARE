﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.FileLayers
{
    public class JpgFileLayer: ILayer
    {
        public ILayer PreviousLayer { get; set; }
        public ILayer NextLayer { get; set; }

        public PixelValue GetPixelValue(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public int GetWidth()
        {
            throw new NotImplementedException();
        }

        public int GetHeigth()
        {
            throw new NotImplementedException();
        }

        public void AddForLayer(ILayer layer)
        {
            throw new NotImplementedException();
        }

        public void DeleteCurrentLayer()
        {
            throw new NotImplementedException();
        }
    }
}

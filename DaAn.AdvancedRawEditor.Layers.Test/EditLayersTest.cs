using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DaAn.AdvancedRawEditor.Layers.FileLayers;
using DaAn.AdvancedRawEditor.Layers.EffectLayers;

namespace DaAn.AdvancedRawEditor.Layers.Test
{
    [TestClass]
    public class EditLayersTest
    {
        [TestMethod]
        public void TestAddLayers()
        {
            Layer start = new JpgFileLayer();

            Layer bw = new BWLayer();

            start.Add(bw, AddLayerMethod.Next);

            Layer group1 = new GroupLayer();

            bw.Add(group1, AddLayerMethod.Next);

            Layer solid = new SolidColorLayer();

            group1.Add(solid, AddLayerMethod.Inside);

            Layer mask = new MaskLayer();

            solid.Add(mask, AddLayerMethod.Wrap);

            Layer mask2 = new MaskLayer();

            mask.Add(mask2, AddLayerMethod.Next);

            Layer bw2 = new BWLayer();

            mask2.Add(bw2, AddLayerMethod.Inside);

        }

        /*[TestMethod]
        public void TestAddLayers2()
        {
            ILayer start = new JpgFileLayer();

            ILayer bwLayer = new BWLayer();

            //Next = After
            bwLayer.Add(AddLayerMethod.After, start);

            ILayer group1 = new GroupLayer();

            group1.Add(AddLayerMethod.After, bwLayer);

            ILayer solid = new SolidColorLayer();

            solid.Add(AddLayerMethod.Inside, group1);

            ILayer mask = new MaskLayer();

            mask.Add(AddLayerMethod.Wrap, solid);


        }*/
    }
}

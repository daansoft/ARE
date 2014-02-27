using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DaAn.AdvancedRawEditor.Layers.FileLayers;
using DaAn.AdvancedRawEditor.Layers.EffectLayers;
using DaAn.AdvancedRawEditor.Layers.Layers;

namespace DaAn.AdvancedRawEditor.Layers.Test
{
    [TestClass]
    public class CreateLayersTest
    {
        [TestMethod]
        public void TestJpgFileLayer()
        {
            Layer jpgFileLayer = new JpgFileLayer(new Guid("00000000-0000-0000-0000-000000000005"), "../../test.jpg");

            Assert.AreEqual(2280, jpgFileLayer.Width);
            Assert.AreEqual(1520, jpgFileLayer.Height);

            Assert.IsNotNull(jpgFileLayer.GetPixelColor(100, 100));
        }

        [TestMethod]
        public void TestBWLayer()
        {
            Layer jpgFileLayer = new JpgFileLayer(new Guid("00000000-0000-0000-0000-000000000005"), "../../test.jpg");

            BWLayer bwLayer = new BWLayer(new Guid("00000000-0000-0000-0000-000000000006"));

            bwLayer.Layers[0] = jpgFileLayer;

            var actual = bwLayer.GetPixelColor(610, 600);

            Assert.AreEqual(23, actual.R);
            Assert.AreEqual(23, actual.G);
            Assert.AreEqual(23, actual.B);

        }

        [TestMethod]
        public void TestCacheLayer()
        {
            Layer jpgFileLayer = new JpgFileLayer(new Guid("00000000-0000-0000-0000-000000000005"), "../../test.jpg");

            CacheLayer cacheLayer = new CacheLayer(new Guid("00000000-0000-0000-0000-000000000006"));

            cacheLayer.Layers[0] = jpgFileLayer;
            cacheLayer.Initialize();
            cacheLayer.RefreshCache();

            var actual = cacheLayer.GetPixelColor(2279, 1519);

            Assert.AreEqual(47, actual.R);
            Assert.AreEqual(47, actual.G);
            Assert.AreEqual(47, actual.B);

        }
    }
}

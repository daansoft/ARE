using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DaAn.AdvancedRawEditor.Layers.FileLayers;
using DaAn.AdvancedRawEditor.Layers.EffectLayers;

namespace DaAn.AdvancedRawEditor.Layers.Test
{
    [TestClass]
    public class CreateLayersTest
    {
        [TestMethod]
        public void TestJpgFileLayer()
        {
            ILayer jpgFileLayer = new JpgFileLayer("../../test.jpg");

            Assert.AreEqual(2280, jpgFileLayer.Width);
            Assert.AreEqual(1520, jpgFileLayer.Height);

            Assert.IsNotNull(jpgFileLayer.GetPixelValue(100, 100));
        }

        [TestMethod]
        public void TestBWLayer()
        {
            ILayer jpgFileLayer = new JpgFileLayer("../../test.jpg");

            BWLayer bwLayer = new BWLayer();

            bwLayer.InputLayer = jpgFileLayer;

            var actual = bwLayer.GetPixelValue(610, 600);

            Assert.AreEqual(23, actual.R);
            Assert.AreEqual(23, actual.G);
            Assert.AreEqual(23, actual.B);

        }

        [TestMethod]
        public void TestCacheLayer()
        {
            ILayer jpgFileLayer = new JpgFileLayer("../../test.jpg");

            CacheLayer cacheLayer = new CacheLayer();

            cacheLayer.InputLayer = jpgFileLayer;
            cacheLayer.Initialize();
            cacheLayer.RefreshCache();

            var actual = cacheLayer.GetPixelValue(2279, 1519);

            Assert.AreEqual(47, actual.R);
            Assert.AreEqual(47, actual.G);
            Assert.AreEqual(47, actual.B);

        }
    }
}

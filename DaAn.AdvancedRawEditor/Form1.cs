using DaAn.AdvancedRawEditor.Layers;
using DaAn.AdvancedRawEditor.Layers.EffectLayers;
using DaAn.AdvancedRawEditor.Layers.FileLayers;
using DaAn.AdvancedRawEditor.Layers.MixLayerMethods;
using System.Windows.Forms;

namespace DaAn.AdvancedRawEditor
{
    public partial class Form1 : Form
    {
        ILayer file;

        public Form1()
        {
            InitializeComponent();

            ILayer jpgFileLayer = new JpgFileLayer("../../test.jpg");

            SamplingLayer samplingLayer = new SamplingLayer(1);
            samplingLayer.InputLayer = jpgFileLayer;

            CacheLayer cacheLayer = new CacheLayer();
            cacheLayer.InputLayer = samplingLayer;
            cacheLayer.Initialize();
            cacheLayer.RefreshCache();

            file = cacheLayer;

            /*BWLayer bwLayer = new BWLayer();

            bwLayer.InputLayer = cacheLayer;

            MixLayer mixLayer = new MixLayer();

            mixLayer.MixMethod = new AvarageMixLayerMethod();
            mixLayer.FirstInputLayer = bwLayer;
            mixLayer.SecondInputLayer = cacheLayer;

            MixLayer mixLayer2 = new MixLayer();

            mixLayer2.MixMethod = new AvarageMixLayerMethod();
            mixLayer2.FirstInputLayer = mixLayer;
            mixLayer2.SecondInputLayer = new BrightnessLayer(1.2) { InputLayer = cacheLayer };

            BrightnessLayer brightnessLayer = new BrightnessLayer(0.9) { InputLayer = bwLayer };

            CacheLayer cacheLayer2 = new CacheLayer();

            cacheLayer2.InputLayer = brightnessLayer;
            cacheLayer2.Initialize();
            cacheLayer2.RefreshCache();

            this.renderLayer = new RenderLayer(cacheLayer2);

            this.renderLayer.GetImage().Save("testttt.jpg");*/
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //this.renderLayer.Render(e.Graphics);
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            SamplingLayer samplingLayer = new SamplingLayer(0.5);

            samplingLayer.InputLayer = this.file;

            BWLayer bwLayer = new BWLayer();

            bwLayer.InputLayer = samplingLayer;

            BrightnessLayer brightnessLayer = new BrightnessLayer(0.9);

            brightnessLayer.InputLayer = bwLayer;

            RenderLayer renderLayer = new RenderLayer(brightnessLayer);

            renderLayer.GetImage().Save("testttt.jpg");
        }
    }
}

using DaAn.AdvancedRawEditor.Layers;
using DaAn.AdvancedRawEditor.Layers.EffectLayers;
using DaAn.AdvancedRawEditor.Layers.FileLayers;
using DaAn.AdvancedRawEditor.Layers.MixLayerMethods;
using System.Windows.Forms;

namespace DaAn.AdvancedRawEditor
{
    public partial class Form1 : Form
    {
        RenderLayer renderLayer;

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

            BWLayer bwLayer = new BWLayer();

            bwLayer.InputLayer = cacheLayer;

            MixLayer mixLayer = new MixLayer();

            mixLayer.MixMethod = new AvarageMixLayerMethod();
            mixLayer.FirstInputLayer = bwLayer;
            mixLayer.SecondInputLayer = cacheLayer;

            this.renderLayer = new RenderLayer(mixLayer);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            this.renderLayer.Render(e.Graphics);
        }
    }
}

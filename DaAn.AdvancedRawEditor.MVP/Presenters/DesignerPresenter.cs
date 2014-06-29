using DaAn.AdvancedRawEditor.Layers;
using DaAn.AdvancedRawEditor.Layers.EffectLayers;
using DaAn.AdvancedRawEditor.Layers.FileLayers;
using DaAn.AdvancedRawEditor.Layers.Layers;
using DaAn.AdvancedRawEditor.Layers.Tools;
using DaAn.AdvancedRawEditor.MVP.Views;
using System;
using System.Drawing;

namespace DaAn.AdvancedRawEditor.MVP.Presenters
{
    public class DesignerPresenter
    {
        private LayerCollection layerCollection;

        public IDesignerView DesignerView { get; set; }

        public void Initialize()
        {
            this.layerCollection = new LayerCollection();

            //this.layerCollection.Select += layerCollection_Select;
            this.layerCollection.Change += layerCollection_Change;

            layerCollection.Add(new JpgFileLayer(new Guid("00000000-0000-0000-0000-000000000000"), "test.jpg"));
            layerCollection.Add(new SamplingLayer(new Guid("00000000-0000-0000-0000-000000000001"), 1000, 1000));
            //layerCollection.Add(new ExposureLayer(new Guid("00000000-0000-0000-0000-000000000001"), 0));
            layerCollection.Add(new CacheLayer(new Guid("00000000-0000-0000-0000-000000000002")));
            //layerCollection.Add(new SolidColorLayer(new Guid("00000000-0000-0000-0000-000000000017")) { Color = PixelColor.FromNormalizedRGB(2, 0, 0) });
            layerCollection.Add(new ExposureLayer(new Guid("00000000-0000-0000-0000-000000000017"), 0.0));
            layerCollection.Add(new ContrastLayer(new Guid("00000000-0000-0000-0000-000000000018"), 1.0));
            layerCollection.Add(new LevelsLayer(new Guid("00000000-0000-0000-0000-000000000050")) { Blacks = -0.0, Whites = 0.0 });
            layerCollection.Add(new CurvesLayer(new Guid("00000000-0000-0000-0000-000000000019")) { Enabled = false });


            layerCollection.Connect(new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001"), 0);
            layerCollection.Connect(new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000002"), 0);
            layerCollection.Connect(new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000017"), 0);
            layerCollection.Connect(new Guid("00000000-0000-0000-0000-000000000017"), new Guid("00000000-0000-0000-0000-000000000018"), 0);
            layerCollection.Connect(new Guid("00000000-0000-0000-0000-000000000018"), new Guid("00000000-0000-0000-0000-000000000050"), 0);
            layerCollection.Connect(new Guid("00000000-0000-0000-0000-000000000050"), new Guid("00000000-0000-0000-0000-000000000019"), 0);

            layerCollection.SetOutputLayer(new Guid("00000000-0000-0000-0000-000000000019"));
            layerCollection.SetSelectedLayer(new Guid("00000000-0000-0000-0000-000000000019"));

            this.DesignerView.SetSelectedLayers(this.layerCollection.Layers);

        }

        void layerCollection_Change(object sender, EventArgs e)
        {
            this.DesignerView.RefreshImageView();
        }

        private void layerCollection_Select(object sender, EventArgs e)
        {
            this.DesignerView.SetSelectedLayer(this.layerCollection.SelectedLayer);
        }

        public Image GetOutputImage()
        {
            RenderLayer renderLayer = new RenderLayer(this.layerCollection.OutputLayer);
            return renderLayer.GetImage();
        }

        public void SaveImage()
        {
            var date1 = DateTime.UtcNow;

            RenderLayer renderLayer = new RenderLayer(this.layerCollection.OutputLayer);
            renderLayer.GetImage().Save(DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".jpg");

            this.DesignerView.SendMessage((DateTime.UtcNow - date1).ToString());
        }
    }
}

using DaAn.AdvancedRawEditor.Layers;
using DaAn.AdvancedRawEditor.Layers.EffectLayers;
using DaAn.AdvancedRawEditor.Layers.FileLayers;
using DaAn.AdvancedRawEditor.Layers.MixLayerMethods;
using DaAn.AdvancedRawEditor.Layers.Tools;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DaAn.AdvancedRawEditor
{
    public partial class Main : Form
    {
        LayerCollection layerCollection;



        public Main()
        {
            InitializeComponent();

            this.layerCollection = new LayerCollection();

            layerCollection.Add(new JpgFileLayer(new Guid("00000000-0000-0000-0000-000000000000"), "../../test.jpg"));
            layerCollection.Add(new SamplingLayer(new Guid("00000000-0000-0000-0000-000000000001"), 0.25));
            layerCollection.Add(new ExposureLayer(new Guid("00000000-0000-0000-0000-000000000017"), 1.0));
            layerCollection.Add(new ContrastLayer(new Guid("00000000-0000-0000-0000-000000000018"), 0.0));
            layerCollection.Add(new BWLayer(new Guid("00000000-0000-0000-0000-000000000050")));
            layerCollection.Add(new CurvesLayer(new Guid("00000000-0000-0000-0000-000000000019")));


            layerCollection.Connect(new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001"), 0);
            layerCollection.Connect(new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000017"), 0);
            //layerCollection.Connect(new Guid("00000000-0000-0000-0000-000000000017"), new Guid("00000000-0000-0000-0000-000000000018"), 0);
            layerCollection.Connect(new Guid("00000000-0000-0000-0000-000000000017"), new Guid("00000000-0000-0000-0000-000000000050"), 0);
            layerCollection.Connect(new Guid("00000000-0000-0000-0000-000000000050"), new Guid("00000000-0000-0000-0000-000000000019"), 0);

            /*CacheLayer cacheLayer = new CacheLayer(new Guid("00000000-0000-0000-0000-000000000002"));

            layerCollection.Add(cacheLayer);

            layerCollection.Connect(new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001"), 0);
            layerCollection.Connect(new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000002"), 0);


            cacheLayer.Initialize();
            cacheLayer.RefreshCache();

            layerCollection.Add(new SamplingLayer(new Guid("00000000-0000-0000-0000-000000000005"), 1));
            layerCollection.Add(new BWLayer(new Guid("00000000-0000-0000-0000-000000000006"), 2, 1, 0.5));
            layerCollection.Add(new BrightnessLayer(new Guid("00000000-0000-0000-0000-000000000007"), 0.50));
            layerCollection.Add(new MixLayer(new Guid("00000000-0000-0000-0000-000000000008")) { MixLayerMethod = new MultipleMixLayerMethod() });
            layerCollection.Add(new MixLayer(new Guid("00000000-0000-0000-0000-000000000009")) { MixLayerMethod = new WeightedAverageMixLayerMethod(0.3) });

            layerCollection.Add(new SaturationLayer(new Guid("00000000-0000-0000-0000-000000000010"), 1.5));


            layerCollection.Connect(new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000005"), 0);
            layerCollection.Connect(new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000007"), 0);
            //layerCollection.Connect(new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000006"), 0);
            //layerCollection.Connect(new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000007"), 0);

            layerCollection.Connect(new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000008"), 0);
            layerCollection.Connect(new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000008"), 1);

            layerCollection.Connect(new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000009"), 0);
            layerCollection.Connect(new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000009"), 1);


            layerCollection.Connect(new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000010"), 0);*/

            layerCollection.SetOutputLayer(new Guid("00000000-0000-0000-0000-000000000019"));
            layerCollection.SetSelectedLayer(new Guid("00000000-0000-0000-0000-000000000017"));

        }

        public static double getValue(double[] p, double x)
        {
            return p[1] + 0.5 * x * (p[2] - p[0] + x * (2.0 * p[0] - 5.0 * p[1] + 4.0 * p[2] - p[3] + x * (3.0 * (p[1] - p[2]) + p[3] - p[0])));
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                BezierCurves bc = new BezierCurves();

                /*bc.Add(BezierCurvePoint.CreateFull(DaAn.AdvancedRawEditor.Layers.Tools.Point.Create(0.4, 0.7),
                    DaAn.AdvancedRawEditor.Layers.Tools.Point.Create(0.3, 0.8),
                    DaAn.AdvancedRawEditor.Layers.Tools.Point.Create(0.6, 0.8),
                    0,
                    0));*/

                Splains s = new Splains(new double[] { -1.0, -0.3, 0.3, 0.4, 0.5, 0.7, 2.0 }, new double[] { -0.25, 0.0, 0.3, 0.3, 0.3, 1.0, 1.25 });

                for (double i = -1; i <= 2; i += 0.01)
                {
                    //e.Graphics.DrawEllipse(Pens.Black, 199 + (int)(i * 300), 399 + (int)(-bc.Calculate(i) * 300), 2, 2);
                    //e.Graphics.DrawEllipse(Pens.Black, 199 + (int)(i * 300), 399 + (int)(-getValue(new double[] { 0, 0.0, 0.8, 0.9 }, i) * 300), 2, 2);
                    //e.Graphics.DrawEllipse(Pens.Black, 199 + (int)(i * 200), 399 + (int)(-s.eval(i, new double[] { -0.0, 0.8, 1.0, 1.1, 1.3, 1.4, 1.9, 2.0 }, new double[] { 0, 0.0, 0.8, 0.8, 1.0, 1.5, 1.0, 0.9 }) * 200), 2, 2);
                    e.Graphics.DrawEllipse(Pens.Black, 199 + (int)(i * 200), 399 + (int)(-s.EvalSpline(i) * 200), 2, 2);

                }


                /*e.Graphics.DrawEllipse(Pens.Red, 190 + (int)(bc.First.PL.X * 300), 390 + (int)(-bc.First.PL.Y * 300), 20, 20);
                e.Graphics.DrawEllipse(Pens.Red, 190 + (int)(bc.First.PP.X * 300), 390 + (int)(-bc.First.PP.Y * 300), 20, 20);
                e.Graphics.DrawEllipse(Pens.Red, 190 + (int)(bc.Last.PL.X * 300), 390 + (int)(-bc.Last.PL.Y * 300), 20, 20);
                e.Graphics.DrawEllipse(Pens.Red, 190 + (int)(bc.Last.PP.X * 300), 390 + (int)(-bc.Last.PP.Y * 300), 20, 20);*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, System.EventArgs e)
        {

            RenderLayer renderLayer = new RenderLayer(layerCollection.OutputLayer);

            renderLayer.GetImage().Save("testttt.jpg");

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            ExposureLayer layer = layerCollection.SelectedLayer as ExposureLayer;

            layer.Exposure = this.trackBar1.Value / 100.0;

            label1.Text = layer.Exposure.ToString();

            /*ContrastLayer layer = layerCollection.SelectedLayer as ContrastLayer;

            layer.Contrast = this.trackBar1.Value / 100.0;

            label1.Text = layer.Contrast.ToString();

            CurvesLayer layer = layerCollection.SelectedLayer as CurvesLayer;

            layer.Factor = this.trackBar1.Value / 10.0;
            layer.Factor2 = this.trackBar2.Value / 100.0;

            label1.Text = layer.Factor.ToString() + " " + layer.Factor2.ToString();*/
        }
    }
}

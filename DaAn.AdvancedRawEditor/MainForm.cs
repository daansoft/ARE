using DaAn.AdvancedRawEditor.Controls;
using DaAn.AdvancedRawEditor.Layers;
using DaAn.AdvancedRawEditor.Layers.EffectLayers;
using DaAn.AdvancedRawEditor.Layers.FileLayers;
using DaAn.AdvancedRawEditor.Layers.MixLayerMethods;
using DaAn.AdvancedRawEditor.Layers.Tools;
using DaAn.AdvancedRawEditor.MVP.Presenters;
using DaAn.AdvancedRawEditor.MVP.Views;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DaAn.AdvancedRawEditor
{
    public partial class MainForm : Form, IMainView, IDesignerView
    {
        public MainForm(MainPresenter mainPresenter, DesignerPresenter designerPresenter, LayerSettingPresenter layerSettingPresenter)
        {
            InitializeComponent();

            this.MainPresenter = mainPresenter;
            this.MainPresenter.MainView = this;

            this.LayerSettingPresenter = layerSettingPresenter;
            this.LayerSettingPresenter.LayerSettingView = this.layerC;

            this.DesignerPresenter = designerPresenter;
            this.DesignerPresenter.DesignerView = this;
            this.DesignerPresenter.Initialize();

        }

        public MainPresenter MainPresenter { get; set; }
        public DesignerPresenter DesignerPresenter { get; set; }
        public LayerSettingPresenter LayerSettingPresenter { get; set; }

        private void button1_Click(object sender, System.EventArgs e)
        {
            this.DesignerPresenter.SaveImage();

        }

        public void ShowView()
        {
            this.Show();
        }

        public void SendMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void imageViewC_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                e.Graphics.DrawImage(this.DesignerPresenter.GetOutputImage(), 0, 0);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        public void SetSelectedLayer(Layer layer)
        {
            this.LayerSettingPresenter.SetLayerView(layer);
        }


        public void RefreshImageView()
        {
            this.imageViewC.Refresh();
        }
    }
}

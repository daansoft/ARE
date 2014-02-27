using DaAn.AdvancedRawEditor.Controls;
using DaAn.AdvancedRawEditor.Layers.MVP;
using DaAn.AdvancedRawEditor.MVP;
using DaAn.AdvancedRawEditor.MVP.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaAn.AdvancedRawEditor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MVPSetting.PresenterFactory.ViewFactory = new WinFormsViewFactory();

            LayerMVPSetting.LayerViewFactory = new ControlLayerViewFactory();

            MainForm form = new MainForm(MVPSetting.PresenterFactory.GetMainPresenter(),
                MVPSetting.PresenterFactory.GetDesignerPresenter(),
                MVPSetting.PresenterFactory.GetLayerSettingPresenter());
            Application.Run(form);
        }
    }
}

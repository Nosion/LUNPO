using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using LUNPO.Framework;
using LUNPO.View;
using LUNPO.ViewModel;
using PluginContracts;
using Utils;
namespace LUNPO
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            PluginInit pluginInit = new PluginInit();

            TextViewModel textViewModel = new TextViewModel(pluginInit.Plugins);

            var window = new MainWindow
            {
                DataContext = textViewModel
            };

            window.ShowDialog();
        }
    }
}

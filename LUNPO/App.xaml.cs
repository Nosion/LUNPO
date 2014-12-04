using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using LUNPO.View;
using LUNPO.ViewModel;

namespace LUNPO
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var window = new MainWindow
            {
                DataContext = new TextViewModel()
            };

            window.ShowDialog();
        }
    }
}

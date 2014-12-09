using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using PluginContracts;
using Utils;


namespace SecondPlugin
{


    public class AutoSavePlugin : IPlugin
    {
        private static double autosaveInterval;

        public string Name
        {
            get
            {
                return "Second Plugin";
            }
        }

        public MenuItem MenuItems
        {
            get
            {

                var menu = new MenuItem("AutoSavePlugin");
                menu.Children.Add(new MenuItem("Save to console"));

                return menu;
            }
        }

<<<<<<< HEAD
        DispatcherTimer autosaveTimer = new DispatcherTimer(TimeSpan.FromSeconds(autosaveInterval), DispatcherPriority.Background, new EventHandler(DoAutoSave), MediaTypeNames.Application.Current.Dispatcher);
        

        private void DoAutoSave(object sender, EventArgs e)
        {
            // Enter save logic here...
        }

        public void DoAutoSave()
=======
        public string TextBoxContent { get; set; }

        public void Do()
>>>>>>> 7b54678422f1d2a87feab203b92c36d31686e587
        {
            Console.WriteLine("Do Something in Second Plugin");
        }
    }
}

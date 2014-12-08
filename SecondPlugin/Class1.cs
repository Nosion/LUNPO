using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PluginContracts;
using Utils;


namespace SecondPlugin
{


    public class SecondPlugin : IPlugin
    {
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

                var menu = new MenuItem("SecondPlugin");
                menu.Children.Add(new MenuItem("Write to console"));

                return menu;
            }
        }

        public void Do()
        {
            Console.WriteLine("Do Something in Second Plugin");
        }
    }
}

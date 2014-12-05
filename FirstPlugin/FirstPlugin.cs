using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PluginContracts;
using Utils;


namespace FirstPlugin
{
  

        public class FirstPlugin : IPlugin
        {
            public string Name
            {
                get
                {
                    return "First Plugin";
                }
            }

            public MenuItem MenuItems
            {
                get
                {

                    var menu = new MenuItem("FirstPlugin");
                    menu.Children.Add(new MenuItem("Write to console"));
                    
                    return menu;
                }
            }

            public void Do()
            {
              Console.WriteLine("Do Something in First Plugin");
            }
        }
}

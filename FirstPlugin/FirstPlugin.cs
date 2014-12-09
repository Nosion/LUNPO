using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PluginContracts;
using Utils;
using Microsoft.Win32;


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
                    DelegateCommand<object> delegateSomething = new DelegateCommand<object>(Do);
                    var menu = new MenuItem("FirstPlugin");
                    MenuItem menuItem = new MenuItem("Write to console");
                    
                    
                    menuItem.Command = delegateSomething;
                    menu.Children.Add(menuItem);
                    return menu;
                }
            }

            public void Do(object obj)
            {
               
              Console.WriteLine("Do Something in First Plugin.");
            }
        }
}
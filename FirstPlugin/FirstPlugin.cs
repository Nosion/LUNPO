using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PluginContracts;
using Utils;
using Microsoft.Win32;
using LUNPO.Model;

namespace FirstPlugin
{

        public class FirstPlugin : IPlugin, INotifyPropertyChanged
        {
            public Text Text { get; private set; }
            public event PropertyChangedEventHandler PropertyChanged;
            protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
            {
                if (Equals(storage, value))
                {
                    return false;
                }

                storage = value;
                this.OnPropertyChanged(propertyName);
                return true;
            }

            protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChangedEventHandler eventHandler = this.PropertyChanged;
                if (eventHandler != null)
                {
                    eventHandler(this, new PropertyChangedEventArgs(propertyName));
                }
            }

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

            public string TextBoxContent 
            { 
                get { return textBoxContent; } 
                set 
                { 
                    textBoxContent = value;
                    OnPropertyChanged("TextBoxContent");
                } 
            }
            private string textBoxContent;
            public void Do(object obj)
            {
                TextBoxContent = "hej";
              Console.WriteLine("Tester");
            }
        }
}

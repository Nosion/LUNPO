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
using DesktopClient.Model;
using System.IO;
using System.Reflection;


namespace CodeInjectionPlugin
{

    public class CodeTemplatePlugin : IPlugin, INotifyPropertyChanged
        {
            public string SavePath { get; set; }
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
                    return "CodeTemplate Plugin";
                }
            }

            public MenuItem MenuItems
            {
                get
                {
                    DelegateCommand<object> delegateSomething = new DelegateCommand<object>(Do);
                    var menu = new MenuItem("CodeTemplate");
                    MenuItem menuItem = new MenuItem("HTML tags");
                    MenuItem menuitem = new MenuItem("test");
                    
                    
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
                if (TextBoxContent != null)
                {
                    
                }
                else {
                    TextBoxContent = Properties.Resources.testhtml;
                }
                
            }
        }
}

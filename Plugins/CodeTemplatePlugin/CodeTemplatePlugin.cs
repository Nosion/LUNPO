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
            
            private string textBoxContent;
            public string SavePath { get; set; }
            public Text Text { get; private set; }
            public event PropertyChangedEventHandler PropertyChanged;

            // Invoked when adding content to textBoxContent
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

            public void setTextBoxContent(string content, bool update)
            {
                TextBoxContent = content;
                if (update)
                {
                    OnPropertyChanged("TextBoxContent");
                }
            }

            
            // When MenuItems is called, the name is added menuItem so that the pluginLoader read it.
            public MenuItem MenuItems
            {
                get
                {
                    DelegateCommand<object> delegatePluginMenu = new DelegateCommand<object>(Do);
                    var menu = new MenuItem("CodeTemplate");
                    MenuItem menuItem = new MenuItem("HTML tags");
                    MenuItem menuitem = new MenuItem("test");
                    
                    
                    menuItem.Command = delegatePluginMenu;
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
                } 
            }
            
            public void Do(object obj)
            {
                if (!string.IsNullOrEmpty(TextBoxContent))
                {
                    byte[] ascIIBytes = Encoding.ASCII.GetBytes(TextBoxContent);

                    Console.WriteLine("test");

                    foreach(byte b in ascIIBytes){
                        Console.WriteLine("Content in textfield is:" + b + "-End of file");
                    }
                    
                }
                else {
                    setTextBoxContent(Properties.Resources.testhtml, true);
                }
                
            }
        }
}

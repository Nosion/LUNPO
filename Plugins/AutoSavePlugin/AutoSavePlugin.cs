using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Microsoft.Win32;
using PluginContracts;
using Utils;
using DesktopClient.Model;
using DesktopClient.ViewModel;
using System.Threading.Tasks;
using System.Timers;


namespace AutoSavePlugin
{
    public class AutoSave : IPlugin, INotifyPropertyChanged
    {

        private static System.Timers.Timer aTimer;
        public string SavePath { get; set; }
        
        public event PropertyChangedEventHandler PropertyChanged;
        private string textBoxContent;

        // Used to autosave when changes have happend to textboxcontent.
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // The name of the plugin, can be used to eg. list plugins.
        public string Name
        {
            get
            {
                return "AutoSave Plugin";
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

        // Delegate menu method and specifying the menu names.
        public MenuItem MenuItems
        {
            get
            {
                DelegateCommand<object> delegateMenu = new DelegateCommand<object>(AutoTimeSave);
                var menu = new MenuItem("AutoSavePlugin");
                MenuItem menuItem = new MenuItem("Write to console");


                menuItem.Command = delegateMenu;
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

        // Main AutoSave plugin method.
        public void AutoTimeSave(object obj)
        {
            Console.WriteLine(SavePath);
            OnPropertyChanged("TextBoxContent");
            
            if (SavePath != null)
            {
                File.WriteAllText(SavePath, TextBoxContent);
            }

        }


    }
}

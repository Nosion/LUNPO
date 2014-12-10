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
using Client.Model;
using Client.ViewModel;


namespace AutoSavePlugin
{
    public class AutoSave : IPlugin, INotifyPropertyChanged
    {
        public string SavePath { get; set; }
        //public MediaTypeNames.Text Text { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private string textBoxContent;
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
                return "AutoSave Plugin";
            }
        }

        public MenuItem MenuItems
        {
            get
            {
                DelegateCommand<object> delegateSomething = new DelegateCommand<object>(AutoTimeSave);
                var menu = new MenuItem("AutoSavePlugin");
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

        public void AutoTimeSave(object obj)
        {
            Console.WriteLine(SavePath);

            /*if (save.ShowDialog() == true)
            {

                File.WriteAllText(save.FileName, save.FileName);
                //Console.WriteLine(TextViewModel.SavePath);
            }*/
        }


    }
}

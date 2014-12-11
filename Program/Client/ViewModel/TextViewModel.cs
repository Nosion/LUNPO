using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using DesktopClient.Framework;
using DesktopClient.Model;
using Microsoft.Win32;
using PluginContracts;
using Utils;
using System.Collections.ObjectModel;

namespace DesktopClient.ViewModel
{
    public class TextViewModel
    {
        private string savePath;

        //private string textareathing;

        //public string Textareathing
        //{
        //    get { return savePath; }
        //    set
        //    {
        //        // Value equals to filepath, that is set in savefile method.
        //        savePath = value;
        //        foreach (var plugin in plugins)
        //        {
        //            plugin.Value.SavePath = savePath;
        //        }
        //    }
        //}
       

        // Get and set filepath where file is saved.
        public string SavePath
        {
            get { return savePath; }
            set
            {
                // Value equals to filepath, that is set in savefile method.
                savePath = value;
                foreach (var plugin in plugins)
                {
                    plugin.Value.SavePath = savePath;
                }
            }
        }
        
        public Text Text { get; private set; }
        // Declares delegatecommands, this is used to bind UI to ViewModel
        public DelegateCommand<object> SaveAsCommand { get; private set; }
        public DelegateCommand<object> SaveCommand { get; private set; }
        public DelegateCommand<object> OpenCommand { get; private set; }
        // Action delegates - form of method pointers
        public Action<string> ShowMessage;
        public Action<string> SaveAsDlg;
        public Action<string> OpenDlg;

        private Dictionary<string, IPlugin> plugins; 
        
        // Constructer - taking a list of plugins.
        public TextViewModel(Dictionary<string, IPlugin> plugins)
        {
            Text = new Text();
            Text.PropertyChanged += Text_PropertyChanged;
            

            this.plugins = plugins;
            foreach (var plugin in this.plugins)
            {
                plugin.Value.TextBoxContent = this.Text.TextArea;
                plugin.Value.PropertyChanged += Value_PropertyChanged;    
            }

            SaveAsCommand = new DelegateCommand<object>(SaveAsCommandExecute);
            // Cast textarea's string to SaveFile method, using a lambda operator.
            SaveAsDlg = msg => SaveFile(msg);

            // Creating a new deligatecommand to another method, so that we easily can unittext inbetween.
            SaveCommand = new DelegateCommand<object>(SaveCommandExecute);

            OpenCommand = new DelegateCommand<object>(OpenCommandExecute);
            // OpenDlg delegate points to OpenFile method
            OpenDlg = OpenFile;
            
            // Test for showing text in popup-box.
            ShowMessage = msg => MessageBox.Show(msg);
        }

        void Text_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            foreach (var plugin in this.plugins)
            {
                plugin.Value.setTextBoxContent(this.Text.TextArea, false);

                 
            }
        }

        void Value_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Text.TextArea = ((IPlugin)sender).TextBoxContent;
        }

        private void OpenCommandExecute(object obj)
        {
            OpenDlg(Text.TextArea);
        }

        // Popup with an open file dialog windows with .txt file extention as default
        private void OpenFile(object obj)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Text Files(*.txt)|*.txt|All(*.*)|*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string fileName = openFileDialog.FileName;
                Text.TextArea = File.ReadAllText(fileName);

            }
        }


        private void SaveAsCommandExecute(object obj)
        {
            SaveAsDlg(Text.TextArea);
        }

        // Uses the ShowMessage delegate to pass the text from TextArea
        private void SaveCommandExecute(object obj)
        {
            ShowMessage(Text.TextArea);
        }

        // Popup with a save file dialog windows with .txt file extention as default
        private void SaveFile(string msg)
        {

            SaveFileDialog save = new SaveFileDialog()
            {
                Filter = "Text Files(*.txt)|*.txt|All(*.*)|*"
            };
            
            if (save.ShowDialog() == true)
            {
                File.WriteAllText(save.FileName, msg);
                SavePath = save.FileName;
            }
        }
        
        // Add plugin menu names to UI
        public ObservableCollection<MenuItem> MenuItems
        {
            get
            {
                ObservableCollection<Utils.MenuItem> pluginMenuItems = new ObservableCollection<Utils.MenuItem>();

                foreach (var plugin in this.plugins)
                {
                    pluginMenuItems.Add(plugin.Value.MenuItems);
                }

                var menu = new ObservableCollection<MenuItem>();
                foreach (MenuItem pluginMenuItem in pluginMenuItems)
                {
                    menu.Add(pluginMenuItem);
                }

                return menu;
            }
        }
    }
}

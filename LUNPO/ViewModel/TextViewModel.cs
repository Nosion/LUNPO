using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using LUNPO.Framework;
using LUNPO.Model;
using Microsoft.Win32;
using Utils;
using System.Collections.ObjectModel;

namespace LUNPO.ViewModel
{
    public class TextViewModel
    {
        public Text Text { get; private set; }
        public DelegateCommand<object> SaveAsCommand { get; private set; }
        public DelegateCommand<object> SaveCommand { get; private set; }
        public DelegateCommand<object> OpenCommand { get; private set; }
        public Action<string> ShowMessage;
        public Action<string> SaveAsDlg; 
        

        private ObservableCollection<MenuItem> pluginMenuItems; 
        
        public TextViewModel(ObservableCollection<MenuItem> pluginMenuItems)
        {
            Text = new Text();
            this.pluginMenuItems = pluginMenuItems;

            SaveAsCommand = new DelegateCommand<object>(SaveAsCommandExecute);
            SaveCommand = new DelegateCommand<object>(SaveCommandExecute);
            OpenCommand = new DelegateCommand<object>(OpenExecute);
            
            // Test for showing text in popup-box.
            ShowMessage = msg => MessageBox.Show(msg);
            //Save As menu function
            SaveAsDlg = msg => SaveFile(msg);
        }


        private void OpenExecute(object obj)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            Nullable<bool> result = openFileDialog.ShowDialog();

            if (result == true)
            {
                string fileName = openFileDialog.FileName;
                Text.TextArea = File.ReadAllText(fileName);
            }

        }

        private void SaveAsCommandExecute(object obj)
        {
            //ShowMessage(Text.TextArea);
            SaveAsDlg(Text.TextArea);
        }

        private void SaveCommandExecute(object obj)
        {
            ShowMessage(Text.TextArea);
        }

        private void SaveFile(string msg)
        {
            SaveFileDialog save = new SaveFileDialog();
            
            Nullable<bool> result = save.ShowDialog();

            save.DefaultExt = ".txt";
            save.Filter = "Text documents (.txt)|*.txt"; 

            if (result == true)
            {
                File.WriteAllText(save.FileName, msg);
            }
        }


        // Add plugin menu names to UI
        public ObservableCollection<MenuItem> MenuItems
        {
            get
            {
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

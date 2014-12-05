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
        public Action<string> ShowMessage;
        public Action<string> SaveAsDlg; 

        public DelegateCommand<object> SaveCommand { get; private set; }
        private ObservableCollection<MenuItem> pluginMenuItems; 
        public TextViewModel(ObservableCollection<MenuItem> pluginMenuItems)
        {
            this.Text = new Text();
            this.pluginMenuItems = pluginMenuItems;

            SaveAsCommand = new DelegateCommand<object>(SaveAsCommandExecute);
            ShowMessage = (Action<string>)(msg => MessageBox.Show(msg));
            SaveAsDlg = (Action<string>) (msg => SaveFile(msg));

            SaveCommand = new DelegateCommand<object>(SaveCommandExecute);
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

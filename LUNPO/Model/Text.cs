using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LUNPO.Framework;

namespace LUNPO.Model
{
   public class Text : ObservableObject
    {
        private string _textArea;

        public string TextArea {
            get { return _textArea; }
            set
            {
                _textArea = value;
                NotifyPropertyChanged("TextArea");
            }
        }
    }
}

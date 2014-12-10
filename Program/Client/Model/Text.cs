﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopClient.Framework;

namespace DesktopClient.Model
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

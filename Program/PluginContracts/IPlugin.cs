﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Utils;
namespace PluginContracts
{

    // 
    public interface IPlugin
    {
        string Name { get; }
        MenuItem MenuItems { get; }

        string TextBoxContent { get; set; }
        string SavePath { get; set; }
        
        event PropertyChangedEventHandler PropertyChanged;

        void setTextBoxContent(string content, bool update);
    }
}
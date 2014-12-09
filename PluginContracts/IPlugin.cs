using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Utils;
namespace PluginContracts
{
    public interface IPlugin
    {
        string Name { get; }
        MenuItem MenuItems { get; }

        string TextBoxContent { get; set; }

        event PropertyChangedEventHandler PropertyChanged;
    }
}
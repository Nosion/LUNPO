using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
namespace PluginContracts
{
    public interface IPlugin
    {
        string Name { get; }
        MenuItem MenuItems { get; }
        
        void Do();
    }
}
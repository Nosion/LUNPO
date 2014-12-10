using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopClient.Framework;
using PluginContracts;


namespace DesktopClient.Framework
{

    public class PluginInit
    {
        // declare Plugins as a dictionary.
        public Dictionary<string, IPlugin> Plugins;


        public PluginInit()
        {
      

            Plugins = new Dictionary<string, IPlugin>();
            ICollection<IPlugin> plugins = GenericPluginLoader<IPlugin>.LoadPlugins("Plugins");
            try
            {

                foreach (var plugin in plugins)
                {
                    Plugins.Add(plugin.Name, plugin);
                }
            }
            catch (Exception)
            {
            }

      
        }



    }
}

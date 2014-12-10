using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Framework;
using PluginContracts;


namespace Client.Framework
{

    class PluginInit
    {
        public Dictionary<string, IPlugin> Plugins;


        public PluginInit()
        {

            Plugins = new Dictionary<string, IPlugin>();
            ICollection<IPlugin> plugins = GenericPluginLoader<IPlugin>.LoadPlugins("Plugins");
            try
            {

                foreach (var item in plugins)
                {
                    Plugins.Add(item.Name, item);
                }
            }
            catch (Exception)
            {
            }

      
        }



    }
}

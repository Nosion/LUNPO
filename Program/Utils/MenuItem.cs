using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{    
    public class MenuItem
    {
        public string Text { get; set; }
        public List<MenuItem> Children { get; private set; }
        public DelegateCommand<object> Command { get; set; }

        public MenuItem(string item)
        {
            Text = item;
            Children = new List<MenuItem>();
        }
    }
}

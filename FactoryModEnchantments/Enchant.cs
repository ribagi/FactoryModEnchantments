using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryModEnchantments
{
    class Enchant
    {
        private string _name;
        public string name { get { return _name; } set { _name = value; } }
        private string _bukkit;
        public string bukkit { get { return _bukkit; } set { _bukkit = value; } }

        public Enchant(string _name, string _bukkit)
        {
            this._bukkit = _bukkit;
            this._name = _name;
        }
    }
}

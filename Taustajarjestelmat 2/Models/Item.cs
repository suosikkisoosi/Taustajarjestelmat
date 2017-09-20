using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taustajarjestelmat_2.Models
{
    public class Item
    {
        public Guid id;
        public string name;
        public int lvl;

        public Guid Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public int Lvl { get { return lvl; } set { lvl = value; } }

        //public Guid Id { get; private set ; }
        //public string Name { get; private set; }
        //public int Lvl { get; private set; }

        public Item(Guid id, string name) { this.id = id; this.name = name; }
    }

}

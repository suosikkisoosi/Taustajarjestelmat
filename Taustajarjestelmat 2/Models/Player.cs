using System;
using System.Collections.Generic;

namespace Taustajarjestelmat_2.Models
{
    public class Player
    {
        Guid id;
        string name;
        int lvl;
        
        public Dictionary<Guid, Item> Items = new Dictionary<Guid, Item>();

        public Guid Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public int Lvl { get { return lvl; } set { lvl = value; } }

        public Player(Guid id, string name) { this.id = id; this.name = name; }
    }
}
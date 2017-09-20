using System;

namespace Taustajarjestelmat_2.Models
{
    public class NewPlayer
    {
        string name;
        int lvl;

        public string Name { get { return name; } set { name = value; } }
        public int Lvl { get { return lvl; } set { lvl = value; } }
    }
}
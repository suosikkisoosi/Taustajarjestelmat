using System;

namespace Taustajarjestelmat_2.Models
{
    public class NewItem
    {
        string name;
        int lvl;
        Date creationDate;


        public string Name { get { return name; } set { name = value; } }
        public int Lvl { get { return lvl; } set { lvl = value; } }
        public Date CreationDate { get { return CreationDate; } set { CreationDate = value; } }
    }

}
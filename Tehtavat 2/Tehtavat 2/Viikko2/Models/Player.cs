using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Viikko2.Models {

    public class Player {

        public Guid ID { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }

        public Player (Guid id, string name) {
            ID = id;
            Name = name;
        }
    }
}

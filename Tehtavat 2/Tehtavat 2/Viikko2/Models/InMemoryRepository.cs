using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Viikko2.Models {

    public class InMemoryRepository : IRepository<Player> {

        private Dictionary<Guid, Player> repo = new Dictionary<Guid, Player> ();

        public async Task<bool> Add (Player player) {
            if (repo.ContainsKey (player.ID))
                return false;
            repo.Add (player.ID, player);
            return true;
        }

        public async Task<bool> Delete (Guid id) {
            if (repo.ContainsKey (id)) {
                repo.Remove (id);
                return true;
            }
            return false;
        }

        public async Task<Player[]> GetAll () {
            return repo.Values.ToArray ();
        }

        public async Task<Player> GetWithGuid (Guid id) {
            repo.TryGetValue (id, out Player player);
            return player;
        }
    }
}

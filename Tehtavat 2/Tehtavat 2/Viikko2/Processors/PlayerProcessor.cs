using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Viikko2.Models;

namespace Viikko2.Processors {
    
    public class PlayerProcessor {

        private IRepository<Player> repo;

        public PlayerProcessor (IRepository<Player> repo) {
            this.repo = repo;
        }

        public async Task<Player> CreateNewPlayer (NewPlayer playerData) {
            var player = new Player (new Guid (), playerData.Name) {
                Level = playerData.Level
            };
            await repo.Add (player);
            return player;
        }

        public async Task<Player> GetPlayer (Guid id) {
            return await repo.GetWithGuid (id);
        }

        public async Task<Player[]> GetAll () {
            return await repo.GetAll ();
        }

        public async Task<bool> DeletePlayer (Guid id) {
            return await repo.Delete (id);
        }

        public async Task<Player> ModifyPlayer (Guid id, ModifiedPlayer modData) {
            Player p = await repo.GetWithGuid (id);
            if (p != null)
                p.Name = modData.Name;
            return p;
        }

    }
   
}

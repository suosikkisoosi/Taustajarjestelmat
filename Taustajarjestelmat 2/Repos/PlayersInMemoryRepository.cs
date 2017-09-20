using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Taustajarjestelmat_2.Models;
using System.Linq;

namespace Taustajarjestelmat_2.Repositories
{
    public class PlayersInMemoryRepository : IPlayersRepository
    {
        private Dictionary<Guid, Player> _players = new Dictionary<Guid, Player>();

        public async Task<Player> Get(Guid id)
        {
            if(_players.ContainsKey(id) == false)
            {
                throw new NotFoundException();
            }
            return _players[id];
        }

        public async Task<Player[]> GetAll()
        {
            return _players.Values.ToArray();
        }

        public async Task<Player> Create(Player player)
        {
            _players.Add(player.Id, player);
            return player;
        }

        public async Task<Player> Modify(Guid id, ModifiedPlayer player)
        {
            Player p;
            if (_players.TryGetValue(id, out p))
            {
                p.Name = player.Name;
                p.Lvl = player.Lvl;
            }

            return null;
        }

        public async Task<Player> Delete(Guid id)
        {
            
            Player p;
            if (_players.TryGetValue(id, out p))
                _players.Remove(id);
            return null;
        }

    }
}
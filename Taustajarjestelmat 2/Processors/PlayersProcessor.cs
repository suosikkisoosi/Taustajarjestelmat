using System;
using System.Threading.Tasks;
using Taustajarjestelmat_2.Repositories;
using Taustajarjestelmat_2.Models;

namespace Taustajarjestelmat_2.Processors
{
    public class PlayersProcessor
    {
        private IPlayersRepository repo;

        public PlayersProcessor(IPlayersRepository repository)
        {
            repo = repository;
        }

        public async Task<Player[]> GetAll()
        {
            return await repo.GetAll();
        }

        public async Task<Player> Get(Guid id)
        {
            return await repo.Get(id);
        }

        public async Task<Player> Create(NewPlayer nPlaya)
        {

            Player p = new Player(Guid.NewGuid(), nPlaya.Name) { Lvl = nPlaya.Lvl };
            return await repo.Create(p);
        }

        public async Task<Player> Modify(Guid id, ModifiedPlayer mPlaya)
        {
            return await repo.Modify(id, mPlaya); ;
        }

        public async Task<Player> Delete(Guid id)
        {
            return await repo.Delete(id);
        }
    }
}
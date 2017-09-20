using System.Threading.Tasks;
using System;
using Taustajarjestelmat_2.Models;

namespace Taustajarjestelmat_2.Repositories
{
    public interface IPlayersRepository
    {
        Task<Player> Get(Guid id);

        Task<Player[]> GetAll();

        Task<Player> Create(Player player);

        Task<Player> Modify(Guid id, ModifiedPlayer player);

        Task<Player> Delete(Guid id);

    }
}
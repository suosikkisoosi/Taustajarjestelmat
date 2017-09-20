using System.Threading.Tasks;
using System;
using Taustajarjestelmat_2.Models;

namespace Taustajarjestelmat_2.Repositories
{
    public interface IItemsRepository
    {
        Task<Item> Get(Guid id);

        Task<Item[]> GetAll();

        Task<Item> Create(Item item);

        Task<Item> Modify(Guid id, ModifiedItem item);

        Task<Item> Delete(Guid id);

    }
}
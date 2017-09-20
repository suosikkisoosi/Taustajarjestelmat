using System;
using System.Threading.Tasks;
using Taustajarjestelmat_2.Repositories;
using Taustajarjestelmat_2.Models;

namespace Taustajarjestelmat_2.Processors
{
    public class ItemsProcessor
    {
        private IItemsRepository repo;

        public ItemsProcessor(IItemsRepository repository)
        {
            repo = repository;
        }

        public async Task<Item[]> GetAll()
        {
            return await repo.GetAll();
        }

        public async Task<Item> Get(Guid id)
        {
            return await repo.Get(id);
        }

        public async Task<Item> Create(NewItem nItem)
        {
            Item i = new Item(Guid.NewGuid(), nItem.Name) { Lvl = nItem.Lvl };
            return await repo.Create(i);
        }

        public async Task<Item> Modify(Guid id, ModifiedItem mItem)
        {
            //_players[playerId].GetItems()[ItemId] = Item;
            //return Item;
            return await repo.Modify(id, mItem); ;
        }

        public async Task<Item> Delete(Guid id)
        {
            return await repo.Delete(id);
        }
    }
}
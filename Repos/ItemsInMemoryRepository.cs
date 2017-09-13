using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Taustajarjestelmat_2.Models;
using System.Linq;

namespace Taustajarjestelmat_2.Repositories
{
    public class ItemsInMemoryRepository : IItemsRepository
    {
        private Dictionary<Guid, Item> _items = new Dictionary<Guid, Item>();

        public async Task<Item> Get(Guid id)
        {
            if (_items.ContainsKey(id) == false)
            {
                throw new NotFoundException();
            }
            return _items[id];
        }

        public async Task<Item[]> GetAll()
        {
            return _items.Values.ToArray();
        }

        public async Task<Item> Create(Item item)
        {
            _items.Add(item.Id, item);
            return item;
        }

        public async Task<Item> Modify(Guid id, ModifiedItem item)
        {
            Item i;
            if (_items.TryGetValue(id, out i))
            {
                i.Name = item.Name;
                i.Lvl = item.Lvl;
            }

            return null;
        }

        public async Task<Item> Delete(Guid id)
        {
            Item i;
            if (_items.TryGetValue(id, out i))
                _items.Remove(id);
            return null;
        }

    }
}
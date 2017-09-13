using System;
using System.Threading.Tasks;
using Taustajarjestelmat_2.Models;
using Microsoft.AspNetCore.Mvc;
using Taustajarjestelmat_2.Processors;

namespace Taustajarjestelmat_2.Controllers
{
    [Route("/api/players/{playerId}/items")]
    public class ItemController : Controller
    {
        private ItemsProcessor _processor;

        public ItemController(ItemsProcessor processor)
        {
            _processor = processor;
        }

        [HttpGet]
        public async Task<Item[]> GetAll()
        {
            Item[] items = await _processor.GetAll();
            return items;
        }

        [HttpPost]
        //[ValidateModel]
        public async Task<Item> Create([FromBody]NewItem item)
        {
            return await _processor.Create(item);
        }

        [HttpPut]
        public async Task<Item> Modify(string id, [FromBody]ModifiedItem item)
        {
            Guid _id = new Guid(id);
            return await _processor.Modify(_id, item);
        }


        [HttpDelete]
        public async Task<Item> Delete(string id)
        {
            Guid _id = new Guid(id);
            return await _processor.Delete(_id);
        }
    }
}
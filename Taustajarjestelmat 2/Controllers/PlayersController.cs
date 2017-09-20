using System;
using System.Threading.Tasks;
using Taustajarjestelmat_2.Models;
using Microsoft.AspNetCore.Mvc;
using Taustajarjestelmat_2.Processors;

namespace Taustajarjestelmat_2.Controllers
{
    [Route("api/players")]
    public class PlayersController : Controller
    {
        private PlayersProcessor _processor;

        public PlayersController(PlayersProcessor processor)
        {
            _processor = processor;
        }

        [HttpGet]
        public async Task<Player[]> GetAll()
        {
            Player[] players = await _processor.GetAll();
            return players;
        }

        [HttpPost]
        //[ValidateModel]
        public async Task<Player> Create([FromBody]NewPlayer player)
        {
            return await _processor.Create(player);
        }

        [HttpPut]
        public async Task<Player> Modify(string id, [FromBody]ModifiedPlayer player)
        {
            Guid _id = new Guid(id);
            return await _processor.Modify(_id, player);
        }

        [HttpDelete]
        public async Task<Player> Delete(string id)
        {
            Guid _id = new Guid(id);
            return await _processor.Delete(_id);
        }
    }
}
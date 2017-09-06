using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Viikko2.Models;
using Viikko2.Processors;

namespace Viikko2.Controllers {

    [Route ("api/players")]
    public class PlayerController : Controller {

        private PlayerProcessor processor;

        public PlayerController (PlayerProcessor processor) {
            this.processor = processor;
        }

        [HttpPost]
        public async void CreatePlayer ([FromBody]NewPlayer playerData) {
            await processor.CreateNewPlayer (playerData);
        }

        [HttpGet ("{id}")]
        public async Task<Player> GetPlayer (Guid id) {
            return await processor.GetPlayer (id);
        }

        [HttpDelete ("{id}")]
        public async void DeletePlayer (Guid id) {
            await processor.DeletePlayer (id);
        }

        [HttpPut ("{id}")]
        public async void ModifyPlayer (Guid id, [FromBody]ModifiedPlayer modifyData) {
            await processor.ModifyPlayer (id, modifyData);
        }
    }
}

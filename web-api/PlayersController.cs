using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace web_api
{
    public class PlayersController
    {
        PlayersProcessor _processor;

        public PlayersController(PlayersProcessor processor)
        {
            _processor = processor;
        }

        [Route("api/players/{id:Guid}")]
        [HttpGet]
        public Task<Player> Get(Guid id)
        {
            return _processor.Get(id);
        }

        [Route("api/players")]
        [HttpGet]
        public Task<Player[]> GetAll()
        {
            return _processor.GetAll();
        }

        [Route("api/players")]
        [HttpPost]
        public Task<Player> Create(NewPlayer player)
        {
            return _processor.Create(player);
        }

        [Route("api/players")]
        [HttpPost]
        public Task<Player> Create([FromBody] string playerJson)
        {
            NewPlayer player = JsonConvert.DeserializeObject<NewPlayer>(playerJson);
            return _processor.Create(player);
        }

        // [Route("api/players/{playerName}")]
        // [HttpPost]
        // public Task<Player> Create(string playerName)
        // {
        //     NewPlayer player = new NewPlayer(playerName);
        //     return _processor.Create(player);
        // }

        // [Route("api/players/diiba")]
        // [HttpPost]
        // public Task<Player> CreateDiiba()
        // {
        //     NewPlayer player = new NewPlayer("Diiba");
        //     return _processor.Create(player);
        // }

        [Route("api/players")]
        [HttpPut]
        public Task<Player> Modify(Guid id, ModifiedPlayer player)
        {
            return _processor.Modify(id, player);
        }

        [Route("api/players")]
        [HttpDelete]
        public Task<Player> Delete(Guid id)
        {
            return _processor.Delete(id);
        }
    }
}

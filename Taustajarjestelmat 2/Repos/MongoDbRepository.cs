using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taustajarjestelmat_2.Models;
using MongoDB.Driver;
using Taustajarjestelmat_2.Mongodb;

namespace Taustajarjestelmat_2.Repos
{
    public class MongoDbRepository : IRepository
    {
        private IMongoCollection<Player> _collection;
        public MongoDbRepository(MongoDBClient client)
        {
            IMongoDatabase database = client.GetDatabase("gameapi");
            _collection = database.GetCollection<Player>("players");
        }

        public Task<Item> CreateItem(Guid playerId, Item item)
        {
            throw new NotImplementedException();
        }

        //KAYTA _COLLECTION.REPLACEONEASYNC
        public async Task<Player> CreatePlayer(Player player)
        {
            await _collection.InsertOneAsync(player);
            return player;
        }

        public Task<Item> DeleteItem(Guid playerId, Item item)
        {
            throw new NotImplementedException();
        }

        public Task<Player> DeletePlayer(Guid playerId)
        {
            throw new NotImplementedException();
        }

        public Task<Item[]> GetAllItems(Guid playerId)
        {
            throw new NotImplementedException();
        }

        public Task<Player[]> GetAllPlayers()
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetItem(Guid playerId, Guid itemId)
        {
            throw new NotImplementedException();
        }

        public async Task<Player> GetPlayer(Guid playerId)
        {
            FilterDefinition<Player> filter = Builders<Player>.Filter.Eq(p => p.Id, playerId); //Type can be var
            var cursor = await _collection.FindAsync(filter);
            var player = await cursor.FirstAsync(); //cursor.tolistasync for get all
            return player;
        }

        public Task<Item> UpdateItem(Guid playerId, Item item)
        {
            throw new NotImplementedException();
        }

        public async Task<Player> UpdatePlayer(Player player)
        {
            FilterDefinition<Player> filter = Builders<Player>.Filter.Eq(p => p.Id, player.Id); //Type can be var
            await _collection.ReplaceOneAsync(filter, player);
            return player;
        }
    }
}

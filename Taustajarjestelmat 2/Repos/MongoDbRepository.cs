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

        public async Task<Item> CreateItem(Guid playerId, Item item)
        {
            Player p = await GetPlayer(playerId);
            p.Items.Add(item.id, item);
            return item;
        }

        //KAYTA _COLLECTION.REPLACEONEASYNC
        public async Task<Player> CreatePlayer(Player player)
        {

            await _collection.InsertOneAsync(player);
            return player;
        }

        public async Task<Item> DeleteItem(Guid playerId, Item item)
        {
            Player p = await GetPlayer(playerId);
            Item i = item;
            p.Items.Remove(item.id);
            return i;
        }

        public async Task<Player> DeletePlayer(Guid playerId)
        {
            Player player = await GetPlayer(playerId);
            FilterDefinition<Player> filter = Builders<Player>.Filter.Eq(p => p.Id, playerId); //Type can be var
            await _collection.DeleteOneAsync(filter);
            return player;
        }

        public async Task<Item[]> GetAllItems(Guid playerId)
        {
            Player player = await GetPlayer(playerId);
            Item[] items = player.Items.Values.ToArray();
            return items;
        }

        public async Task<Player[]> GetAllPlayers()
        {
            FilterDefinition<Player> filter = Builders<Player>.Filter.OfType<Player>(); //Type can be var
            var cursor = await _collection.FindAsync(filter);
            var players = await cursor.ToListAsync();
            return players.ToArray();
        }

        public async Task<Item> GetItem(Guid playerId, Guid itemId)
        {
            Player player = await GetPlayer(playerId);
            Item i = player.Items[itemId];
            return i;
        }

        public async Task<Player> GetPlayer(Guid playerId)
        {
            FilterDefinition<Player> filter = Builders<Player>.Filter.Eq(p => p.Id, playerId); //Type can be var
            var cursor = await _collection.FindAsync(filter);
            var player = await cursor.FirstAsync(); //cursor.tolistasync for get all
            return player;
        }

        public async Task<Item> UpdateItem(Guid playerId, Item item)
        {
            Player player = await GetPlayer(playerId);
            player.Items[item.id] = item;
            return item;
        }

        public async Task<Player> UpdatePlayer(Player player)
        {
            FilterDefinition<Player> filter = Builders<Player>.Filter.Eq(p => p.Id, player.Id); //Type can be var
            await _collection.ReplaceOneAsync(filter, player);
            return player;
        }
    }
}

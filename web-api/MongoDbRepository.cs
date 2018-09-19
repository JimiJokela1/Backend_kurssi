using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace web_api
{
    public class MongoDbRepository : IRepository
    {
        private readonly IMongoCollection<Player> _collection;

        public MongoDbRepository()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = mongoClient.GetDatabase("Game");
            _collection = database.GetCollection<Player>("players");
        }

        public async Task<Player> Create(Player player)
        {
            await _collection.InsertOneAsync(player);
            return player;
        }

        public async Task<Player> Delete(Guid id)
        {
            Player player = await Get(id);
            var filter = Builders<Player>.Filter.Eq("_id", id);
            await _collection.DeleteOneAsync(filter);
            
            return player;
        }

        public async Task<Player> Get(Guid id)
        {
            var filter = Builders<Player>.Filter.Eq("Id", id);
            return await _collection.Find(filter).FirstAsync();
        }

        public async Task<Player[]> GetAll()
        {
            List<Player> players = await _collection.Find(new BsonDocument()).ToListAsync();
            return players.ToArray();
        }

        public async Task<Player> Modify(Guid id, ModifiedPlayer modPlayer)
        {
            Player player = await Get(id);
            player.Modify(modPlayer);
            var filter = Builders<Player>.Filter.Eq("_id", player.Id);
            await _collection.ReplaceOneAsync(filter, player);
            return player;
        }

        public async Task<Item[]> GetAllItems(Guid playerId)
        {
            // var pull = Builders<Player>.Update.PullFilter(p => p.Items, i => i.Id == itemId);
            // var filter = Builders<Player>.Filter.Eq("_id", playerId);
            throw new NotImplementedException();
        }

        public async Task<Item> GetItem(Guid playerId, Guid itemId)
        {
            throw new NotImplementedException();
        }

        public async Task<Item> CreateItem(Guid playerId, Item item)
        {
            throw new NotImplementedException();
        }

        public async Task<Item> ModifyItem(Guid playerId, Guid itemId, ModifiedItem item)
        {
            throw new NotImplementedException();
        }

        public async Task<Item> DeleteItem(Guid playerId, Guid itemId)
        {
            throw new NotImplementedException();
        }
    }
}
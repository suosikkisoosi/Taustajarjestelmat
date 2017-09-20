using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Taustajarjestelmat_2.Mongodb
{
    public class MongoDBClient
    {
        private readonly MongoClient _mongoClient;

        public MongoDBClient()
        {
            _mongoClient = new MongoClient("mongodb:localhost:27017");
        }

        public IMongoDatabase GetDatabase(string name)
        {
            return _mongoClient.GetDatabase(name);
        }
    }
}

using Microsoft.Extensions.Options;
using MongoDB.Driver;
using sts_models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace sts_daos
{
    public class MongoGeneralContext
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }

    public class MongoDataContext
    {
        private readonly IMongoDatabase _database = null;

        public MongoDataContext(IOptions<MongoGeneralContext> mongoGeneralContext)
        {
            var client = new MongoClient(mongoGeneralContext.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(mongoGeneralContext.Value.Database);
        }

        public IMongoCollection<sts_models.DTO.UserMG> Users { get{
                return _database.GetCollection<sts_models.DTO.UserMG>("User");
            }
        }
    }

    
}

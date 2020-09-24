using Microsoft.EntityFrameworkCore;

namespace finance_app_api.Models
{
    using finance_app_api;
    using MongoDB.Driver;
    using System;
    public class AccountContext : IAccountContext
    {
        private readonly IMongoDatabase _db;
        public AccountContext(MongoDBConfig config)
        {
            var client = new MongoClient(config.ConnectionString);
            _db = client.GetDatabase(config.Database);
        }

        public IMongoCollection<Account> Accounts => _db.GetCollection<Account>("Accounts");
    }
}
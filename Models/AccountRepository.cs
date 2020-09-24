namespace finance_app_api.Models{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MongoDB.Driver;
    using MongoDB.Bson;
    using System.Linq;

    public class AccountRepository : IAccountRepository
    {
        private readonly IAccountContext _context;

        public AccountRepository(IAccountContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Account>> GetAllAccounts()
        {
            return await _context
            .Accounts
            .Find(_ => true)
            .ToListAsync();
        }

        public Task<Account> GetAccount(long id)
        {
            FilterDefinition<Account> filter = Builders<Account>.Filter.Eq(m => m.Id, id);
            return _context
            .Accounts
            .Find(filter)
            .FirstOrDefaultAsync();
        }

        public async Task Create(Account account)
        {
            await _context.Accounts.InsertOneAsync(account);
        }
        public async Task<bool> Update(Account account)
        {
            ReplaceOneResult updateResult = await _context
            .Accounts
            .ReplaceOneAsync(
                filter: g => g.Id == account.Id, replacement: account
            );
            
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(long id)
        {
            FilterDefinition<Account> filter = Builders<Account>.Filter.Eq(m => m.Id, id);
            DeleteResult deleteResult = await _context
                                                .Accounts
                                              .DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
        public async Task<long> GetNextId()
        {
            return await _context.Accounts.CountDocumentsAsync(new BsonDocument()) + 1;
        }
    }
}
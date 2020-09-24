namespace finance_app_api.Models
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAccountRepository
    {
        // api/[GET]
        Task<IEnumerable<Account>> GetAllAccounts();
        
        // api/1/[GET]
        Task<Account> GetAccount(long id);
        
        // api/[POST]
        Task Create(Account account);
        
        // api/[PUT]
        Task<bool> Update(Account account);
        
        // api/1/[DELETE]
        Task<bool> Delete(long id);

        Task<long> GetNextId();
    }
}
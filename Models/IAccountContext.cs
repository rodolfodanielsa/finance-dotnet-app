namespace finance_app_api.Models
{
    using MongoDB.Driver;

    public interface IAccountContext
    {
        IMongoCollection<Account> Accounts { get; }
    }
}
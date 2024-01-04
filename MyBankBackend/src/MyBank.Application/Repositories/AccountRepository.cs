using MyBank.Data;
using MyBank.Models;

namespace MyBank.Repositories
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(AppDbContext dbContext) : base(dbContext) { }

    }
}
using Microsoft.EntityFrameworkCore;
using MyBank.Data;
using MyBank.Models;

namespace MyBank.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext dbContext) : base(dbContext) { }


        public async Task<Customer?> FindActiveCustomersByEmail(string email)
        {
            return await _dbSet
                .Where(c => c.Email == email && !c.Deleted && c.Active)
                .FirstOrDefaultAsync();

        }
    }
}
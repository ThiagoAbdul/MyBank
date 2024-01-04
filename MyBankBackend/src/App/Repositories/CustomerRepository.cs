using Microsoft.EntityFrameworkCore;
using MyBank.Data;
using MyBank.Models;

namespace MyBank.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext dbContext) : base(dbContext) { }


        public async Task<Customer?> FindByEmail(string email)
        {
            return await _dbSet
                .Where(c => c.Email == email)
                .FirstOrDefaultAsync();

        }
    }
}
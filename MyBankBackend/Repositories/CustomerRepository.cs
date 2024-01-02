using MyBank.Data;
using MyBank.Models;

namespace MyBank.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}
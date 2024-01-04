using MyBank.Models;

namespace MyBank.Repositories
{
    public interface ICustomerRepository: IRepository<Customer>
    {
        Task<Customer?> FindByEmail(string email);
    }
}
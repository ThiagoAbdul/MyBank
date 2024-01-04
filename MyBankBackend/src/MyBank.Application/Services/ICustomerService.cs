using MyBank.Models;

namespace MyBank.Services
{
    public interface ICustomerService
    {
        Task<Customer> RegisterCustomer(Customer customer);
    }

}
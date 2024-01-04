using MyBank.Models;
using MyBank.Repositories;

namespace MyBank.Services
{
    public class CustomerService : ICustomerService
    {

    private readonly ICustomerRepository _customerRepository;
    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

        public async Task<Customer> RegisterCustomer(Customer customer)
        {
            return await _customerRepository.Create(customer);
        }
    }
}
using MyBank.Clients;
using MyBank.Exceptions;
using MyBank.Models;
using MyBank.Repositories;

namespace MyBank.Services
{
    public class CustomerService : ICustomerService
    {

    private readonly ICustomerRepository _customerRepository;
    private IEmailServiceClient _emailServiceClient;
    public CustomerService(ICustomerRepository customerRepository, 
                            IEmailServiceClient emailServiceClient)
    {
        _customerRepository = customerRepository;
        _emailServiceClient = emailServiceClient;
    }

        public async Task<Customer> RegisterCustomer(Customer customer)
        {
            await VerifyIfEmailIsNotRegistered(customer);
            Customer created = await _customerRepository.Create(customer);
            _emailServiceClient.SendEmailConfirmationRequest(created.Email, created.Id);
            await _customerRepository.CommitAsync();
            return created;
        }

        private async Task VerifyIfEmailIsNotRegistered(Customer customer)
        {
            Customer? found =  await _customerRepository.FindByEmail(customer.Email);
            if (found != null)
            {
                throw new EmailAlreadyRegisteredException(found.Email);
            }
        }
    }
}
using MyBank.Clients;
using MyBank.Exceptions;
using MyBank.Models;
using MyBank.Repositories;

namespace MyBank.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ICustomerRepository _customerRepository;
        private IEmailServiceClient _emailServiceClient;
        public AccountService(IAccountRepository accountRepository, 
            ICustomerRepository customerRepository,
            IEmailServiceClient emailServiceClient)
        {
            _accountRepository = accountRepository;
            _customerRepository = customerRepository;
            _emailServiceClient = emailServiceClient;
        }
        public async Task<Account> OpenAccount(Customer customer, string password)
        {
            customer = await _customerRepository.Create(customer);
            Account account = customer.CreateAccount("1234", password); // Hash password
            account =  await _accountRepository.Create(account);
            await _accountRepository.CommitAsync();
            return account;
        }

    }
}
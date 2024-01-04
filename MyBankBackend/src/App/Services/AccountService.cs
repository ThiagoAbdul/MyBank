using MyBank.Exceptions;
using MyBank.Models;
using MyBank.Repositories;

namespace MyBank.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ICustomerRepository _customerRepository;
        public AccountService(IAccountRepository accountRepository, 
            ICustomerRepository customerRepository)
        {
            _accountRepository = accountRepository;
            _customerRepository = customerRepository;
        }
        public async Task<Account> OpenAccount(Customer customer, string password) // Test
        {
            await VerifyIfEmailIsNotRegistered(customer); // Test
            customer = await _customerRepository.Create(customer);
            Account account = customer.CreateAccount("1234", password); // Hash password
            account =  await _accountRepository.Create(account);
            await _accountRepository.CommitAsync();
            return account;
        }

        private async Task VerifyIfEmailIsNotRegistered(Customer customer) // Test
        {
            Customer? found =  await _customerRepository.FindByEmail(customer.Email);
            if (found != null)
                throw new EmailAlreadyRegisteredException(found.Email);
        }

    }
}
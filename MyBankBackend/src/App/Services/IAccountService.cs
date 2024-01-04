using MyBank.Models;

namespace MyBank.Services
{
    public interface IAccountService
    {
        Task<Account> OpenAccount(Customer customer);
    }
}
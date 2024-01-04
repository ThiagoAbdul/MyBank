using Moq;
using MyBank.Exceptions;
using MyBank.Models;
using MyBank.Repositories;
using MyBank.Services;

namespace MyBankTest.Services
{
    public class AccountServiceTest
    {
        AccountService _accountService;
        Customer _customer;
        Mock<IAccountRepository> accountRepositoryMock;
        Mock<ICustomerRepository> customerRepositoryMock;
        public AccountServiceTest()
        {
            accountRepositoryMock = new Mock<IAccountRepository>();
            customerRepositoryMock = new Mock<ICustomerRepository>();
            _accountService = new AccountService(
                accountRepositoryMock.Object,
                customerRepositoryMock.Object
            );

            customerRepositoryMock
                .Setup(mock  => mock.Create(It.IsAny<Customer>()))
                .Returns<Customer>(customer => 
                    {
                        customer.Id = Guid.NewGuid();
                        return Task.FromResult(customer);
                    }
                );

            accountRepositoryMock
                .Setup(mock  => mock.Create(It.IsAny<Account>()))
                .Returns<Account>(account => 
                    {
                        account.Id = Guid.NewGuid();
                        return Task.FromResult(account);
                    }
                );

            _customer = new Customer("João", "Souza", "joao@gmail.com", 
                                                    new DateOnly(2000, 10, 1));
        }

        [Fact]
        public async void OpenAccount()
        {
            Account account = await _accountService.OpenAccount(_customer, "lsllds");
            Assert.Equal(_customer, account.Customer);

        }

        [Fact]
        public void OpenAccount_EmailMustBeUnique()
        {
            customerRepositoryMock
                .Setup(mock => mock.FindByEmail(_customer.Email))
                .ReturnsAsync(_customer);
            Assert.ThrowsAsync<EmailAlreadyRegisteredException>(
                () => _accountService.OpenAccount(_customer, "sjdsd")
            );
        }
    }
}
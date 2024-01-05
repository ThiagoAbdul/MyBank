using Microsoft.EntityFrameworkCore;
using MyBank.Data;
using MyBank.Models;
using MyBank.Repositories;

namespace MyBankTest.Repositories
{
    public class CustomerRepositoryTest : IDisposable
    {   
        static readonly AppDbContext  _dbContext;
                
        CustomerRepository _customerRepository = new CustomerRepository(_dbContext);
        Customer _customer;
        
        static CustomerRepositoryTest()
        {
            _dbContext = new AppDbContext(
                new DbContextOptionsBuilder<AppDbContext>()
                    .UseInMemoryDatabase("Test_DB")
                    .Options
            );
        }
        public CustomerRepositoryTest()
        {
            _dbContext.Database.EnsureCreated();
            _customer = new Customer("João", "Souza", "joao@gmail.com", new DateOnly(2000, 10, 1));

        }

        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
        }

        [Fact]
        public async Task FindByEmail()
        {
            await _customerRepository.Create(_customer);
            await _customerRepository.CommitAsync();
            Customer? found = await _customerRepository.FindByEmail(_customer.Email);
            Assert.NotNull(found);
            Assert.Equal(_customer.Email, found.Email);
        }

        [Fact]
        public async Task FindByEmail_CustomerDeleted()
        {   _customer.Deleted = true;
            await _customerRepository.Create(_customer);
            await _customerRepository.CommitAsync();
            Customer? found = await _customerRepository.FindByEmail(_customer.Email);
            Assert.Null(found);
            
        }

    }
}
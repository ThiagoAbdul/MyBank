using MyBank.Exceptions;
using MyBank.Models;

namespace MyBankTest.Models
{
    public class CustomerTest
    {
        Customer _customer;
        public CustomerTest() 
        {
            _customer = new Customer("João", "Souza", "joao@gmail.com", new DateOnly(2000, 10, 1));
        }

        [Fact]
        public void CreateAccount_customerMustBeAdult()
        {
            _customer.BirthDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-17));
            Assert.Throws<UnderageCustomerException>(() => _customer.CreateAccount("1234", "1234"));
            
        }
    }
}
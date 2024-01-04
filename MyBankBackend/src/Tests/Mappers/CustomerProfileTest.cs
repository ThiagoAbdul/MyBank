using AutoMapper;
using MyBank.DTOs.Inputs;
using MyBank.DTOs.Outputs;
using MyBank.Mappers;
using MyBank.Models;

namespace MyBankTest.Mappers
{
    public class CustomerProfileTest
    {
        private readonly IMapper _mapper;
        CustomerInputModel _customerInputModel;
        Customer _customer;
        public CustomerProfileTest()
        {
            _mapper = new MapperConfiguration(
                cfg => cfg.AddProfile(new CustomerProfile())
            )
            .CreateMapper();
            _customerInputModel = new CustomerInputModel{
                FirstName = "João",
                LastName = "Souza",
                Email = "joao@gmail.com",
                BirthDate = "2000-10-01"
            };

            _customer = new Customer{
                Id = Guid.NewGuid(),
                FirstName = "João",
                LastName = "Souza",
                Email = "joao@gmail.com",
                BirthDate = new DateOnly(2000, 10, 1)
            };

            var account = new Account("1234", "1234", _customer);
            account.Id = Guid.NewGuid();
            _customer.Account = account;

        }

        [Fact]
        public void CustomerInputModelToCustomer()
        {
            Customer customer = _mapper.Map<Customer>(_customerInputModel);

            Assert.NotNull(customer.BirthDate);
            Assert.Equal(2000, customer.BirthDate?.Year);
        }

        [Fact]
        public void CustomerToCustomerViewModel()
        {
            var customerViewModel = _mapper.Map<CustomerViewModel>(_customer);

            Assert.NotNull(customerViewModel.BirthDate);
        }
    }
}
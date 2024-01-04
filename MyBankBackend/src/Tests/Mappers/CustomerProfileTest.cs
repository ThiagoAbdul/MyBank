using AutoMapper;
using MyBank.DTOs.Inputs;
using MyBank.Mappers;
using MyBank.Models;

namespace MyBankTest.Mappers
{
    public class CustomerProfileTest
    {
        private readonly IMapper _mapper;
        CustomerInputModel _customerInputModel;
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

        }

        [Fact]
        public void CustomerInputModelToCustomer()
        {
            Customer customer = _mapper.Map<Customer>(_customerInputModel);

            Assert.NotNull(customer.BirthDate);
            Assert.Equal(2000, customer.BirthDate?.Year);
        }
    }
}
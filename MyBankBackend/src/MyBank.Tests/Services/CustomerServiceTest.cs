using Moq;
using MyBank.Clients;
using MyBank.Events;
using MyBank.Exceptions;
using MyBank.Models;
using MyBank.Repositories;
using MyBank.Services;

namespace MyBankTest.Services
{
    public class CustomerServiceTest
    {
        CustomerService _customerSerivce;
        Mock<ICustomerRepository> customerRepositoryMock;
        Mock<IEmailServiceClient> emailServiceClientMock;
        Customer _customer;

        public CustomerServiceTest()
        {
            customerRepositoryMock = new Mock<ICustomerRepository>();
            emailServiceClientMock = new Mock<IEmailServiceClient>();

            customerRepositoryMock
                .Setup(mock  => mock.Create(It.IsAny<Customer>()))
                .Returns<Customer>(customer => 
                    {
                        customer.Id = Guid.NewGuid();
                        return Task.FromResult(customer);
                    }
                );

            _customerSerivce = new CustomerService(
                customerRepositoryMock.Object, 
                emailServiceClientMock.Object
            );


            _customer = new Customer("João", "Souza", "joao@gmail.com", 
                                                    new DateOnly(2000, 10, 1));
        }


        [Fact]
        public async void CreateCustomer()
        {
            await _customerSerivce.RegisterCustomer(_customer);
            emailServiceClientMock
                .Verify(mock => mock.SendEmailConfirmationRequest(_customer.Email, _customer.Id));
        }

        [Fact]
        public void CreateCustomert_EmailMustBeUnique()
        {
            customerRepositoryMock
                .Setup(mock => mock.FindByEmail(_customer.Email))
                .ReturnsAsync(_customer);
            Assert.ThrowsAsync<EmailAlreadyRegisteredException>(
                () => _customerSerivce.RegisterCustomer(_customer)
            );
        }
    }
}
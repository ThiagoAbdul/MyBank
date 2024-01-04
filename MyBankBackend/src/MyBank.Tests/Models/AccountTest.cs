using MyBank.Exceptions;
using MyBank.Models;

namespace MyBankTest.Models
{
    public class AccountTest
    {
        Account a1;
        Account a2;

        public AccountTest()
        {
            a1 = new(
                "1234", 
                "1234", 
                new Customer(
                    "João", 
                    "Souza", 
                    "joao@gmail.com",
                    new DateOnly(2000, 10, 1)
                )
            );

            a2 = new(
                "6541", 
                "2435", 
                new Customer(
                    "Maria", 
                    "Silva", 
                    "maria@gmail.com",
                    new DateOnly(1998, 7, 10)
                )
            );
        }

        [Fact]
        public void Transfer_ValueMustBePositive()
        {
            Assert.Throws<MinimalValueException>(() => a1.Transfer(a2, -5));
        }

        [Fact]
        public void Transfer_BalanceMustBeGreatherOrEqualsValue()
        {
            Assert.Throws<InsufficientFundsException>(() => a1.Transfer(a2, a1.Balance + 1));
        }
    }
}
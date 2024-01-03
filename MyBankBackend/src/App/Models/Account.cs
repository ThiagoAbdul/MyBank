using MyBank.Exceptions;

namespace MyBank.Models
{
    public class Account : EntityBase
    {
        public decimal Balance { get; set; } = 0;
        public string Number { get; set; }
        public string Password { get; set; }
        public Customer Customer { get; set; }
        public Guid CustomerId { get; set; }

        Account() { }

        public Account(string number, string password, Customer customer)
        {
            Number = number;
            Password = password;
            Customer = customer;
            CustomerId = customer.Id;
        }


        public Transaction Transfer(Account otherAccount, decimal value)
        {
            if(value <= 0)
                throw new MinimalValueException();
            if (this.Balance < value)
                throw new InsufficientFundsException();

            this.Balance -= value;
            otherAccount.Balance += value;
            return new Transaction(value, this, otherAccount);
        }

    }
}

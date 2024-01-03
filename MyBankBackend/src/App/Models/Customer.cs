using MyBank.Exceptions;

namespace MyBank.Models
{
    public class Customer : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateOnly? BirthDate { get; set; }
        public Account? Account{ get; set; }

        Customer() { }
        public Customer(string firstName, string lastName, string email, DateOnly birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
        }

        public Account CreateAccount(string accountNumber, string password)
        {
            if (BirthDate?.ToDateTime(TimeOnly.MinValue).AddYears(18) > DateTime.Today)
            {
                    throw new UnderageCustomerException();
            }
            Account = new Account(accountNumber, password, this);
            return Account;
        }

    }
}

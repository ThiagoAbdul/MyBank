namespace MyBank.Models
{
    public class Account
    {
        public Guid Id { get; set; }
        public decimal Balance { get; set; }
        public string Number { get; set; }
        public string Password { get; set; }
        public Customer Customer { get; set; }
        public Guid CustomerId { get; set; }

    }
}

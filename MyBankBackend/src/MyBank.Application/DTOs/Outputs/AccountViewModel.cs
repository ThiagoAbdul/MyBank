namespace MyBank.DTOs.Outputs
{
    public class AccountViewModel
    {
        public Guid Id { get; set; }
        public decimal Balance { get; set; }
        public string Number { get; set; }
        public CustomerViewModel Customer { get; set; }
    }
}
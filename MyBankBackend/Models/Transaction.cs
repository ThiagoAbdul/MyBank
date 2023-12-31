namespace MyBank.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public decimal Value { get; set; } 
        public DateTime Timestamp { get; set; }
        public Account Sender{ get; set; }
        public Guid SenderId { get; set; }
        public Account Receiver { get; set; }
        public Guid ReceiverId { get; set; }
    }
}

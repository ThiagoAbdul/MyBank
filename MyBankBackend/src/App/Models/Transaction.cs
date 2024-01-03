namespace MyBank.Models
{
    public class Transaction : EntityBase
    {
        public decimal Value { get; set; } 
        public DateTime Timestamp { get; set; }
        public Account Sender{ get; set; }
        public Guid SenderId { get; set; }
        public Account Receiver { get; set; }
        public Guid ReceiverId { get; set; }

        Transaction() { }
        
        public Transaction(decimal value, Account sender, Account receiver){
            Value = value;
            Sender = sender;
            SenderId = sender.Id;
            Receiver = receiver;
            ReceiverId = receiver.Id;
            Timestamp = DateTime.Now;
        }
    }
}

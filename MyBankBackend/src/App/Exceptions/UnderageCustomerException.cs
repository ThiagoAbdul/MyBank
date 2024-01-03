namespace MyBank.Exceptions
{
    public class UnderageCustomerException : Exception
    {
        public UnderageCustomerException() : base($"Customer is underage") { }
    }
}
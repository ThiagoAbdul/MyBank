namespace MyBank.Exceptions
{
    public class EmailAlreadyRegisteredException : Exception
    {
        public EmailAlreadyRegisteredException(string email) : base($"Email already registered: {email}") { }
    }
}
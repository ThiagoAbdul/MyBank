namespace MyBank.Exceptions
{
    public class MinimalValueException: Exception
    {
        public MinimalValueException() : base("Value for transfers must be positive") { }
    }
}
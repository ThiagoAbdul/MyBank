namespace MyBank.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException() : this("Entity") { }
        public EntityNotFoundException(string entityName) : base ($"{entityName} not found") { }
    }
}
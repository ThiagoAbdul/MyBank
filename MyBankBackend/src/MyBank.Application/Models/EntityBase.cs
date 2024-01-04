namespace MyBank.Models
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }
        public bool Deleted { get; set; } = false;
    }
}
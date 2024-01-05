namespace MyBank.Events
{
    public record EmailConfirmationRequestEvent(string Email, Guid CustomerId);
}
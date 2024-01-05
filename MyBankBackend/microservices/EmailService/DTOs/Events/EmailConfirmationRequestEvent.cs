namespace EmailService.Events
{
    public record EmailConfirmationRequestEvent(string Email, Guid CustomerId);
}
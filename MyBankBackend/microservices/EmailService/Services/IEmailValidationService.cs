namespace EmailService.Services
{
    public interface IEmailValidationService
    {
        Task ValidateEmail(string email, Guid customerId);
    }
}
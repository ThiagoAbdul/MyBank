namespace EmailService.Services
{
    public class EmailValidationService : IEmailValidationService 
    {
        readonly ILogger<EmailValidationService> _logger;
        public EmailValidationService(ILogger<EmailValidationService> logger)
        {
            _logger =logger;
        }
        public Task ValidateEmail(string email, Guid customerId){
            return Task.Run(() => 
            {
                Thread.Sleep(2000);
                _logger.LogInformation(email);
            });                                                        
        }
    }
}
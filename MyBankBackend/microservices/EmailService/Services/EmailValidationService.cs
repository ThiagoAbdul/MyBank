using EmailService.Models;
using EmailService.Repositories;

namespace EmailService.Services
{
    public class EmailValidationService : IEmailValidationService 
    {
        private readonly ILogger<EmailValidationService> _logger;
        private readonly IEmailValidationRepository _emailValidationRepository; 
        public EmailValidationService(
            IEmailValidationRepository emailValidationRepository,
            ILogger<EmailValidationService> logger)
        {
            _emailValidationRepository = emailValidationRepository;
            _logger = logger;
        }
        public async Task ValidateEmail(string email, Guid customerId){
            var emailValidation = new EmailValidation(email, customerId);
            await _emailValidationRepository.CreateAsync(emailValidation);
            _logger.LogInformation("email: {}\nid: {}\ntoken: {}", 
            emailValidation.Email, emailValidation.Id, emailValidation.Token);                                                
        }
    }
}
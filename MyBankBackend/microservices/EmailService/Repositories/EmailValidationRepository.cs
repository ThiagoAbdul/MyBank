using EmailService.Data;
using EmailService.Models;
using Microsoft.Extensions.Options;

namespace EmailService.Repositories;

public class EmailValidationRepository : RepositoryBase<EmailValidation>, IEmailValidationRepository
{
    

    public EmailValidationRepository(
        IOptions<DatabaseConfiguration> options
    ) : base(options, "EmailValidation") { }
}
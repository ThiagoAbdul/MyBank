using EmailService.Events;
using EmailService.Messaging;
using EmailService.Services;

namespace EmailService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public IServiceProvider Services { get; set; }

    public Worker(IServiceProvider serviceProvider,    
                ILogger<Worker> logger)
    {
        Services = serviceProvider;
        _logger = logger;
    }


    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using (var scope = Services.CreateScope())
        {
            var emailValidationService = 
                scope.ServiceProvider
                    .GetRequiredService<IEmailValidationService>();
            var messagingClient = 
                scope.ServiceProvider
                    .GetRequiredService<IMessagingClient>();

            await messagingClient.Consume<EmailConfirmationRequestEvent>(
            "email-service.email-confirmation-requested", 
            async @event => 
            {
                await emailValidationService.ValidateEmail(@event.Email, @event.CustomerId);
            });
            
        }

    }
}

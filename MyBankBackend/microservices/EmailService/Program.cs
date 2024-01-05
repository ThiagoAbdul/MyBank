using EmailService;
using EmailService.Messaging;
using EmailService.Services;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddScoped<IEmailValidationService, EmailValidationService>();
builder.Services.AddScoped<IMessagingClient, RabbitClient>();
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();

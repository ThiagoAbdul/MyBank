using EmailService;
using EmailService.Data;
using EmailService.Messaging;
using EmailService.Repositories;
using EmailService.Services;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddScoped<IEmailValidationRepository, EmailValidationRepository>();

builder.Services.AddScoped<IEmailValidationService, EmailValidationService>();
builder.Services.AddScoped<IMessagingClient, RabbitClient>();


builder.Services.AddHostedService<Worker>();

builder.Services.Configure<DatabaseConfiguration>(
    builder.Configuration.GetSection("EmailServiceDatabase"));

var host = builder.Build();
host.Run();

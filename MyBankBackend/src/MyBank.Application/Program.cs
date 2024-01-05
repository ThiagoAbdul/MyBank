using Microsoft.EntityFrameworkCore;
using MyBank.Clients;
using MyBank.Configurations;
using MyBank.Data;
using MyBank.Mappers;
using MyBank.Messaging;
using MyBank.Repositories;
using MyBank.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
           .AddJsonOptions(options =>
            {
               options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
            });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<AppDbContext>(
    options => options.UseNpgsql(
        Environment.GetEnvironmentVariable(
        "DB_CONNECTION_STRING") ??
        builder.Configuration.GetConnectionString("DevDatabase"
        ))
    );

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IMessagingClient, RabbitClient>();

builder.Services.AddScoped<IEmailServiceClient, EmailServiceClient>();

builder.Services.AddAutoMapper(typeof(CustomerProfile).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

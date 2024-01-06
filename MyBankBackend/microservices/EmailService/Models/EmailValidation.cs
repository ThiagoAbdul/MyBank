namespace EmailService.Models;

public class EmailValidation : ModelBase
{

    public Guid CustomerId { get; set; }        
    public string Email { get; set; }
    public Guid Token { get; set; }
    public DateTime Expiration { get; set; }

    public EmailValidation(){}
    public EmailValidation(string email, Guid customerId)
    {
        Email = email;
        CustomerId = customerId;
        Token = Guid.NewGuid();
        Expiration = DateTime.Now.AddHours(1);
    }
}
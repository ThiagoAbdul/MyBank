namespace MyBank.Clients
{
    public interface IEmailServiceClient
    {
        void SendEmailConfirmationRequest(string email, Guid customerId);
    }
}
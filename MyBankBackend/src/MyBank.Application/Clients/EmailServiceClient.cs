using MyBank.Events;
using MyBank.Messaging;

namespace MyBank.Clients
{
    public class EmailServiceClient : IEmailServiceClient
    {

        private readonly IMessagingClient _messagingClient;
        private const string ROUTING_KEY_SUBSCRIBE = "email-confirmation-requested";
        public EmailServiceClient(IMessagingClient messagingClient)
        {
            _messagingClient = messagingClient;
        }

        public void SendEmailConfirmationRequest(string email, Guid customerId)
        {
            var requestEvent = new EmailConfirmationRequestEvent(email, customerId);
            _messagingClient.Publish(requestEvent, ROUTING_KEY_SUBSCRIBE);
        }
    } 
}
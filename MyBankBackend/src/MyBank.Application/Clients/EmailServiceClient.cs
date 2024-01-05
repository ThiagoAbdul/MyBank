using MyBank.Events;
using MyBank.Messaging;

namespace MyBank.Clients
{
    public class EmailServiceClient : IEmailServiceClient
    {

        private readonly IMessagePublisher _messagePublisher;
        private const string ROUTING_KEY_SUBSCRIBE = "email-confirmation-requested";
        public EmailServiceClient(IMessagePublisher messagePublisher)
        {
            _messagePublisher = messagePublisher;
        }

        public void SendEmailConfirmationRequest(string email, Guid customerId)
        {
            var requestEvent = new EmailConfirmationRequestEvent(email, customerId);
            _messagePublisher.Publish(requestEvent, ROUTING_KEY_SUBSCRIBE);
        }
    } 
}
using MyBank.Events;
using MyBank.Messaging;

namespace MyBank.Clients
{
    public class EmailServiceClient : IEmailServiceClient
    {

        private readonly IMessagePublisher _messagePublisher;
        private const string QUEUE_NAME = "email-service/email-confirmation-requested";
        private const string ROUTING_KEY_SUBSCRIBE = "email-confirmation-requested";
        public EmailServiceClient(IMessagePublisher messagePublisher)
        {
            _messagePublisher = messagePublisher;
            _messagePublisher.SetupQueue(QUEUE_NAME, ROUTING_KEY_SUBSCRIBE);
        }

        public void SendEmailConfirmationRequest(string email, Guid customerId)
        {
            var requestEvent = new EmailConfirmationRequestEvent(email, customerId);
            _messagePublisher.Publish(requestEvent, "email-confirmation-requested");
        }
    } 
}
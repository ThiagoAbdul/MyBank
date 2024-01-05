namespace MyBank.Messaging
{
    public interface IMessagingClient
    {
        void Publish(object data, string routingKey);

    }
}
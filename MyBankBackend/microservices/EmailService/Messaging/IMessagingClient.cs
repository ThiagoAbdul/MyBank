namespace EmailService.Messaging
{
    public interface IMessagingClient
    {
        void Publish(object data, string routingKey);
        Task Consume<T>(string queueName, Action<T> action);

    }
}
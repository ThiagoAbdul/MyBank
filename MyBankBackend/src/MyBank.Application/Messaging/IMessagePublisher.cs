namespace MyBank.Messaging
{
    public interface IMessagePublisher
    {
        void Publish(object data, string routingKey);
        void SetupQueue(string queueName, string routingKeySubscribe);
    }
}
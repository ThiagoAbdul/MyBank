using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace MyBank.Messaging
{
    public class MessagePublisher : IMessagePublisher
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private const string EXCHANGE_NAME = "mybank-service";

        public MessagePublisher()
        {
            var connectionFactory = new ConnectionFactory {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };
            _connection = connectionFactory.CreateConnection("mybank-service-publisher");
            _channel = _connection.CreateModel();
        }
        public void Publish(object data, string routingKey)
        {
            byte[] payload = ParseDataToPayload(data);
            _channel.BasicPublish(EXCHANGE_NAME, routingKey, null, payload);
        }

        private static byte[] ParseDataToPayload(object data)
        {
            string json = JsonConvert.SerializeObject(data);
            byte[] payload = Encoding.UTF8.GetBytes(json);
            return payload;
        }
    }
}
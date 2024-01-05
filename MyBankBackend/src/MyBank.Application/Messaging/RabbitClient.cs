using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace MyBank.Messaging
{
    public class RabbitClient : IMessagingClient
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private const string EXCHANGE_NAME = "mybank-service";
        private readonly ILogger<RabbitClient> _logger;

        public RabbitClient(ILogger<RabbitClient> logger)
        {
            _logger = logger;
            var connectionFactory = new ConnectionFactory {
                HostName = Environment.GetEnvironmentVariable("RABBIT_HOST") ?? "localhost",
                UserName = Environment.GetEnvironmentVariable("RABBIT_USER") ?? "guest",
                Password = Environment.GetEnvironmentVariable("RABBIT_PASS") ?? "guest"
            };
            _connection = connectionFactory.CreateConnection("mybank-service-publisher");
            _channel = _connection.CreateModel();
            
        }
        public void Publish(object data, string routingKey)
        {
            byte[] payload = SerializePayload(data);
            _channel.BasicPublish(EXCHANGE_NAME, routingKey, null, payload);
            _logger.LogInformation("Message published");
        }

        private static byte[] SerializePayload(object data)
        {
            string json = JsonConvert.SerializeObject(data);
            byte[] payload = Encoding.UTF8.GetBytes(json);
            return payload;
        }
    }
}
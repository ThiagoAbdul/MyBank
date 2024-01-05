using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace EmailService.Messaging
{
    public class RabbitClient : IMessagingClient
    {

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
            IConnection _connection = connectionFactory.CreateConnection("mybank-service-publisher");
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

        public Task Consume<T>(string queueName, Action<T> action)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (sender, eventArgs) => 
            {
                T t = DeserializePayload<T>(eventArgs);
                action.Invoke(t);
                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };
            _channel.BasicConsume(queueName, false, consumer);
            return Task.CompletedTask;

        }

        private static T DeserializePayload<T>(BasicDeliverEventArgs eventArgs)
        {
            var byteArray = eventArgs.Body.ToArray();
            string json = Encoding.UTF8.GetString(byteArray);
            T? t = JsonConvert.DeserializeObject<T>(json)
                ?? throw new Exception("Error at deserialization");
            return t;
        }
    }
}
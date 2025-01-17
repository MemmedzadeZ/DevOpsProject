using Microsoft.AspNetCore.Connections;
using MusicService.Web_API.Services.Abstruct;
using RabbitMQ.Client;
using System.Text;


namespace MusicService.Web_API.Services.Concrete
{
    public class RabbitMQService : IRabbitMQService
    {
        private readonly ConnectionFactory _factory;

        public RabbitMQService(IConfiguration configuration)
        {
            _factory = new ConnectionFactory
            {
                HostName = configuration["RabbitMQ:HostName"],
                Port = int.Parse(configuration["RabbitMQ:Port"]),
                UserName = configuration["RabbitMQ:UserName"],
                Password = configuration["RabbitMQ:Password"],
                VirtualHost = configuration["RabbitMQ:VirtualHost"]
            };
        }

        public async Task AddMusicMessage(string musicId, string message)
        {
            using var connection = _factory.CreateConnection();
            using var channel = connection.CreateModel();

            // Declare the queue with the musicId as the name
            channel.QueueDeclare(queue: musicId,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var body = Encoding.UTF8.GetBytes(message);

            // Publish the message to the RabbitMQ queue
            channel.BasicPublish(exchange: "",
                                 routingKey: musicId,
                                 basicProperties: null,
                                 body: body);

            await Task.CompletedTask;  // Ensure the method completes asynchronously
        }

        public async Task<List<string>> GetMusicMessages(string musicId)
        {
            var messages = new List<string>();

            using var connection = _factory.CreateConnection();
            using var channel = connection.CreateModel();

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                messages.Add(message);
            };

            // Consume the message from the queue
            channel.BasicConsume(queue: musicId,
                                 noAck: true,
                                 consumer: consumer);

            // Introduce a delay to ensure the consumer has time to receive messages
            await Task.Delay(1000);

            return messages;
        }
    }
}

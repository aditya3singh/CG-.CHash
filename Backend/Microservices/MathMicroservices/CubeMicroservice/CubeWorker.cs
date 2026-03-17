using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace CubeMicroservice
{
    public class CubeWorker : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = await factory.CreateConnectionAsync();
            var channel = await connection.CreateChannelAsync();

            await channel.ExchangeDeclareAsync(exchange: "math_exchange", type: ExchangeType.Fanout);
            await channel.QueueDeclareAsync(queue: "cube_queue", durable: false, exclusive: false, autoDelete: false);
            await channel.QueueBindAsync(queue: "cube_queue", exchange: "math_exchange", routingKey: "");

            Console.WriteLine("======== Cube Microservice Started ========");

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += async (sender, ea) =>
            {
                var body = ea.Body.ToArray();
                int number = int.Parse(Encoding.UTF8.GetString(body));

                // Extract the Correlation ID
                string correlationId = ea.BasicProperties.CorrelationId ?? "No-ID";

                // Include the Correlation ID in the log
                Console.WriteLine($"[Cube Service] [ID: {correlationId}] Received: {number} -> Cube is: {number * number * number}");

                await Task.CompletedTask;
            };

            await channel.BasicConsumeAsync(queue: "cube_queue", autoAck: true, consumer: consumer);

            await Task.Delay(Timeout.Infinite, stoppingToken);
        }
    }
}
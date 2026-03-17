using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace SquareMicroservice
{
    public class SquareWorker : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = await factory.CreateConnectionAsync();
            var channel = await connection.CreateChannelAsync();

            // 1. Ensure the exchange exists
            await channel.ExchangeDeclareAsync(exchange: "math_exchange", type: ExchangeType.Fanout);

            // 2. Declare the specific queue for this microservice
            await channel.QueueDeclareAsync(queue: "square_queue", durable: false, exclusive: false, autoDelete: false);

            // 3. Bind the queue to the exchange
            await channel.QueueBindAsync(queue: "square_queue", exchange: "math_exchange", routingKey: "");

            Console.WriteLine("======== Square Microservice Started ========");

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += async (sender, ea) =>
            {
                var body = ea.Body.ToArray();
                int number = int.Parse(Encoding.UTF8.GetString(body));

                // Extract the Correlation ID from the message properties
                string correlationId = ea.BasicProperties.CorrelationId ?? "No-ID";

                // Include the Correlation ID in the log
                Console.WriteLine($"[Square Service] [ID: {correlationId}] Received: {number} -> Square is: {number * number}");

                await Task.CompletedTask;
            };

            await channel.BasicConsumeAsync(queue: "square_queue", autoAck: true, consumer: consumer);

            // Keep service alive
            await Task.Delay(Timeout.Infinite, stoppingToken);
        }
    }
}
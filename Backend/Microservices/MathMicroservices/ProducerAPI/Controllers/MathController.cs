using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;

namespace ProducerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MathController : ControllerBase
    {
        [HttpGet("{number}")]
        public async Task<IActionResult> SendNumber(int number)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            await using var connection = await factory.CreateConnectionAsync();
            await using var channel = await connection.CreateChannelAsync();

            await channel.ExchangeDeclareAsync(exchange: "math_exchange", type: ExchangeType.Fanout);

            var message = number.ToString();
            var body = Encoding.UTF8.GetBytes(message);

            // 1. Generate a unique Correlation ID for this specific request
            var correlationId = Guid.NewGuid().ToString();

            // 2. Create the BasicProperties and assign the ID
            var properties = new BasicProperties
            {
                CorrelationId = correlationId
            };

            // 3. Pass the properties into the Publish method
            await channel.BasicPublishAsync(
                exchange: "math_exchange",
                routingKey: "",
                mandatory: false,
                basicProperties: properties,
                body: body);

            return Ok($"Number {number} sent! Correlation ID: {correlationId}");
        }
    }
}
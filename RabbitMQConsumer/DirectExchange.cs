using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQConsumer
{
    internal class DirectExchange
    {

        public DirectExchange() { }

        public async Task DirectExchangeConsumer()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            var connection = await factory.CreateConnectionAsync(); // create connection

            var channel = await connection.CreateChannelAsync(); // create rmq instence or object



            var consumer = new AsyncEventingBasicConsumer(channel);

            // this event is raised when a message is received or this a delegate
            consumer.ReceivedAsync += async (sender, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                Console.WriteLine($"Message received: {message}");
            };


            await channel.BasicConsumeAsync(queue: "TestDirectQ", autoAck: true, consumer: consumer);

            Console.WriteLine(consumer);

            Console.WriteLine("All messages received");

            Console.ReadLine();
        }
    }
}

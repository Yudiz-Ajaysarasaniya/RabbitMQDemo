using RabbitMQ.Client;
using System.Text;



var factory = new ConnectionFactory() { HostName = "localhost" };

var connection = await factory.CreateConnectionAsync(); // create connection

var channel = await connection.CreateChannelAsync(); // create rmq instence or object


//channel.BasicPublishAsync(exchange: "", routingKey: "TestQ", mandatory: false, basicProperties: null, body: Encoding.UTF8.GetBytes("Hello World!"), CancellationToken.None);

var message = "Testing RabbitMQ By Creating New Exchange and Queue";


// Using Direct Exchange
//for (int i = 1; i <= 10; i++)
//{
//    message = "Testing RabbitMQ By Creating New Exchange and Queue :" + i;

//    var messagebody = Encoding.UTF8.GetBytes(message);

//    var properties = new BasicProperties();
//    await channel.BasicPublishAsync(exchange: "TestDirect", routingKey: "TestKey", mandatory: false, basicProperties: properties, body: messagebody, CancellationToken.None);

//}

// Using Fanout Exchange
for (int i = 1; i <= 10; i++)
{
    message = "Testing RabbitMQ By Creating New Exchange and Queue :" + i;

    var messagebody = Encoding.UTF8.GetBytes(message);

    var properties = new BasicProperties();
    await channel.BasicPublishAsync(exchange: "FanOutExchange", routingKey: "", mandatory: false, basicProperties: properties, body: messagebody, CancellationToken.None);

}

Console.WriteLine(" [x] Sent {0}", message);

Console.ReadLine();







//channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);
//string message = "Hello World!";
//var body = Encoding.UTF8.GetBytes(message);
//channel.BasicPublish(exchange: "", routingKey: "hello", basicProperties: null, body: body);
//Console.WriteLine(" [x] Sent {0}", message);



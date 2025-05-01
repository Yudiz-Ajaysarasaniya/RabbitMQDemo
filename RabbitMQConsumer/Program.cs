using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQConsumer;
using System.Text;



FanOutExchange fanOutExchange = new FanOutExchange();
await fanOutExchange.FanOutExchangeConsumer();
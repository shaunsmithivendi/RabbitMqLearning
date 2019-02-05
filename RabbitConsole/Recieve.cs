using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace RabbitRecieve
{
    public class Recieve
    {
        public void Receieve()
        {
            var factory = new ConnectionFactory() { HostName = "localhost", Port = 32768 };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "MessageTest",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received {0}", message);
                };
                channel.BasicConsume(queue: "MessageTest",
                                     autoAck: true,
                                     consumer: consumer);

                Console.WriteLine("Press any key to confirm Message");
                Console.ReadLine();
            }
        }
    }
}

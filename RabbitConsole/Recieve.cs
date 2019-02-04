using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Collections.Generic;

namespace RabbitRecieve
{
    public class Recieve
    {
        public string Receieve()
        {
            string message = "No message found";
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
                    message = Encoding.UTF8.GetString(body);
                };
                channel.BasicConsume(queue: "MessageTest",
                                     autoAck: true,
                                     consumer: consumer);
                
            }
            return message;
        }
    }
}

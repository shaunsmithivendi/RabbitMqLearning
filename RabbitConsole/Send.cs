using System;
using RabbitMQ.Client;
using System.Text;

namespace RabbitSend
{
    public class Send
    {
        public bool SendMessage() {

            Console.WriteLine("Please Enter a message to enter follow by the Enter Key");
            var message = Console.ReadLine();

            var factory = new ConnectionFactory() { HostName = "localhost", Port = 32768};

            bool sent = false; 

            using (var connection = factory.CreateConnection())
            
                using (var channel = connection.CreateModel())                                                         
                {
                    channel.QueueDeclare(
                        queue: "MessageTest",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    var body = Encoding.UTF8.GetBytes(message);
                    
                    channel.BasicPublish(
                        exchange: "",
                        routingKey: "MessageTest",
                        basicProperties: null,
                        body:body
                        );
                    sent = true;

                }
            return sent;
        }           
    }
}

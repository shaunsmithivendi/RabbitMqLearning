using System;
using System.Collections.Generic;
using System.Text;
using RabbitSend;
using RabbitRecieve;

namespace RabbitConsole
{
    public class RabbitConsole
    {

        public static void Main() {
            int option;
            string input;

            while (true)
            {
                Console.WriteLine("Please choose from the following options (1, 2, 3):" + "\n" + "1. Send Message to Queue" + "\n" + "2. Receieve Message" + "\n" + "3. Exit");
                input = Console.ReadLine();
                if (input == "1" || input == "2" || input == "3")
                {
                    Int32.TryParse(input, out option);
                    if (option == 1)
                    {
                        var rabbitSend = new Send();
                        var sucess = rabbitSend.SendMessage();
                        if (sucess == true)
                        {
                            Console.WriteLine("Message Sent Succesfully!");
                        }
                        else
                        {
                            Console.WriteLine("Failed to send Message!");
                        }
                    }
                    else if (option == 2)
                    {
                        var rabbitReceieve = new Recieve();
                        rabbitReceieve.Receieve();
                    }
                    else if (option == 3)
                    {
                        break;
                    }                    
                }
                else
                {
                    Console.WriteLine("Invalid option! Please try again!");
                }
            }

        }    
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitConsole
{
    public class RabbitConsole
    {

        public static void Main() {

            int option;
            string input;

            while (true)
            {
                Console.WriteLine("Please choose from the following options (1, 2, 3, 4):" + "\n" + "1. ");
                input = Console.ReadLine();
                if (input == "1" || input == "2" || input == "3" || input == "4")
                {
                    Int32.TryParse(input, out option);
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option! Please try again!");
                }
            }





        }

    }
}

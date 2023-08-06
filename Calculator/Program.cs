using System;

namespace Maths
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Write allows you to stay on the same line in the terminal as compared to Console.WriteLine which 
            //places user in the next line like /n

            //Ask the user for the first number
            Console.Write("Input the first number: ");
            double firstNum = double.Parse(Console.ReadLine());

            Console.Write("Input the second number: ");
            double secondNum = double.Parse(Console.ReadLine());

            Console.Write("Do you want to + - * /? ");
            string operation = Console.ReadLine();

            if (operation == "+")
            {
                Console.WriteLine("Answer: " + (firstNum + secondNum));
            }
            else if (operation == "-")
            {
                Console.WriteLine("Answer: " + (firstNum - secondNum));
            }
            else if (operation == "*")
            {
                Console.WriteLine("Answer: " + (firstNum * secondNum));
            }
            else if (operation == "/")
            {
                Console.WriteLine("Answer: " + (firstNum / secondNum));
            }
            else {
                Console.WriteLine("Error please try again");
            }



        }
    }
}
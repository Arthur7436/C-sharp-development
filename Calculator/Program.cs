using System;

namespace Maths
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                //Console.Write allows you to stay on the same line in the terminal as compared to Console.WriteLine which 
                //places user in the next line like /n

                //Ask the user for the first number
                Console.Write("Input the first number: ");
                //If the user inputs "q", then the program breaks
                string firstNumInput = Console.ReadLine();
                if (firstNumInput == "q")
                {
                    break;
                }

                double firstNum = double.Parse(firstNumInput);


                //Ask the user for the second number
                Console.Write("Input the second number: ");
                //If the user inputs "q", then the program breaks
                string secondNumInput = Console.ReadLine();
                if (secondNumInput == "q")
                {
                    break;
                }

                double secondNum = double.Parse(secondNumInput);

                //Ask the user which operator they would want to user
                Console.Write("Do you want to + - * /? ");
                string operation = Console.ReadLine();

                //If else statements will determine the answers
                if (operation == "+")
                {
                    Console.WriteLine("Answer: " + (firstNum + secondNum).ToString("F2"));
                }
                else if (operation == "-")
                {
                    Console.WriteLine("Answer: " + (firstNum - secondNum).ToString("F2"));
                }
                else if (operation == "*")
                {
                    Console.WriteLine("Answer: " + (firstNum * secondNum).ToString("F2"));
                }
                else if (operation == "/")
                {
                    if (secondNum != 0)
                    {
                        Console.WriteLine("Answer: " + (firstNum / secondNum).ToString("F2"));
                    }
                    else
                    {
                        Console.WriteLine("Cannot be divided by the value 0");
                    }
                }
                else
                {
                    Console.WriteLine("Error please try again");
                }


            }
        }
    }
}
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
                double firstNum;
                do
                {
                    //Ask the user for the first number
                    Console.Write("Input the first number: ");
                    //Store the first value into the string firstNumInput
                    string firstNumInput = Console.ReadLine();
                    //If the user inputs "q", then the program breaks
                    if (firstNumInput == "q")
                    {
                        return;
                    }

                    if (double.TryParse(firstNumInput, out firstNum))
                    {
                        break; //Parsing successful, break the loop
                    }
                    // If the user inputs a non numerical character then give an error for them to try again
                    else
                    {
                        Console.WriteLine("Invalid input, please try again.");
                    }
                }
                while (true);

                //Ask the user for the second number
                Console.Write("Input the second number: ");
                //Store the second value into the string secondNumInput
                string secondNumInput = Console.ReadLine();
                //If the user inputs "q", then the program breaks
                if (secondNumInput == "q")
                {
                    break;
                }

                //If user DOES NOT input "q", then parse the string into 2 decimal places and store it in the variable secondNum
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
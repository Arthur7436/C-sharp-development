using System;
using Class;

namespace Practice
{
    class Program
    {
        public static void Main(string[] args)
        {
            Calculation();

        }

        public static void Calculation()
        {
            Console.Write("Would you like to + - * / ? ");
            string operation = Console.ReadLine();

            Console.Write("Please insert first number: ");
            double num1 = double.Parse(Console.ReadLine());
            Console.Write("Please insert second number: ");
            double num2 = double.Parse(Console.ReadLine());

            if (operation == "+")
            {
                double answer = Addition(num1, num2);
                Console.WriteLine($"The sum of {num1} and {num2} is {answer}");
            }
            else if (operation == "-")
            {
                double answer = Subtraction(num1, num2);
                Console.WriteLine($"The subtraction of {num1} and {num2} is {answer}");
            }
            else if (operation == "*")
            {
                double answer = Multiplication(num1, num2);
                Console.WriteLine($"The multiples of {num1} and {num2} is {answer}");
            }
            else if (operation == "/")
            {
                double answer = Division(num1, num2);
                Console.WriteLine($"The division of {num1} and {num2} is {answer}");
            }
            else
            {
                Console.WriteLine("Error Try again");
            }

           
        }

        public static double Addition(double a, double b) {

        return a + b;

        }

        public static double Subtraction(double a, double b)
        {

            return a - b;

        }

        public static double Multiplication(double a, double b)
        {

            return a * b;

        }

        public static double Division(double a, double b)
        {

            return a / b;

        }


    }
}
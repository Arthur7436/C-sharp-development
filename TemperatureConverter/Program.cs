using System;

namespace TemperatureConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> temperatureOptions = new List<string> { "Celcius", "Fahrenheit" };
            do
            {
                Console.Clear();
                Console.WriteLine("Which temperature would you like to convert FROM?");
                for (int i = 0; i < temperatureOptions.Count; i++) //list out the opti
                {
                    Console.WriteLine((i + 1) + ". " + temperatureOptions[i]);
                }
                Console.WriteLine("To exit the program please type 'Exit'");

                Console.WriteLine("");

                do
                {
                    Console.Write("Please insert number: ");
                    string answer = Console.ReadLine();
                    Console.WriteLine("");


                    if (answer == "1" || answer == "celcius" || answer == "Celcius")
                    {
                        Console.WriteLine("You have chosen Celcius");
                        Console.Write("Please enter the number you want to convert INTO Fahrenheit FROM Celcius: ");
                        double fahrenheitAnswer = double.Parse(Console.ReadLine());
                        double fahrenheitConversion = (fahrenheitAnswer * 1.8) + 32;
                        Console.Write("The conversion to Fahrenheit is: ");
                        Console.WriteLine(fahrenheitConversion + " degrees");
                        Console.WriteLine("Please press any key to return back to the menu");
                        Console.ReadLine();
                        break;

                    }
                    else if (answer == "2" || answer == "Fahrenheit" || answer == "fahrenheit")
                    {
                        Console.WriteLine("you have chosen Fahrenheit");
                        Console.Write("Please enter the number you want to convert INTO Celcius FROM Fahrenheit: ");
                        double celciusAnswer = double.Parse(Console.ReadLine());
                        double celciusConversion = (celciusAnswer - 32) / (1.8);
                        Console.Write("The conversion to Celcius is: ");
                        Console.WriteLine(celciusConversion + " degrees");
                        Console.WriteLine("Please press any key to return back to the menu");
                        Console.ReadLine();
                        break;
                    }
                    else if (answer == "exit" || answer == "Exit")
                    {
                        return;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: Incorrect input, please try again");
                        Console.ResetColor();
                    }
                }
                while (true);
            }
            while (true);

        }
    }
}
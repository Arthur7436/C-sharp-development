using System;

namespace WeatherApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Weather App!");
            do
            {
                Console.Write("Please enter the city that you want to check the weather at: ");
                string city = Console.ReadLine();


                if (city.All(char => char.IsLetter(c) || char.IsWhiteSpace(c)) && !string.IsNullOrWhiteSpace(city))
                {

                }
                else
                {
                    Console.WriteLine("Invalid city name. Please enter a valid city name");
                }
            }
            while (true);
        }
    }
}

using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace WeatherApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "api.openweathermap.org/data/2.5/weather?q=London,uk&APPID=3d4dfc51d1c525476468da067621d472";

            Console.WriteLine("Welcome to the Weather App!");
            do
            {
                Console.Write("Please enter the city that you want to check the weather at: ");
                string city = Console.ReadLine();


                if (city.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)) && !string.IsNullOrWhiteSpace(city))
                {
                    Console.WriteLine("The city entered is valid");

                    using (HttpClient httpClient = new HttpClient())
                    {

                    }
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

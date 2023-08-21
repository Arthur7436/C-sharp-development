using System;
using ClassLibrary;

namespace WeatherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = OtherClass.GetName();
            Console.WriteLine($"Hello {name}");
        }
    }
}

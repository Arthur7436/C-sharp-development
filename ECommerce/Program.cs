using System;

namespace ECommercePlatform
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Ecommerce platform!");
                Console.WriteLine("Please choose which user you want to be: ");
                string? input = Console.ReadLine();

                List<string> displayMenu = new List<string>()
                {
                    "1. View all products",
                    "2. Add a product",
                    "3. Remove a product",
                    "Enter 'q' to exit the program"
                };

                if (input == "q")
                {
                    //quit program
                }
                else if (input == "1")
                {
                    //view all products
                }
                if (input == "2")
                {
                    //add product
                }
                if (input == "3")
                {
                    //remove a product
                }
            } while (true);
        }
    }
}

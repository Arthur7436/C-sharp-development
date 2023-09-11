using System;
using ECommercePlatform.Roles;
using People;

namespace ECommercePlatform
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to the ecommerce platform!");
                Console.WriteLine("Please choose which user you want to be: ");

                DisplayMenu.DisplayListAndChoice();

            } while (DisplayMenu.keepRunning);
        }
    }
}

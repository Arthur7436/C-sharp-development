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

                List<string> userRolesDisplay = new List<string>
                {
                    "1. Admin",
                    "2. Buyer",
                    "3. Seller",
                    "Input 'q' to quit the program"
                };

                for (int i = 0; i < userRolesDisplay.Count; i++)
                {
                    Console.WriteLine(userRolesDisplay[i]);
                }

                Console.Write("Input: ");
                string? userRolesInput = Console.ReadLine();

                if (userRolesInput == "q")
                {
                    return;
                }
                else if (userRolesInput == "1" || userRolesInput == "Admin" || userRolesInput == "admin")
                {
                    Admin admin = UserCreation.CreateAdmin();
                    Console.WriteLine(admin.ToString());
                    Console.ReadLine();
                }
                else if (userRolesInput == "2" || userRolesInput == "Buyer" || userRolesInput == "buyer")
                {
                    Buyer buyer = UserCreation.CreateBuyer();
                    Console.WriteLine(buyer.ToString());
                    Console.ReadLine();
                }
                else if (userRolesInput == "3" || userRolesInput == "Seller" || userRolesInput == "seller")
                {
                    Seller seller = UserCreation.CreateSeller();
                    Console.WriteLine(seller.ToString());
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Invalid user input, please try again");
                    Console.WriteLine("Press any key to restart");
                    Console.ReadLine();
                }


            } while (true);
        }
    }
}

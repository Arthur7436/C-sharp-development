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
                Console.WriteLine("welcome to the ecommerce platform!");
                Console.WriteLine("Please choose which user you want to be: ");

                List<string> userRolesDisplay = new List<string>
                {
                    "1. Admin",
                    "2. Buyer",
                    "3. Seller"
                };

                for (int i = 0; i < userRolesDisplay.Count; i++)
                {
                    Console.WriteLine(userRolesDisplay);
                }
                
                Console.Write("Input: ");
                string? userRolesInput = Console.ReadLine();

                if (userRolesInput == "1" || userRolesInput == "Admin" || userRolesInput == "admin")
                {
                    Admin admin = UserCreation.CreateAdmin();

                    Console.WriteLine($"The user you logged in as is: ${admin.FirstName}");
                }
                if (userRolesInput == "2" || userRolesInput == "Buyer" || userRolesInput == "buyer")
                {
                    UserCreation.CreateSeller();
                }
                if (userRolesInput == "3" || userRolesInput == "Seller" || userRolesInput == "seller")
                {
                    UserCreation.CreateBuyer();
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

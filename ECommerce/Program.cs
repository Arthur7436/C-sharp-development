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

                    Console.WriteLine($"your user details are:");
                    Console.WriteLine($"Id: {admin.id}");
                    Console.WriteLine($"First name: {admin.FirstName}");
                    Console.WriteLine($"Last name: {admin.LastName}");
                    Console.WriteLine($"Email: {admin.Email}");
                    Console.WriteLine($"Country: {admin.Country}");

                    Console.ReadLine();
                }
                else if (userRolesInput == "2" || userRolesInput == "Buyer" || userRolesInput == "buyer")
                {
                    Buyer buyer = UserCreation.CreateBuyer();

                    Console.WriteLine($"your user details are:");
                    Console.WriteLine($"Id: {buyer.id}");
                    Console.WriteLine($"First name: {buyer.FirstName}");
                    Console.WriteLine($"Last name: {buyer.LastName}");
                    Console.WriteLine($"Email: {buyer.Email}");
                    Console.WriteLine($"Country: {buyer.Country}");

                    Console.ReadLine();
                }
                else if (userRolesInput == "3" || userRolesInput == "Seller" || userRolesInput == "seller")
                {
                    Seller seller = UserCreation.CreateSeller();

                    Console.WriteLine($"your user details are:");
                    Console.WriteLine($"Id: {seller.id}");
                    Console.WriteLine($"First name: {seller.FirstName}");
                    Console.WriteLine($"Last name: {seller.LastName}");
                    Console.WriteLine($"Email: {seller.Email}");
                    Console.WriteLine($"Country: {seller.Country}");

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

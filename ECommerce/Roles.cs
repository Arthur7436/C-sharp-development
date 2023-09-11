using System;
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;
using People;

namespace ECommercePlatform.Roles
{
    public class Admin
    {
        public int id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Country { get; set; }

        public override string ToString()
        {
            return
            $"Id: {id}\n" +
            $"First name: {FirstName}\n" +
            $"Last name: {LastName}\n" +
            $"Email: {Email}\n" +
            $"country: {Country}\n";
        }
    }


    public class Seller
    {
        public int id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Country { get; set; }

        public override string ToString()
        {
            return
            $"Id: {id}\n" +
            $"First name: {FirstName}\n" +
            $"Last name: {LastName}\n" +
            $"Email: {Email}\n" +
            $"country: {Country}\n";
        }

    }

    public class Buyer
    {
        public int id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Country { get; set; }

        public override string ToString()
        {
            return
            $"Id: {id}\n" +
            $"First name: {FirstName}\n" +
            $"Last name: {LastName}\n" +
            $"Email: {Email}\n" +
            $"country: {Country}\n";
        }
    }

    public class Display
    {
        public static void DisplayList()
        {
            List<string> userRoleDisplay = new List<string>()
                {
                    "1. Admin",
                    "2. Buyer",
                    "3. Seller",
                    "Input 'q' to quit the program"
                };

            for (int i = 0; i < userRoleDisplay.Count; i++)
            {
                Console.WriteLine(userRoleDisplay[i]);
            }
        }
    }

    public class Choice
    {
        public static void Displaychoice()
        {
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

        }
    }
}

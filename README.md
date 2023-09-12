I want to know how to add these user instances that are made from different classes to be added in one list so that I can show the list of all the users within the program.
Is it possible to delete theses from the list if the user chose to do so?

using ECommercePlatform.Roles;

namespace People
{
    public static class UserCreation
    {
        public static Admin CreateAdmin()
        {
            Admin admin = new();
            {
                admin.id = 123;
                admin.FirstName = "Arthur";
                admin.LastName = "Thai";
                admin.Email = "example@email.com";
                admin.Country = "country";
            };
            return admin;
        }

        public static Buyer CreateBuyer()
        {
            Buyer buyer = new();
            {
                buyer.id = 123;
                buyer.FirstName = "Buyer";
                buyer.LastName = "Thai";
                buyer.Email = "example@email.com";
                buyer.Country = "country";
            };
            return buyer;
        }

        public static Seller CreateSeller()
        {
            Seller seller = new();
            {
                seller.id = 123;
                seller.FirstName = "Seller";
                seller.LastName = "Thai";
                seller.Email = "example@email.com";
                seller.Country = "country";
            };
            return seller;
        }
    }
}

using UserChoice;

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

    public class DisplayMenu
    {
        public static bool keepRunning = true;
        public static void DisplayListAndChoice()
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
            Console.Write("Input: ");
            string? userRolesInput = Console.ReadLine();

            if (userRolesInput == "q")
            {
                keepRunning = false;
            }
            else if (userRolesInput == "1" || userRolesInput == "Admin" || userRolesInput == "admin")
            {
                Choices.AdminChoice();

                //After selecting admin > show action dashboard (1. View all users 2. Delete users 3.Add users 4.Delete products 5. quit from program)
                do
                {
                    Console.Clear();
                    List<string> AdminDashboard = new List<string>()
                    {
                        "1. View all users",
                        "2. Delete users",
                        "3. Add users",
                        "4. Delete products",
                        "5. Input 'q' to quit the program",
                    };

                    for (int i = 0; i < AdminDashboard.Count; i++)
                    {
                        Console.WriteLine($"{AdminDashboard[i]}");
                    }

                    Console.Write("Please enter input:");
                    string? input = Console.ReadLine();

                    if (input == "q")
                    {
                        return;
                    }
                    else if (input == "1")
                    {
                        //display all users and when press any key return to admin dashboard
                    }
                    else if (input == "2")
                    {
                        Console.WriteLine("You chose to delete users");
                        Console.WriteLine("Please choose which users to delete: ");
                        //Display list of all users in Program
                        //Based on which user they delete, remove that user from the list
                    }
                    else if (input == "3")
                    {
                        //Add users to the list
                    }
                    else if (input == "4")
                    {
                        //Show all the products that are available
                        //Based on input, delete product from the list
                    }




                } while (true);
            }
            else if (userRolesInput == "2" || userRolesInput == "Buyer" || userRolesInput == "buyer")
            {
                Choices.BuyerChoice();
            }
            else if (userRolesInput == "3" || userRolesInput == "Seller" || userRolesInput == "seller")
            {
                Choices.SellerChoice();
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

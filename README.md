I'm struggling to add these hard coded created objects within the userCreation class and add them to a list to be displayed. What might be wrong with my code 
and preventing me from doing that?

using ECommercePlatform.Roles;

namespace People
{
    public class UserCreation
    {
        public static List<User> users = new List<User>();
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
            users.Add(admin);
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
            users.Add(buyer);
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
            users.Add(seller);
            return seller;
        }
    }
}
using People;
using UserChoice;

namespace ECommercePlatform.Roles
{

    public class User
    {
        public int id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Country { get; set; }
    }

    public class Admin : User
    {
        public int Id { get; set; }
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


    public class Seller : User
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

    public class Buyer : User
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
                Choices.AdminChoice(); //displays the admin user details

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
                        Console.WriteLine($"{AdminDashboard[i]}"); //displays another dashboard
                    }

                    Console.Write("Please enter input:");
                    string? input = Console.ReadLine();

                    if (input == "q")
                    {
                        return; //returns to main menu
                    }
                    else if (input == "1")
                    {
                        //display all users 
                        //for (int i = 0; i < UserCreation.users.Count; i++)
                        //{
                        Console.WriteLine(UserCreation.users[0]);
                        Console.WriteLine(UserCreation.users[1]);
                        Console.WriteLine(UserCreation.users[2]);
                        //}
                        Console.ReadLine();
                    }
                    else if (input == "2")
                    {
                        Console.WriteLine("You chose to delete users");
                        Console.WriteLine("Please choose which users to delete: ");
                        //display all users
                        //remove chosen users
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

using ECommercePlatform.Roles;
using People;

namespace UserChoice
{
    public static class Choices
    {
        public static void AdminChoice()
        {
            Admin admin = UserCreation.CreateAdmin();
            Console.WriteLine(admin.ToString());
            Console.ReadLine();
        }

        public static void BuyerChoice()
        {
            Buyer buyer = UserCreation.CreateBuyer();
            Console.WriteLine(buyer.ToString());
            Console.ReadLine();
        }

        public static void SellerChoice()
        {
            Seller seller = UserCreation.CreateSeller();
            Console.WriteLine(seller.ToString());
            Console.ReadLine();
        }

    }
}

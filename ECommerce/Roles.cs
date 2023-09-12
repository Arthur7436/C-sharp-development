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

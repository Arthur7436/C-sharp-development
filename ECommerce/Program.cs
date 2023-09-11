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

                Console.Write("Input: ");
                string? userRolesInput = Console.ReadLine();

                if (userRolesInput == "1" || userRolesInput == "Admin" || userRolesInput == "admin") { }
                if (userRolesInput == "1" || userRolesInput == "Admin" || userRolesInput == "admin") { }
                if (userRolesInput == "1" || userRolesInput == "Admin" || userRolesInput == "admin") { }
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

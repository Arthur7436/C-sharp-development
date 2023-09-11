using ECommercePlatform.Roles;
//test
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

                DisplayMenu.DisplayListAndChoice();

            } while (DisplayMenu.keepRunning);
        }
    }
}

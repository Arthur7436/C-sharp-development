using System;

namespace BethanysPieShop
{
    class Program
    {
        public static void Main(string[] args)
        {
            do
            {
                welcome();

                Console.WriteLine("");

                listMenu();


            } while (true);

        }

        public static void welcome()
        {
            Console.WriteLine("Bethany's Pie Shop Employee App");
            Console.WriteLine("Select an action");
        }

        public static void listMenu()
        {
            List<string> listMenu = new List<string>();
            listMenu.Add("1: Register employee");
            listMenu.Add("2: Register work hours for employee");
            listMenu.Add("3: Pay employee");
            listMenu.Add("9: Quit application");

            for (int i = 0; i < listMenu.Count; i++)
            {
                Console.WriteLine(listMenu[i]);
            }

        }

        public static void registerEmployee()
        {

        }

    }
}


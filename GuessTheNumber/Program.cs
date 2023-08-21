using System;

namespace GuessTheNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int randomNumber = random.Next(1, 10);

            do
            {

                Console.Clear();
                Console.WriteLine("Welcome to 'Guess The Number' game!");
                Console.WriteLine("Please choose a number between 1 - 10");
                Console.Write("Insert number: ");

                int num = int.Parse(Console.ReadLine());

                if (num == randomNumber)
                {
                    Console.WriteLine("You got it!");
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect! Press Enter to try again");
                    Console.ReadLine();

                }


            }
            while (true);
        }
    }
}

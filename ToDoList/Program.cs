using System;

namespace ToDoList
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] options = { "Option 1", "Option 2", "Option 3", "Exit" };
            int selectedIndex = 0;
            ConsoleKeyInfo keyInfo;

            do
            {
                Console.Clear();
                Console.WriteLine("Use arrow keys to navigate through menu");

                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    
                }

            } while(true);
        }
    }
}


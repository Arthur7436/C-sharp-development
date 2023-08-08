using System;

namespace ToDoList
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] options = { "Show list", "Add", "Delete", "Exit" };
            int selectedIndex = 0;
            string topLine = "╔═══════════════════════════════════════╗";
            string middleLine = "║    Use arrow keys to navigate!        ║";
            string bottomLine = "╚═══════════════════════════════════════╝";
            string[] array = { "ToDo1", "Todo2" };

            do
            {
                Console.Clear();
                Console.WriteLine(topLine);
                Console.WriteLine(middleLine);
                Console.WriteLine(bottomLine);

                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Magenta;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.WriteLine(options[i]);
                    Console.ResetColor();
                }



                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex - 1 + options.Length) % options.Length;
                }

                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex + 1 + options.Length) % options.Length;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine("You have selected " + options[selectedIndex]);
                    if (options[selectedIndex] == "Show list")
                    {
                        for (int i = 0; i < array.Length; i++)
                        {
                            Console.WriteLine(array[i]);
                        }
                    }
                    break;
                }


            } while (true);
        }
    }
}


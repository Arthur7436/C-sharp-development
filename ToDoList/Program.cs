using System;

namespace ToDoList
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] menuOptions = { "Show list", "Add", "Delete", "Exit" };
            int selectedIndex = 0;
            string topLine = "╔═══════════════════════════════════════╗";
            string middleLine = "║    Use arrow keys to navigate!        ║";
            string bottomLine = "╚═══════════════════════════════════════╝";
            List<string> inputList = new List<string> { "Hello" };

            //string[] inputList = { "ToDo1", "Todo2" };

            do
            {
                Console.Clear();
                Console.WriteLine(topLine);
                Console.WriteLine(middleLine);
                Console.WriteLine(bottomLine);

                for (int i = 0; i < menuOptions.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Magenta;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.WriteLine(menuOptions[i]);
                    Console.ResetColor();
                }



                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex - 1 + menuOptions.Length) % menuOptions.Length;
                }

                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex + 1 + menuOptions.Length) % menuOptions.Length;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine("You have selected " + menuOptions[selectedIndex]);
                    if (menuOptions[selectedIndex] == "Show list")
                    {
                        for (int i = 0; i < inputList.Count; i++)
                        {
                            Console.WriteLine(inputList[i]);
                        }
                    }
                    else if (menuOptions[selectedIndex] == "Add")
                    {
                        Console.Clear();
                        Console.WriteLine("What would you like to add to your list?");
                        string addInput = Console.ReadLine();
                        inputList.Add(addInput);

                        Console.WriteLine("You have added the following to your list: " + addInput);

                    }
                    else if (menuOptions[selectedIndex] == "Delete")
                    {
                        Console.Clear();
                        Console.WriteLine("What would you like to delete from your list?");
                        for (int i = 0; i < inputList.Count; i++)
                        {
                            Console.WriteLine(inputList[i]);
                        }


                    }
                    break;

                }


            } while (true);
        }
    }
}


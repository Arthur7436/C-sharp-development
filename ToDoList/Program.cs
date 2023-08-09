using System;
using System.Collections.Generic;

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
            List<string> inputList = new List<string> { "1. Hello" };

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

                    if (menuOptions[selectedIndex] == "Exit")
                    {
                        break;
                    }
                    else if (menuOptions[selectedIndex] == "Show list")
                    {
                        for (int i = 0; i < inputList.Count; i++)
                        {
                                
                            Console.WriteLine("Here is your list:");
                            Console.WriteLine(inputList[i]);
                            Console.WriteLine("Press any key to return to main menu");
                            Console.ReadKey();
                            
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
                        Console.WriteLine("Choose the list by it's number");
                        for (int i = 0; i < inputList.Count; i++)
                        {
                            Console.WriteLine(inputList[i]);
                        }

                        int deleteNum = int.Parse(Console.ReadLine());

                        if (deleteNum > 0 && deleteNum < (inputList.Count + 1))
                        {
                            inputList.RemoveAt(deleteNum - 1);
                            Console.WriteLine("Item was successfully deleted");

                            Console.WriteLine("Here is the remainder of your list");
                            for (int i = 0; i < inputList.Count; i++)
                            {
                                Console.WriteLine(inputList[i]);
                            }

                        }
                        else
                        {
                            Console.WriteLine("The list number you inputted doesn't exist");
                        }

                    }


                }


            } while (true);
        }
    }
}


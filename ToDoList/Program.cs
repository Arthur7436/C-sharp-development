using System;
using System.Collections.Generic;

namespace ToDoList
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] menuOptions = { "Show list", "Add", "Delete", "Exit" }; //list of the menu options 
            List<string> inputList = new List<string> { "My first list" }; //creation of dynamic list to store new lists 
            int selectedIndex = 0; //initialize variable to 0
            //heading of program
            string topLine = "╔═══════════════════════════════════════╗";
            string middleLine = "║    Use arrow keys to navigate!        ║";
            string bottomLine = "╚═══════════════════════════════════════╝";

            //program doesn't stop until they select 'Exit' option
            do
            {
                Console.Clear();
                Console.WriteLine(topLine);
                Console.WriteLine(middleLine);
                Console.WriteLine(bottomLine);
                //whatever the selectedIndex is depending on the up and down arrow key, the background of that option will change
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


                //read the users key input and match to the option accordingly
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

                    if (menuOptions[selectedIndex] == "Exit") //if user selects exit then quit the program
                    {
                        break;
                    }
                    else if (menuOptions[selectedIndex] == "Show list") //if user selects show list
                    {
                        Console.Clear();
                        Console.WriteLine("Here is your list:");
                        for (int i = 0; i < inputList.Count; i++)
                        {
                            Console.WriteLine((i + 1) + ". " + inputList[i]);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Press any key to return to main menu");
                        Console.ReadKey();

                    }
                    else if (menuOptions[selectedIndex] == "Add") //if user selects add
                    {
                        Console.Clear();
                        Console.WriteLine("What would you like to add to your list?");
                        string addInput = Console.ReadLine();
                        inputList.Add(addInput);

                        Console.WriteLine("You have added the following to your list: " + addInput);
                        Console.WriteLine("Please press 'Enter' to return to main menu");
                        Console.ReadLine();


                    }
                    else if (menuOptions[selectedIndex] == "Delete") //if user selects delete
                    {
                        do
                        {

                            Console.Clear();
                            Console.WriteLine("What number from the list did you want to delete?");


                            for (int i = 0; i < inputList.Count; i++)
                            {
                                Console.WriteLine((i + 1) + ". " + inputList[i]);
                            }

                            Console.WriteLine();
                            Console.WriteLine("To exit please type 'Exit'");

                            int deleteNum;
                            decimal decimalValue;
                            bool isNumber;
                            bool isDecimal;

                            string input = Console.ReadLine();
                            isNumber = int.TryParse(input, out deleteNum);
                            isDecimal = decimal.TryParse(input, out decimalValue);

                            if (input == "Exit")
                            {
                                break;
                            }
                            if (!isNumber)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error: Please enter a number");
                                Console.ResetColor();
                                Console.WriteLine("Please press 'Enter' to try again");
                                Console.ReadLine();
                            }
                            else if (!isDecimal)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error: Please enter a whole number");
                                Console.ResetColor();
                                Console.WriteLine("Please press 'Enter' to try again");
                                Console.ReadLine();
                            }
                            else if (deleteNum > 0 && deleteNum < (inputList.Count + 1))
                            {


                                inputList.RemoveAt(deleteNum - 1);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("You have successfully deleted list number: " + deleteNum);
                                Console.ResetColor();
                                Console.WriteLine("Please press 'Enter' to return to menu");
                                Console.ReadLine();
                                break;

                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error: The list number " + "'" + deleteNum + "'" + " doesn't exist");
                                Console.ResetColor();
                                Console.WriteLine("Please press 'Enter' to try again");
                                Console.ReadLine();
                            }
                        } while (true);
                    }
                }
            } while (true);
        }
    }
}


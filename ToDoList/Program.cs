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
                    Console.WriteLine("You have chosen to select " + menuOptions[selectedIndex]);

                    if (menuOptions[selectedIndex] == "Exit")
                    {
                        break;
                    }
                    else if (menuOptions[selectedIndex] == "Show list")
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
                    else if (menuOptions[selectedIndex] == "Add")
                    {
                        Console.Clear();
                        Console.WriteLine("What would you like to add to your list?");
                        string addInput = Console.ReadLine();
                        inputList.Add(addInput);

                        Console.WriteLine("You have added the following to your list: " + addInput);
                        Console.WriteLine("Please press 'Enter' to return to main menu");
                        Console.ReadLine();


                    }
                    else if (menuOptions[selectedIndex] == "Delete")
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
                            // int deleteNum = int.Parse(Console.ReadLine());
                            // bool isValidNumber;
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

                            // isValidNumber = int.Parse(deleteNum);
                            // if (!isValidNumber)
                            // {
                            //     Console.WriteLine("Error: please enter a number");
                            // }
                            // else
                            // {
                            //     break;
                            // }

                            //If the number inputted is not a number
                            //Give an error message 
                            //Loop the question until a number is placed



                            // else if (!isValidNumber) // If the input is non numerical
                            // {
                            //     Console.WriteLine("Error: Please enter a number");
                            // }
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


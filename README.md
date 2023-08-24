This is separate file:
using System;

namespace Employees
{
    class EmployeesClass
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int hourlyRate { get; set; }
        public int hoursWorked { get; set; }
    }
}

This is separate file:

using System;
using System.Collections.Generic;
using Employees;

namespace BethanysPieShop
{
    class Program
    {
        static List<EmployeesClass> employeeList = new List<EmployeesClass>();

        public static void Main(string[] args)
        {

            Console.WriteLine("Bethany's Pie Shop Employee App");

            bool continueLoop;
            do
            {
                welcome();

                Console.Write("");

                listMenu();

                continueLoop = askForPrompt();

            } while (continueLoop);

        }

        public static void welcome()
        {

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

            Console.WriteLine("");
        }

        public static bool askForPrompt()
        {
            Console.Write("Insert action: ");
            int userPrompt = int.Parse(Console.ReadLine());

            if (userPrompt == 9)
            {
                return false;
            }
            else if (userPrompt == 1)
            {
                Console.WriteLine();
                Console.WriteLine("Creating an employee");
                Console.Write("Enter the first name: ");
                string employeeFirstName = Console.ReadLine();
                Console.Write("Enter the last name: ");
                string employeeLastName = Console.ReadLine();
                Console.Write("Enter the hourly rate: ");
                String employeeHourlyRate = Console.ReadLine();

                Console.WriteLine("Employee created!");
                Console.WriteLine("");

                //store the employee details into an instance
                EmployeesClass employeeInstance = new EmployeesClass();
                {
                    employeeInstance.firstName = employeeFirstName;
                    employeeInstance.lastName = employeeLastName;
                    employeeInstance.hourlyRate = int.Parse(employeeHourlyRate);
                }

                employeeList.Add(employeeInstance);
                Console.WriteLine($"{employeeInstance.firstName} {employeeInstance.lastName} has been added!");

                Console.WriteLine();


            }
            else if (userPrompt == 2)
            {
                Console.WriteLine("Select an employee:");

                //show list of employees registered
                for (int i = 0; i < employeeList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {employeeList[i].firstName} {employeeList[i].lastName}");
                }
                Console.WriteLine();

                Console.Write("Select employee's number: ");
                int selectedEmployee = int.Parse(Console.ReadLine());
                //if user chooses existing employee
                if (selectedEmployee >= 1 && selectedEmployee <= employeeList.Count)
                {
                    //Create an instance of that existing employee and notify the user who they have selected
                    EmployeesClass employee = employeeList[selectedEmployee - 1];
                    Console.WriteLine($"You have selected {employeeList[selectedEmployee - 1].firstName} {employeeList[selectedEmployee - 1].lastName}");
                    //Ask the user to enter the number of hours worked 
                    Console.Write("Enter the number of hours worked: ");
                    int hoursWorked = int.Parse(Console.ReadLine()); //store value in a variable

                    employeeList[selectedEmployee - 1].hoursWorked = hoursWorked;//store hours worked in the employees class property
                    //reiterate to the user what they have done
                    Console.WriteLine($"{employeeList[selectedEmployee - 1].firstName} {employeeList[selectedEmployee - 1].lastName} has now worked {employeeList[selectedEmployee - 1].hoursWorked} hours in total");

                    Console.WriteLine();
                }
                else if (userPrompt == 3)
                {
                    Console.WriteLine("Select an employee:");

                    //show list of employees registered
                    for (int i = 0; i < employeeList.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {employeeList[i].firstName} {employeeList[i].lastName}");
                    }
                    Console.WriteLine();

                    Console.Write("Select employee's number: ");
                    int selectedEmployee = int.Parse(Console.ReadLine());
                    //if user chooses existing employee
                    if (selectedEmployee >= 1 && selectedEmployee <= employeeList.Count)
                    {
                        //Create an instance of that existing employee and notify the user who they have selected
                        EmployeesClass employee = employeeList[selectedEmployee - 1];

                        //Calculate the wage earned AND reset hours worked to 0
                        int wageEarned = employeeList[selectedEmployee - 1].hoursWorked * employeeList[selectedEmployee].hourlyRate;
                        Console.WriteLine($"Wage earned is {wageEarned}");

                        Console.WriteLine();

                    }
                    else
                    {
                        Console.WriteLine("Invalid selection. Please try again.");
                    }




                    //if number is not valid, then ask the user to input a valid number again
                    //When a number is inputted, then print '{employeeFirstName} {employeeLastName} has now worked {hoursWorked} hours in total.'  
                    //else if employee DOES NOT exist, then Ask to select an employee that exists
                    //break

                }
                return true;
            }

        }
    }
}

I'm getting error where it says i'm missing curly brackets. how do i fix this?
Can you give me hints as to how I can optimally update my code?
What's the difference between the green button that opens a new terminal visual studio and type dotnet run in the terminal which essentially do the same thing?
Is my style of creating this program good for building my knowledge for real world swe?

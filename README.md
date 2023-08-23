using System;

namespace Employees
{
    class EmployeesClass
    {        
            public string firstName { get; set; }
            public string lastName { get; set; }
            public int hourlyRate { get; set; }
    }
}

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
            
            do
            {
                welcome();

                Console.WriteLine("");

                listMenu();

                askForPrompt();



            } while (true);

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

            for (int i = 0; i < listMenu.Count; i++) {
                Console.WriteLine(listMenu[i]); 
            }

            Console.WriteLine("");
        }

        public static void askForPrompt()
        {
            Console.Write("Insert action: ");
            int userPrompt = int.Parse(Console.ReadLine());

            if (userPrompt == 1)
            {
                Console.WriteLine("Creating an employee");
                Console.Write("Enter the first name: ");
                string employeeFirstName = Console.ReadLine();
                Console.Write("Enter the last name: ");
                string employeeLastName = Console.ReadLine();
                Console.Write("Enter the hourly rate: ");
                String employeeHourlyRate = Console.ReadLine();

                Console.WriteLine("Employee created!");
                Console.WriteLine("");
                Console.WriteLine("");

                //store the employee details into an instance
                EmployeesClass employeeInstance = new EmployeesClass();
                {
                    EmployeesClass.firstName = employeeFirstName;
                    EmployeesClass.lastName = employeeLastName;
                    EmployeesClass.hourlyRate = int.Parse(employeeHourlyRate);
                }

                employeeList.Add(employeeInstance);
                Console.WriteLine(employeeInstance);

            }
            else if (userPrompt == 2)
            {
                Console.WriteLine("Select an employee:");

                //show list of employees registered
                //let the database of employees to be in parallel with the list that is shown
                //if user chooses existing employee, then Ask 'Enter the number of hours worked', then store that to the employee's instance
                    //if number is not valid, then ask the user to input a valid number again
                    //When a number is inputted, then print '{employeeFirstName} {employeeLastName} has now worked {hoursWorked} hours in total.'  
                //else if employee DOES NOT exist, then Ask to select an employee that exists
                //break

            }
        }
        
    }
}
This is my new code and it looks like it has been fixed. However I'm getting an error:
C:\Visual Studio Projects\BethanysPieShop\Employees.cs(7,27): warning CS8618: Non-nullable property 'firstName' must contain a non-null value when exiting constructor. Consider declaring the property as null
able. [C:\Visual Studio Projects\BethanysPieShop\BethanysPieShop.csproj]
C:\Visual Studio Projects\BethanysPieShop\Employees.cs(8,27): warning CS8618: Non-nullable property 'lastName' must contain a non-null value when exiting constructor. Consider declaring the property as nulla
ble. [C:\Visual Studio Projects\BethanysPieShop\BethanysPieShop.csproj]
C:\Visual Studio Projects\BethanysPieShop\Program.cs(75,21): error CS0120: An object reference is required for the non-static field, method, or property 'EmployeesClass.firstName' [C:\Visual Studio Projects\
BethanysPieShop\BethanysPieShop.csproj]
C:\Visual Studio Projects\BethanysPieShop\Program.cs(76,21): error CS0120: An object reference is required for the non-static field, method, or property 'EmployeesClass.lastName' [C:\Visual Studio Projects\B
ethanysPieShop\BethanysPieShop.csproj]
C:\Visual Studio Projects\BethanysPieShop\Program.cs(77,21): error CS0120: An object reference is required for the non-static field, method, or property 'EmployeesClass.hourlyRate' [C:\Visual Studio Projects
\BethanysPieShop\BethanysPieShop.csproj]
C:\Visual Studio Projects\BethanysPieShop\Program.cs(56,40): warning CS8604: Possible null reference argument for parameter 's' in 'int int.Parse(string s)'. [C:\Visual Studio Projects\BethanysPieShop\Bethan
ysPieShop.csproj]
C:\Visual Studio Projects\BethanysPieShop\Program.cs(62,44): warning CS8600: Converting null literal or possible null value to non-nullable type. [C:\Visual Studio Projects\BethanysPieShop\BethanysPieShop.cs
proj]
C:\Visual Studio Projects\BethanysPieShop\Program.cs(64,43): warning CS8600: Converting null literal or possible null value to non-nullable type. [C:\Visual Studio Projects\BethanysPieShop\BethanysPieShop.cs
proj]
C:\Visual Studio Projects\BethanysPieShop\Program.cs(66,45): warning CS8600: Converting null literal or possible null value to non-nullable type. [C:\Visual Studio Projects\BethanysPieShop\BethanysPieShop.cs
proj]
C:\Visual Studio Projects\BethanysPieShop\Program.cs(75,48): warning CS8601: Possible null reference assignment. [C:\Visual Studio Projects\BethanysPieShop\BethanysPieShop.csproj]
C:\Visual Studio Projects\BethanysPieShop\Program.cs(76,47): warning CS8601: Possible null reference assignment. [C:\Visual Studio Projects\BethanysPieShop\BethanysPieShop.csproj]
C:\Visual Studio Projects\BethanysPieShop\Program.cs(77,59): warning CS8604: Possible null reference argument for parameter 's' in 'int int.Parse(string s)'. [C:\Visual Studio Projects\BethanysPieShop\Bethan
ysPieShop.csproj]

The build failed. Fix the build errors and run again.

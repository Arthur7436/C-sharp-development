# C-sharp-development
Repository for me to practice learning C# by creating mini projects 
I have created a separate cs file:
using System;

namespace Employees
{
    class Employees
    {
        public static string employees()
        {
            public string firstName { get; set; };
            public string lastName { get; set; };
            public int hourlyRate { get; set; };

            

        }
    }
}

In my other file is:
using System;
using Employees;

namespace BethanysPieShop
{
    class Program
    {
        List<string> employeeList = new List<string>();

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
                Employees.employees() employeeInstance = new Employees.employees();
                {
                    employeeInstance.firstName = employeeFirstName;
                    employeeInstance.lastName = employeeLastName;
                    employeeInstance.hourlyRate = employeeHourlyRate
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
The issue is that I can't somehow have the List employeeList and the new instance to be connected. It seems that they are not connected.

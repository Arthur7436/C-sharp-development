using ECommerce.Models;
using ECommerce.Repository;
using System.Data.SqlClient;

namespace ECommercePlatform
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> ListOfProducts = new List<Product>(); //create a list to store all products inside
            ProductRepository.ConnectToSqlDb(); //connect program to database

            do
            {
                //When sql db is updated then update the json file (in case via web api app, db is updated.. this initialises the list when Ecommerce app starts)
                string pwd = Environment.GetEnvironmentVariable("SQL_PASSWORD", EnvironmentVariableTarget.Machine)!; //used SETX command to store SQL_PASSWORD into local machine so that credentials are not hard-coded
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Storage of password in variable was successful...");
                Console.ResetColor();
                Thread.Sleep(500);

                //Attempt to connect console application to server database

                //variable declaration
                string connectionString = null!;
                SqlConnection cnn;
                connectionString = $"Data Source=AUL0953;Initial Catalog=ProductDB;User ID=sa;Password={pwd}";

                //assign connection
                cnn = new SqlConnection(connectionString);

                //See if the connection works
                try //if connection to db is successful
                {
                    cnn.Open();
                }
                catch (Exception ex) //if connection to db is unsuccessful
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Cannot open connection... ");
                    Console.ResetColor();
                    Thread.Sleep(3000);
                }






                ListOfProducts = ProductRepository.DeserializeJsonFileToList(); //allows product stored in file as memory upon start up

                ProductRepository.MakeIdentifyColumnNumberingUpToDate(); //Makes SQL db column for "Identify" in chronological numerical sequence 

                ProductRepository.DisplayMenu();//Display the menu to user

                string? input = Console.ReadLine(); //store the users input into variable to determine program flow

                //FIND A WAY TO MAKE SWITCH FOR THE IF-ELSE PROGRAM FLOW AT THE BOTTOM

                if (input == "q") //quit the program
                {
                    ProductRepository.TurnOffConnectionToDb(); //close the connection of db when they click q
                    return; //close the program
                }
                else if (input == "r") //reset program memory
                {
                    ProductRepository.ClearProductList(ListOfProducts); //reset the list and json file
                }
                else if (input == "1") //view all products available
                {
                    ProductRepository.ViewProduct(ListOfProducts); //views what is in list & JSON file

                    ProductRepository.ViewSqlDb(); //views what is in db

                    Console.ReadLine();
                }
                else if (input == "2") //add the product requested by user via the console application
                {
                    ProductRepository.AddProductToListAndSqlDb(ListOfProducts!); //Add product to JSON file and SQL db
                    ProductRepository.SerializeToJsonFile(ListOfProducts); //Serialize the updated list to the JSON file
                }
                else if (input == "3") //remove the product requested by user
                {
                    ProductRepository.RemoveProduct(ListOfProducts!);//removes the requested product
                    ProductRepository.SerializeToJsonFile(ListOfProducts);//Serialize the updated list to the JSON file
                }
                else if (input == "4") //update the product requested by user
                {
                    ProductRepository.UpdateProduct(ListOfProducts!);//Updates the products name or description in both JSON file and SQL db
                }
            } while (true);
        }


    }
}

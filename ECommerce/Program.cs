﻿using ECommerce.Models;
using ECommerce.Repository;
using Newtonsoft.Json;
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
                ListOfProducts = ProductRepository.DeserializeJsonFileToList(); //allows product stored in file as memory upon start up

                MakeIdentifyColumnNumberingUpToDate();

                DisplayMenu();

                string? input = Console.ReadLine(); //store the users input into variable to determine program flow

                if (input == "q") //quit the program
                {
                    ProductRepository.TurnOffConnectionToDb(); //close the connection of db when they click q
                    return; //close the program
                }
                else if (input == "r") //reset the list and json file
                {
                    ClearProductList(ListOfProducts);
                }
                else if (input == "1") //view all products available
                {
                    ViewProduct(ListOfProducts); //views what is in list & JSON file

                    ViewSqlDb(); //views what is in db

                    Console.ReadLine();
                }
                else if (input == "2") //add the product requested by user via the console application
                {
                    AddProductToJsonAndSqlDb(ListOfProducts!);
                    ProductRepository.SerializeToJsonFile(ListOfProducts);
                }
                else if (input == "3") //remove the product requested by user
                {
                    RemoveProduct(ListOfProducts!);
                    ProductRepository.SerializeToJsonFile(ListOfProducts);
                }
                else if (input == "4") //update the product requested by user
                {
                    UpdateProduct(ListOfProducts!);
                }
            } while (true);
        }

        private static void MakeIdentifyColumnNumberingUpToDate()
        {
            //set sql variables
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = "";

            string pwd = Environment.GetEnvironmentVariable("SQL_PASSWORD", EnvironmentVariableTarget.Machine)!;
            string connectionString = null!;
            SqlConnection cnn;
            connectionString = $"Data Source=AUL0953;Initial Catalog=ProductDB;User ID=sa;Password={pwd}";
            cnn = new SqlConnection(connectionString);

            cnn.Open();

            //Make Identify to be sequential numbering
            sql = "DECLARE @id INT SET @id = 0 UPDATE dbo.Product SET @id = Identify = @id + 1";

            command = new SqlCommand(sql, cnn);
            adapter.UpdateCommand = new SqlCommand(sql, cnn);
            adapter.UpdateCommand.ExecuteNonQuery();

            command.Dispose();
            cnn.Close();
        }

        private static void UpdateProduct(List<Product> ListOfProducts)
        {
            //set sql variables
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = "";

            string pwd = Environment.GetEnvironmentVariable("SQL_PASSWORD", EnvironmentVariableTarget.Machine)!;
            string connectionString = null!;
            SqlConnection cnn;
            connectionString = $"Data Source=AUL0953;Initial Catalog=ProductDB;User ID=sa;Password={pwd}";
            cnn = new SqlConnection(connectionString);

            //Ask the user
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Which product did you want to update: ");
            Console.ResetColor();

            foreach (Product products in ListOfProducts)
            {
                Console.WriteLine(products);
            }

            string? UserInput = Console.ReadLine();
            //loop through list and if the name of product equals userInput then ask which they want to update: NameOfProduct or Description
            List<string> productDetails = new List<string>();
            productDetails.Add("Name of Product");
            productDetails.Add("Description of product");



            if (ListOfProducts.Any(x => x.NameOfProduct == UserInput)) //if user selects a product via NameOfProduct
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Which property did you want to update for '{UserInput}':");
                Console.ResetColor();

                for (int j = 0; j < ListOfProducts.Count; j++)
                {
                    Console.WriteLine($"{j + 1}: {productDetails[j]}"); //display properties of Product that can be updated
                }

                int? numInput = int.Parse(Console.ReadLine());
                if (numInput == 1) //<-------HANDLE SYSTEM IF USER INPUTS NOT A NUMBER -------->
                {
                    Console.WriteLine("Enter new product name: ");
                    string? newProductName = Console.ReadLine();

                    //update the Object's property NameOfProduct
                    //go through whole list and find the object's index
                    for (int i = 0; i < ListOfProducts.Count; i++)
                    {
                        if (ListOfProducts[i].NameOfProduct == UserInput)
                        {
                            ListOfProducts[i].NameOfProduct = newProductName;
                            ProductRepository.SerializeToJsonFile(ListOfProducts); //serialize to json file so that it would not be overwritten at the start of Main Program
                            //update in sql db
                            cnn.Open();
                            sql = "Update dbo.Product set NameOfProduct='" + $"{UserInput}" + $"' where row={i + 1}"; //Update the column NameOfProduct at the row of that product

                            command = new SqlCommand(sql, cnn);

                            adapter.UpdateCommand = new SqlCommand(sql, cnn);
                            adapter.UpdateCommand.ExecuteNonQuery();

                            command.Dispose();
                            cnn.Close();



                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Product name updated!");
                            Console.ResetColor();
                            Thread.Sleep(500);
                        }
                    }
                }
                else if (numInput == 2)
                {
                    Console.WriteLine("Enter new product description: ");
                    string? newProductDescription = Console.ReadLine();

                    //update the Object's property NameOfProduct
                    //go through whole list and find the object's index
                    for (int i = 0; i < ListOfProducts.Count; i++)
                    {
                        if (ListOfProducts[i].NameOfProduct == UserInput)
                        {
                            ListOfProducts[i].Description = newProductDescription;
                            ProductRepository.SerializeToJsonFile(ListOfProducts); //serialize to json file so that it would not be overwritten

                            //update in sql db
                            cnn.Open();
                            sql = "Update dbo.Product set Description='" + $"{UserInput}" + $"' where row={i + 1}"; //Update the column NameOfProduct at the row of that product

                            command = new SqlCommand(sql, cnn);

                            adapter.UpdateCommand = new SqlCommand(sql, cnn);
                            adapter.UpdateCommand.ExecuteNonQuery();

                            command.Dispose();
                            cnn.Close();

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Product description updated!");
                            Console.ResetColor();
                            Thread.Sleep(500);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Product doesn't exist");

            }
        }

        private static void ViewSqlDb()
        {
            //create sql commands to be able to read from db
            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";

            string pwd = Environment.GetEnvironmentVariable("SQL_PASSWORD", EnvironmentVariableTarget.Machine)!;

            sql = "Select Identify,Id,NameOfProduct,Description from dbo.Product";

            string connectionString = null!;
            SqlConnection cnn;
            connectionString = $"Data Source=AUL0953;Initial Catalog=ProductDB;User ID=sa;Password={pwd}";

            //assign connection
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + " - " + dataReader.GetValue(2) + " - " + dataReader.GetValue(3) + "\n";
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("SQL database:");
            Console.ResetColor();
            Console.WriteLine(Output);
            dataReader.Close();
            command.Dispose();
            cnn.Close();
        }

        private static void ClearProductList(List<Product> ListOfProducts)
        {
            //remove everything in the list
            ListOfProducts.Clear();
            //push those changes and serialize as Json 
            string json = JsonConvert.SerializeObject(ListOfProducts);
            File.WriteAllText(@"C:\FileStorage\Test.json", json);
        }

        private static void ViewProduct(List<Product> ListOfProducts) //ListOfProducts <List> is already deserialized into a list from the file
        {
            if (ListOfProducts == null || ListOfProducts.Count == 0) //give error message if list is empty
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No products to view!");
                Console.ResetColor();

                Console.ReadLine();
            }
            else //list all the products
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Here is the list of all products:");
                Console.ResetColor();

                //display all objects within List
                foreach (Product products in ListOfProducts)
                {
                    Console.WriteLine(products.ToString());
                }

                Console.WriteLine();
            }
        }

        private static void RemoveProduct(List<Product> ListOfProducts)
        {
            //set sql variables
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = "";

            string pwd = Environment.GetEnvironmentVariable("SQL_PASSWORD", EnvironmentVariableTarget.Machine)!;
            string connectionString = null!;
            SqlConnection cnn;
            connectionString = $"Data Source=AUL0953;Initial Catalog=ProductDB;User ID=sa;Password={pwd}";
            cnn = new SqlConnection(connectionString);
            cnn.Open();

            //collect info from user
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Which product would you like to delete?");
            Console.ResetColor();

            foreach (Product products in ListOfProducts!) //print out all the products available
            {
                Console.WriteLine(products.ToString());
            }

            ViewSqlDb();

            Console.Write("Input: ");
            string userRemovalInput = Console.ReadLine()!;

            //remove based on name of product
            if (!ListOfProducts.Any(x => x.NameOfProduct == userRemovalInput)) //if users inputs a product that already exists => give error
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The product doesn't exist!");
                Console.ResetColor();

                Console.ReadLine();
                return;
            }

            if (ListOfProducts.Any(x => x.NameOfProduct == userRemovalInput)) //else remove the product from the list
            {
                //loop through the whole list 
                for (int i = 0; i < ListOfProducts.Count; i++)
                {
                    //if the name of product is equal to the userRemovalInput, find the index of that object
                    if (ListOfProducts[i].NameOfProduct == userRemovalInput)
                    {
                        //remove from list
                        ListOfProducts.RemoveAt(i);

                        //remove product also from sql db
                        sql = $"Delete dbo.Product where Identify={i + 1}";

                        command = new SqlCommand(sql, cnn);

                        adapter.DeleteCommand = new SqlCommand(sql, cnn);
                        adapter.DeleteCommand.ExecuteNonQuery();

                        command.Dispose();
                        cnn.Close();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Product successfully removed!");
                        Console.ResetColor();

                        Console.ReadLine();
                    }
                }
            }
        }

        private static void AddProductToJsonAndSqlDb(List<Product> ListOfProducts)
        {
            //set sql variables
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = "";

            string pwd = Environment.GetEnvironmentVariable("SQL_PASSWORD", EnvironmentVariableTarget.Machine)!;
            string connectionString = null!;
            SqlConnection cnn;
            connectionString = $"Data Source=AUL0953;Initial Catalog=ProductDB;User ID=sa;Password={pwd}";
            cnn = new SqlConnection(connectionString);

            //Create instance and add details to the instance which will be added to the list

            Product product = new Product();

            string GenerateRandomID = Guid.NewGuid().ToString("N");

            Console.WriteLine($"Product Id: {GenerateRandomID}");
            product.Id = GenerateRandomID;

            Console.WriteLine("Name of product: ");
            string? productNameInput = Console.ReadLine();

            //if the name of product already exists, then notify user
            for (int i = 0; i < ListOfProducts.Count; i++)
            {
                if (ListOfProducts[i].NameOfProduct == productNameInput)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("This product name already exists!");
                    Console.ResetColor();

                    Console.ReadLine();
                    return;
                }
            }

            product.NameOfProduct = productNameInput;

            Console.WriteLine("Description of product: ");
            string? DescriptionOfProductInput = Console.ReadLine();
            product.Description = DescriptionOfProductInput!;

            ListOfProducts!.Add(product);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Product added!");
            Console.ResetColor();

            //Loop through the list and find the row number + Id + NameOfProduct + Description in order to be sent to sql db
            for (int i = 0; i < ListOfProducts.Count; i++)
            {
                sql = $"Insert into dbo.Product (Identify,Id,NameOfProduct,Description) values({i + 1},'" + $"{product.Id}" + "', '" + $"{product.NameOfProduct}" + "' , '" + $"{product.Description}" + "')";
            }

            //push the product into sql db
            command = new SqlCommand(sql, cnn);
            adapter.InsertCommand = new SqlCommand(sql, cnn);

            cnn.Open();
            adapter.InsertCommand.ExecuteNonQuery();

            command.Dispose();
            cnn.Close();

            Console.ReadLine();
        }

        private static void DisplayMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to the E-commerce platform!");
            Console.ResetColor();
            Console.WriteLine("Please select one of the following: ");

            List<string> displayMenu = new List<string>()
                {
                    "1. View all products",
                    "2. Add a product",
                    "3. Remove a product",
                    "4. Update a product",
                    "Enter 'r' to reset the list to null",
                    "Enter 'q' to exit the program"
                };


            for (int i = 0; i < displayMenu.Count; i++)
            {
                Console.WriteLine(displayMenu[i]); //display menu
            }
        }
    }
}

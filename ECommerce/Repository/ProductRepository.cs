﻿using ECommerce.Models;
using Newtonsoft.Json;
using System.Data.SqlClient;


namespace ECommerce.Repository
{
    public class ProductRepository
    {
        public static List<Product> DeserializeJsonFileToList()
        {
            List<Product> ListOfProducts;
            //turn the Json file into ListOfProducts so that memory is stored
            string storedJsonMemory = File.ReadAllText(@"C:\FileStorage\Test.json");
            ListOfProducts = JsonConvert.DeserializeObject<List<Product>>(storedJsonMemory)!;
            return ListOfProducts;
        }

        public static void SerializeToJsonFile(List<Product> ListOfProducts)
        {
            string json = $"{JsonConvert.SerializeObject(ListOfProducts, Formatting.Indented)}";
            File.WriteAllText(@"C:\FileStorage\Test.json", json); //add ListOfProducts <List> into JSON file
        }

        public void AddMethod(string Id, string NameOfProduct, string Description)
        {

        }

        public static void ConnectToSqlDb()
        {
            string pwd = Environment.GetEnvironmentVariable("SQL_PASSWORD", EnvironmentVariableTarget.Machine)!; //used SETX command to store SQL_PASSWORD into local machine so that credentials are not hard-coded
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Storage of password in variable was successful!");
            Console.ResetColor();
            Thread.Sleep(3000);


            //Attempt to connect console application to server database
            string connetionString = null!;
            SqlConnection cnn;

            connetionString = $"Data Source=AUL0953;Initial Catalog=ProductDB;User ID=sa;Password={pwd}";
            cnn = new SqlConnection(connetionString);

            //See if the connection works
            try
            {
                cnn.Open();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Connection to SQL database was successful! ");
                Console.ResetColor();
                Thread.Sleep(3000);
                cnn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not open connection ! ");
                Thread.Sleep(3000);
            }
        }








    }
}

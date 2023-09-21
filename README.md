using ECommerce.Models;
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

        public static void ConnectToSqlDb()
        {
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
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Connection to SQL database was successful... ");
                Console.ResetColor();
                Thread.Sleep(500);
                //cnn.Close(); Move this to TurnOffConnectionToDb method when user enters q
            }
            catch (Exception ex) //if connection to db is unsuccessful
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cannot open connection... ");
                Console.ResetColor();
                Thread.Sleep(3000);
            }
        }
        public static void TurnOffConnectionToDb()
        {
            string pwd = Environment.GetEnvironmentVariable("SQL_PASSWORD", EnvironmentVariableTarget.Machine)!; //used SETX command to store SQL_PASSWORD into local machine so that credentials are not hard-coded

            string connectionString = null!;
            SqlConnection cnn;

            connectionString = $"Data Source=AUL0953;Initial Catalog=ProductDB;User ID=sa;Password={pwd}";
            cnn = new SqlConnection(connectionString);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Database connection closing...");
            Console.ResetColor();
            cnn.Close();
            Thread.Sleep(500);
        }

        public static void MakeIdentifyColumnNumberingUpToDate()
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

          public static void UpdateProduct(List<Product> ListOfProducts)
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

          for (int j = 0; j < (productDetails.Count); j++)
          {
              Console.WriteLine($"{j + 1}: {productDetails[j]}"); //display properties of Product that can be updated
              //if we have reached to the last option of the list then break

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
                      sql = "Update dbo.Product set NameOfProduct='" + $"{newProductName}" + $"' where Identify={i + 1}"; //Update the column NameOfProduct at the row of that product

                      command = new SqlCommand(sql, cnn);

                      adapter.UpdateCommand = new SqlCommand(sql, cnn);
                      Console.WriteLine(adapter.UpdateCommand.ExecuteNonQuery());
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
                      sql = "Update dbo.Product set Description='" + $"{newProductDescription}" + $"' where Identify={i + 1}"; //Update the column Description at the row of that product

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

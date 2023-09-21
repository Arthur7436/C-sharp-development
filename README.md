So looking at my code, am I implementing DAL or ORM? How can I tell the difference?

using ECommerce.Models;
using ECommerce.Repository;

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

                ProductRepository.MakeIdentifyColumnNumberingUpToDate(); //Makes SQL db column for "Identify" in chronological numerical sequence 

                ProductRepository.DisplayMenu();//Display the menu to user

                string? input = Console.ReadLine(); //store the users input into variable to determine program flow

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

Here is some parts of my other code that touches the sql db:
  public static void ViewProduct(List<Product> ListOfProducts) //ListOfProducts <List> is already deserialized into a list from the file
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

  public static void RemoveProduct(List<Product> ListOfProducts)
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

  public static void AddProductToListAndSqlDb(List<Product> ListOfProducts)
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

using ECommerce;
using Newtonsoft.Json;

namespace ECommercePlatform
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> ListOfProducts = new List<Product>(); //create a list to store all products inside

            do
            {
                ListOfProducts = DeserializeJsonFileToList(); //allows product stored in file as memory upon start up
                
                DisplayMenu();

                string? input = Console.ReadLine();

                if (input == "q") //quit the program
                {
                    return;
                }
                else if (input == "r") //reset the list and json file
                {
                    ClearProductList(ListOfProducts);
                }
                else if (input == "1") //view all products available
                {
                    ViewProduct(ListOfProducts);

                }
                else if (input == "2") //add the product requested by user
                {
                    AddProduct(ListOfProducts!);
                    SerializeToJsonFile(ListOfProducts);
                }
                else if (input == "3") //remove the product requested by user
                {
                    RemoveProduct(ListOfProducts!);
                    SerializeToJsonFile(ListOfProducts);
                }
            } while (true);
        }
        
        private static void ClearProductList(List<Product> ListOfProducts)
        {
            //remove everything in the list
            ListOfProducts.Clear();
            //push those changes and serialize as Json 
            string json = JsonConvert.SerializeObject(ListOfProducts);
            File.WriteAllText(@"C:\FileStorage\Test.json", json);
        }

        private static List<Product> DeserializeJsonFileToList()
        {
            List<Product> ListOfProducts;
            //turn the Json file into ListOfProducts so that memory is stored
            string storedJsonMemory = File.ReadAllText(@"C:\FileStorage\Test.json");
            ListOfProducts = JsonConvert.DeserializeObject<List<Product>>(storedJsonMemory)!;
            return ListOfProducts;
        }

        private static void SerializeToJsonFile(List<Product> ListOfProducts)
        {
            string json = $"{JsonConvert.SerializeObject(ListOfProducts, Formatting.Indented)}";
            File.WriteAllText(@"C:\FileStorage\Test.json", json); //add ListOfProducts <List> into JSON file
        }

        private static void ViewProduct(List<Product> ListOfProducts)
        {
            //view all products from the text file

            //view all products
            if (ListOfProducts == null || ListOfProducts.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No products to view!");
                Console.ResetColor();

                Console.ReadLine();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Here is the list of all products:");
                Console.ResetColor();

                //display all objects within List
                foreach (Product products in ListOfProducts)
                {
                    Console.WriteLine(products.ToString());
                }

                Console.ReadLine();
            }
        }

        private static void RemoveProduct(List<Product> ListOfProducts)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Which product would you like to delete?");
            Console.ResetColor();

            foreach (Product products in ListOfProducts!) //print out all the products available
            {
                Console.WriteLine(products.ToString());
            }

            string userRemovalInput = Console.ReadLine()!;

            //remove based on name of product
            if (ListOfProducts.Any(x => x.NameOfProduct == userRemovalInput)) //if users input equals the products name 
            {
                //go through the entire list and if the list object property matches the NameOfProduct, remove that entire object from list
                for (int i = 0; i < ListOfProducts.Count; i++)
                {
                    else if (ListOfProducts[i].NameOfProduct == userRemovalInput)
                    {
                        ListOfProducts.Remove(ListOfProducts[i]);
                    }
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Product has been successfully removed");
                Console.ResetColor();

                Console.ReadLine();
            } else if (!ListOfProducts.Any(x => x.NameOfProduct == userRemovalInput)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The product doesn't exist!");
                Console.ResetColor();

                Console.ReadLine();
                return;
            }
        }

        private static void AddProduct(List<Product> ListOfProducts)
        {
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

            Console.ReadLine();
        }

        private static void DisplayMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to the Ecommerce platform!");
            Console.ResetColor();
            Console.WriteLine("Please select one of the following: ");

            List<string> displayMenu = new List<string>()
                {
                    "1. View all products",
                    "2. Add a product",
                    "3. Remove a product",
                    "Enter 'r' to reset the list to null",
                    "Enter 'q' to exit the program"
                };

            //display menu
            for (int i = 0; i < displayMenu.Count; i++)
            {
                Console.WriteLine(displayMenu[i]);
            }
        }


    }
}

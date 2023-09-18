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
                Console.WriteLine("No products to view!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Here is the list of all products:");

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
            Console.WriteLine("Which product would you like to delete?");

            foreach (Product products in ListOfProducts!)
            {
                Console.WriteLine(products.ToString());
            }

            string userRemovalInput = Console.ReadLine()!;

            //remove based on name of product
            if (ListOfProducts.Any(x => x.NameOfProduct == userRemovalInput))
            {
                //go through the entire list and if the list object property matches the NameOfProduct, remove that entire object from list
                for (int i = 0; i < ListOfProducts.Count; i++)
                {
                    if (ListOfProducts[i].NameOfProduct == userRemovalInput)
                    {
                        ListOfProducts.Remove(ListOfProducts[i]);
                    }
                }
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
            //loop through all the nameofproducts
            for (int i = 0; i < ListOfProducts.Count; i++)
            {
                if (ListOfProducts[i].NameOfProduct == productNameInput)
                {
                    Console.WriteLine("This product name already exists!");
                    break;
                }
                else
                {
                    Console.WriteLine("Description of product: ");
                    string? DescriptionOfProductInput = Console.ReadLine();
                    product.Description = DescriptionOfProductInput!;

                    ListOfProducts!.Add(product);

                    Console.ReadLine();
                }
            }

            //Console.WriteLine("Description of product: ");
            //string? DescriptionOfProductInput = Console.ReadLine();
            //product.Description = DescriptionOfProductInput!;

            //ListOfProducts!.Add(product);

            //Console.ReadLine();

        }

        private static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Ecommerce platform!");
            Console.WriteLine("Please select one of the following: ");

            List<string> displayMenu = new List<string>()
                {
                    "1. View all products",
                    "2. Add a product",
                    "3. Remove a product",
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

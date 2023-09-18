using ECommerce.Product;
using Newtonsoft.Json;

namespace ECommercePlatform
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> ListOfProducts = new List<Product>();
            //string jsonList = JsonConvert.SerializeObject(ListOfProducts, Formatting.Indented); //convert the list into JSON format

            do
            {
                DisplayMenu();

                string? input = Console.ReadLine();

                if (input == "q")
                {
                    //quit program
                    return;
                }
                else if (input == "1")
                {
                    ViewProduct(ListOfProducts);
                }
                else if (input == "2")
                {
                    AddProduct(ListOfProducts!);

                    //Add a bracket at the beginning of the file
                    File.WriteAllText(@"C:\FileStorage\Test.json", "[");

                    //if there is at least one object to the list then append
                    if (ListOfProducts?.Count == 1) // "== 1" because there is a product already added to the list 
                    {
                        for (int j = 0; j < ListOfProducts.Count; j++)
                        {
                            string json = $"{JsonConvert.SerializeObject(ListOfProducts[j], Formatting.Indented)}";
                            File.AppendAllText(@"C:\FileStorage\Test.json", json);
                        }
                    }
                    //else if there is atleast one object, add to the json file 
                    else if (ListOfProducts?.Count > 1)
                    {
                        //Why the below approach? The initial method appends all text with the comma as a result leaves the first object with a comma in front which leads to syntax error. By doing below approach, deserializing the entire list, adding the new product to the list, then serializing the entire list will effectively avoid that issue of having the comma at the first object

                        //Deserialize the entire file into a list
                        string jsonString = File.ReadAllText(@"C:\FileStorage\Test.json");
                        //List<Product> listWithJson = new List<Product>();

                        var list = JsonConvert.DeserializeObject<List<Product>>(jsonString)!;
                        //Product list = JsonSerializer.Deserialize<Product>(jsonString);
                        //var list = (Product)JsonConvert.DeserializeObject(jsonString);

                        //Add the new product to list
                        AddProduct(ListOfProducts);

                        //Serialize the list with newly added product into file again
                        for (int j = 0; j < ListOfProducts.Count; j++)
                        {
                            string json = $"{JsonConvert.SerializeObject(ListOfProducts[j], Formatting.Indented)}";
                            File.WriteAllText(@"C:\FileStorage\Test.json", json);
                        }

                    }

                    //add closing bracket of file
                    File.AppendAllText(@"C:\FileStorage\Test.json", "]");

                    //Console.WriteLine(JsonConvert.SerializeObject(ListOfProducts[0])); //it works

                }
                else if (input == "3")
                {
                    RemoveProduct(ListOfProducts!);
                }
            } while (true);
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
            string? ProductNameInput = Console.ReadLine();
            product.NameOfProduct = ProductNameInput!;

            Console.WriteLine("Description of product: ");
            string? DescriptionOfProductInput = Console.ReadLine();
            product.Description = DescriptionOfProductInput!;

            ListOfProducts!.Add(product);

            Console.ReadLine();

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

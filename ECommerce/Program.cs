using ECommerce.Product;

namespace ECommercePlatform
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> ListOfProducts = new List<Product>();

            do
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

                string? input = Console.ReadLine();

                if (input == "q")
                {
                    //quit program
                    return;
                }
                else if (input == "1")
                {
                    //view all products
                    if (ListOfProducts == null || ListOfProducts.Count == 0)
                    {
                        Console.WriteLine("No products to view!");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Here is the list of all products:");
                        Console.WriteLine(ListOfProducts);
                    }
                }
                if (input == "2")
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

                    ListOfProducts.Add(product);
                    Console.WriteLine(product.ToString());



                    Console.ReadLine();
                }
                if (input == "3")
                {
                    //remove a product
                }
            } while (true);
        }
    }
}

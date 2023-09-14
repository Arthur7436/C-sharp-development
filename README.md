Can you guide me as to why 'product' instance is not being added to the list and being seen? Help me to understand under the hood.

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

                    Console.WriteLine(product);

                    Console.WriteLine(ListOfProducts[0].ToString());

                    Console.WriteLine(ListOfProducts[0]);

                    Console.WriteLine(ListOfProducts.ToArray());





                    //add id for product
                    //Console.Write("Product Id: ");
                    //Console.WriteLine(product.GetId());



                    //add name of product
                    //Console.Write("Product name: ");
                    //string? ProductName = Console.ReadLine();

                    //product.GetNameOfProduct();

                    //Description of product
                    //Console.Write("Description of product: ");
                    //string? DescriptionOfProduct = Console.ReadLine();
                    //product.GetDescriptionOfProduct();

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

namespace ECommerce.Product
{
    //public class Product : IProduct
    //{
    //    public string GetId() //returns a random id for the product
    //    {
    //        return Guid.NewGuid().ToString("N");

    //    }

    //    public string GetNameOfProduct()
    //    {

    //        return "Test";
    //    }

    //    public string GetDescriptionOfProduct()
    //    {
    //        return "Test";
    //    }
    //}

    public class Product
    {
        public string Id { get; set; }
        public string NameOfProduct { get; set; }
        public string Description { get; set; }
    }



}


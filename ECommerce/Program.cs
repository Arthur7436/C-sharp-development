﻿using ECommerce.Product;
using Newtonsoft.Json;

namespace ECommercePlatform
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> ListOfProducts = new List<Product>();
            string jsonList = JsonConvert.SerializeObject(ListOfProducts, Formatting.Indented); //convert the list into JSON format

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
                if (input == "2")
                {
                    AddProduct(ListOfProducts!);


                    //when a product has been added, store object in the Test.txt file.
                    string file = @"C:\FileStorage\Test.json";
                    string text = "Testing";
                    File.WriteAllText(file, jsonList);

                    Console.WriteLine(ListOfProducts.Count);

                }
                if (input == "3")
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

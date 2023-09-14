﻿using ECommerce.Product;

namespace ECommercePlatform
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> ListOfProducts = new List<string>();
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
                    //add id
                    Console.Write("Product Id: ");
                    Console.WriteLine(product.GetId());
                    Console.ReadLine();
                    //add name of product
                    //Description of product
                }
                if (input == "3")
                {
                    //remove a product
                }
            } while (true);
        }
    }
}

using System;
using ECommercePlatform.Roles;
using People;

namespace UserChoice
{
    public static class Choices
    {
        public static void AdminChoice()
        {
            Admin admin = UserCreation.CreateAdmin();
            Console.WriteLine(admin.ToString());
            Console.ReadLine();
        }

        public static void BuyerChoice()
        {
            Admin buyer = UserCreation.CreateAdmin();
            Console.WriteLine(buyer.ToString());
            Console.ReadLine();
        }

        public static void SellerChoice()
        {
            Admin seller = UserCreation.CreateAdmin();
            Console.WriteLine(seller.ToString());
            Console.ReadLine();
        }

    }
}
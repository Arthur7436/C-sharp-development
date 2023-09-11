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
            Buyer buyer = UserCreation.CreateBuyer();
            Console.WriteLine(buyer.ToString());
            Console.ReadLine();
        }

        public static void SellerChoice()
        {
            Seller seller = UserCreation.CreateSeller();
            Console.WriteLine(seller.ToString());
            Console.ReadLine();
        }

    }
}
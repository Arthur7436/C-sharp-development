using System;
using System.Runtime.InteropServices;
using ECommercePlatform.Roles;

namespace People
{
    public static class UserCreation
    {
        public static Admin CreateAdmin()
        {
            Admin admin = new Admin();
            {
                admin.id = 123;
                admin.FirstName = "Arthur";
                admin.LastName = "Thai";
                admin.Email = "example@email.com";
                admin.Country = "country";
            };
            return admin;
        }

        public static Buyer CreateBuyer()
        {
            Buyer buyer = new Buyer();
            {
                buyer.id = 123;
                buyer.FirstName = "Buyer";
                buyer.LastName = "Thai";
                buyer.Email = "example@email.com";
                buyer.Country = "country";
            };
            return buyer;
        }

        public static Seller CreateSeller()
        {
            Seller seller = new Seller();
            {
                seller.id = 123;
                seller.FirstName = "Seller";
                seller.LastName = "Thai";
                seller.Email = "example@email.com";
                seller.Country = "country";
            };
            return seller;
        }
    }
}

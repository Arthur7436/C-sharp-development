using System;
using System.Runtime.InteropServices;
using ECommercePlatform.Roles;

namespace People
{
    public class UserCreation
    {
        public static void CreateAdmin()
        {
            Admin admin = new Admin();
            {
                admin.id = 123;
                admin.FirstName = "Arthur";
                admin.LastName = "Thai";
                admin.Email = "example@email.com";
                admin.Country = "country";
            };
        }

        public static void CreateSeller()
        {
            Admin admin = new Admin();
            {
                admin.id = 123;
                admin.FirstName = "Seller";
                admin.LastName = "Thai";
                admin.Email = "example@email.com";
                admin.Country = "country";
            };
        }

        public static void CreateBuyer()
        {
            Admin admin = new Admin();
            {
                admin.id = 123;
                admin.FirstName = "Buyer";
                admin.LastName = "Thai";
                admin.Email = "example@email.com";
                admin.Country = "country";
            };
        }
    }
}

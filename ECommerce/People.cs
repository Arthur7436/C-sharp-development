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
                admin.firstName = "Arthur";
                admin.lastName = "Thai";
                admin.email = "example@email.com";
                admin.country = "country";
            };
        }

        public static void CreateSeller()
        {
            Admin admin = new Admin();
            {
                admin.id = 123;
                admin.firstName = "Seller";
                admin.lastName = "Thai";
                admin.email = "example@email.com";
                admin.country = "country";
            };
        }

        public static void CreateBuyer()
        {
            Admin admin = new Admin();
            {
                admin.id = 123;
                admin.firstName = "Buyer";
                admin.lastName = "Thai";
                admin.email = "example@email.com";
                admin.country = "country";
            };
        }
    }
}

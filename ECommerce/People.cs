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
    }
}

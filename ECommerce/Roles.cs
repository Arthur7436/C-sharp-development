using System;
using System.Dynamic;

namespace ECommercePlatform.Roles
{
    enum UserRole
    {
        Admin,
        Buyer,
        Seller
    }

    class Admin
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string country { get; set; }

    }
    class Seller
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string country { get; set; }

    }

    class Buyer
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string country { get; set; }

    }
}

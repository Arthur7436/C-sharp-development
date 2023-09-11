﻿using System;
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;

namespace ECommercePlatform.Roles
{
    public class Admin
    {
        public int id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Country { get; set; }

        public override string ToString()
        {
            return
            $"Id: {id}\n" +
            $"First name: {FirstName}\n" +
            $"Last name: {LastName}\n" +
            $"Email: {Email}\n" +
            $"country: {Country}\n";
        }
    }


    public class Seller
    {
        public int id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Country { get; set; }

        public override string ToString()
        {
            return
            $"Id: {id}\n" +
            $"First name: {FirstName}\n" +
            $"Last name: {LastName}\n" +
            $"Email: {Email}\n" +
            $"country: {Country}\n";
        }

    }

    public class Buyer
    {
        public int id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Country { get; set; }

        public override string ToString()
        {
            return
            $"Id: {id}\n" +
            $"First name: {FirstName}\n" +
            $"Last name: {LastName}\n" +
            $"Email: {Email}\n" +
            $"country: {Country}\n";
        }
    }

    public class Display
    {
        public static void DisplayList()
        {
            List<string> userRoleDisplay = new List<string>()
                {
                    "1. Admin",
                    "2. Buyer",
                    "3. Seller",
                    "Input 'q' to quit the program"
                };

            for (int i = 0; i < userRoleDisplay.Count; i++)
            {
                Console.WriteLine(userRoleDisplay[i]);
            }
        }

    }
}

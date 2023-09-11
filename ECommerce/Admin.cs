using System;
using People;

namespace AdminChoice
{
    public static class AdminChoice
    {
        Admin admin = UserCreation.CreateAdmin();
        Console.WriteLine(admin.ToString());
                Console.ReadLine();

    }
}
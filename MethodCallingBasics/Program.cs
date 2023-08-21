using System;
using ClassLibrary;

namespace MethodCallingBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = OtherClass.GetName();
            Console.WriteLine($"Hello {name}");
        }
    }
}

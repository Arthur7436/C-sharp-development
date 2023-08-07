using System;

namespace ToDoList
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] options = { "Option 1", "Options 2", "Options 3" , "Exit"};
            do
            {
                for (int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine(options[i]);
                }

            } while (true);


        }
    }

}

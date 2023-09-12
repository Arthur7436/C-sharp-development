using Animals;

namespace Program
{
    class Program
    {
        public static void Main(string[] args)
        {
            Dog dog = new Dog("ArthurDog");
            Console.WriteLine(dog.Speak());
            Console.WriteLine(dog.Eat());

            Cat cat = new Cat("ArthurCat");
            Console.WriteLine(cat.Speak());
            Console.WriteLine(cat.Eat());
        }
    }
}
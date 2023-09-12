using AnimalAbstractConcrete.AnimalClass;


namespace AnimalAbstractConcrete
{
    class Program
    {
        static void Main(string[] args)
        {
            Lion leo = new Lion();
            Console.WriteLine(leo.Name());
            Console.WriteLine(leo.Speak());
            Console.WriteLine(leo.Eat());
        }
    }
}
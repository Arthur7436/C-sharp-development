using IShapes;

namespace Program
{
    class Program
    {
        public static void Main(string[] args)
        {
            Circles newCircle = new Circles(10.00, 10.00);
            Console.WriteLine(CalculateCircleArea(newCircle));

        }
    }
}
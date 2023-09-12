using IShapes;

namespace Program
{
    class Program
    {
        public static void Main(string[] args)
        {
            Circles newCircle = new Circles(10);
            Console.WriteLine(newCircle.CalculateCircleArea());

            Triangle newTriangle = new Triangle(10, 10);
            Console.WriteLine(newTriangle.AreaOfTriangle());

        }
    }
}
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

namespace IShapes
{
    public interface CircleInterface
    {
        double Circumference();
        double Radius();

    }
    public class Circles : CircleInterface
    {
        public double circumference;
        public double radius;

        public Circles(double x, double y)
        {
            double circumference = x;
            double radius = y;

        }

        public double Circumference()
        {
            return circumference;
        }

        public double Radius()
        {
            return radius;
        }

        public double CalculateCircleArea()
        {
            return circumference * radius;
        }

    }
}

//    public interface SquareInterface
//    {
//        int side();

//    }

//    public class Squares
//    {

//    }
//}

What is wrong with my code? I can't seem to use the calculatecirclearea method on the Program. Am I on the right track?

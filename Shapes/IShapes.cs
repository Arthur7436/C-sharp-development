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
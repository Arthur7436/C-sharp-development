namespace IShapes
{
    public interface ICircleInterface
    {
        double CalculateCircleArea();

    }

    public class Circles : ICircleInterface
    {
        public double radius;

        public Circles(double x)
        {
            radius = x;
        }

        public double CalculateCircleArea()
        {
            return 3.16 * (radius * radius);
        }

    }


    public interface ITriangleInterface
    {
        double AreaOfTriangle();
    }

    public class Triangle : ITriangleInterface
    {
        public double height;
        public double baseOfTriangle;

        public Triangle(double x, double y)
        {
            height = x;
            baseOfTriangle = y;
        }

        public double AreaOfTriangle()
        {
            return (height * baseOfTriangle) * 0.5;
        }
    }



}

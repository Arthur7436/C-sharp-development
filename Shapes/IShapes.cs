namespace IShapes
{
    public interface ICircleInterface
    {
        double Radius();
        double CalculateCircleArea();

    }

    public class Circles : ICircleInterface
    {
        public double radius;

        public Circles(double x)
        {
            radius = x;
        }

        public double Radius()
        {
            return radius;
        }

        public double CalculateCircleArea()
        {
            return 3.16 * (radius * radius);
        }

    }


    public interface ITriangleInterface
    {
        double Height();
        double Base();
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

        public double Height()
        {
            return height;
        }

        public double Base()
        {
            return baseOfTriangle;
        }
    }



}

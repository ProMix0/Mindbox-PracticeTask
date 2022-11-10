namespace ShapesLib;

public class Triangle : IShape
{
    public double SideA { get; }
    public double SideB { get; }
    public double SideC { get; }

    public Triangle(double a, double b, double c)
    {
        if (a <= 0 || b <= 0 || c <= 0) IsValid = false;

        var maxSide = a > b ? a : b;
        if (c > maxSide) maxSide = c;

        // Triangle exists
        if (a + b + c < 2 * maxSide)
            IsValid = false;

        if (Math.Abs(2 * maxSide * maxSide - (a * a + b * b + c * c)) < 1E-6)
            IsRectangular = true;

        double halfPerimeter = (a + b + c) / 2;
        Area = Math.Sqrt(halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c));

        SideA = a;
        SideB = b;
        SideC = c;
    }

    public bool IsRectangular { get; }

    public double Area { get; }

    public bool IsValid { get; } = true;
}
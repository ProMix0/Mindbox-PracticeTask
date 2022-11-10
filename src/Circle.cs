namespace ShapesLib;

public class Circle:IShape
{
    public double Radius { get; }

    public Circle(double radius)
    {
        if (radius > 0) IsValid = true;

        Area = Math.PI * radius * radius;

        Radius = radius;
    }
    
    public double Area { get; }
    public bool IsValid { get; } = false;
}
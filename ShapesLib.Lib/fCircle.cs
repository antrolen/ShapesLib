namespace ShapesLib.Lib;
public class Circle:  IShape{
    /// <summary>
    /// Circle radius
    /// </summary>
    public double Radius { get; set; }

    /// <summary>
    /// Circle area
    /// </summary>
    public double Area => double.Pi * Radius * Radius;


    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="radius">Circle radius</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown for radius values: negative, NaN, Infinity. Thrown for too big shapes</exception>
    public Circle(double radius){
        if( false 
        || double.IsInfinity(radius)
        || double.IsNaN(radius)
        || double.IsNegative(radius)
        || radius == double.NegativeZero
        )
        {
            throw new ArgumentOutOfRangeException($"{nameof(radius)} = {radius}");
        }

        if(!IsAreaCalculatable(radius)){
            throw new ArgumentOutOfRangeException($"{nameof(radius)} = {radius} is too big to calculate circle's area");
        }

        Radius = radius;

    }


    private static bool IsAreaCalculatable(double radius){
        double maxRaduis = Math.Sqrt(double.MaxValue / double.Pi);
        return radius < maxRaduis;
    }


}

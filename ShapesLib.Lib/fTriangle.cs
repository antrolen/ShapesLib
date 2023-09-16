namespace ShapesLib.Lib;
public class Triangle : IShape
{
    /// <summary>
    /// Triangle First Side
    /// </summary> 
    public double A { get; }

    /// <summary>
    /// Triangle Second Side
    /// </summary>
    public double B { get; }

    /// <summary>
    /// Triangle Third Side
    /// </summary>
    public double C { get; }

    /// <summary>
    /// Is Triangle a kind of rectangular
    /// </summary>
    public bool IsRight =>
        Math.Abs(A * A + B * B - C * C) < 0.000000000001d
        || Math.Abs(C * C + B * B - A * A) < 0.000000000001d
        || Math.Abs(A * A + C * C - B * B) < 0.000000000001d;

    /// <summary>
    /// Triangle area
    /// </summary>
    public double Area
    {
        get
        {
            return CalcAreaByThreeSides(A, B, C) ;
        }
    }


    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="a">Firast Side</param>
    /// <param name="b">Second Side</param>
    /// <param name="c">Third Side</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown for sides values: negative, NaN, Infinity. Thrown for too big shapes and nonexisting triangle</exception>
    public Triangle(double a, double b, double c)
    {
        if (IsIncorrectSide(a))
        {
            throw new ArgumentOutOfRangeException(nameof(a));
        }
        if (IsIncorrectSide(b))
        {
            throw new ArgumentOutOfRangeException(nameof(b));
        }
        if (IsIncorrectSide(c))
        {
            throw new ArgumentOutOfRangeException(nameof(c));
        }
        if (!IsExist(a, b, c))
        {
            throw new ArgumentOutOfRangeException($"{nameof(a)} = {a}; {nameof(b)} = {b}; {nameof(a)} = {c}");
        }
        if(!IsAreaCalculable(a, b, c))
        {
            throw new ArgumentOutOfRangeException($"{nameof(a)} = {a}; {nameof(b)} = {b}; {nameof(a)} = {c} are too big to calculate triangle's area");
        }

        A = a;
        B = b;
        C = c;
    }


    private static bool IsIncorrectSide(double side)
    {
        return (double.IsInfinity(side)
            || double.IsNaN(side)
            || double.IsNegative(side)
            || side == double.NegativeZero
        );
    }

    private static bool IsExist(double a, double b, double c)
    {
        return a + b > c && a + c > b && b + c > a;
    }

    private static bool IsAreaCalculable(double a, double b, double c){
        var result = CalcAreaByThreeSides(a, b, c) ;
        return double.IsFinite(result);
    }

    private static double CalcAreaByThreeSides(double a, double b, double c){
        double s = (a + b + c) / 2; 
        return Math.Pow(s, 0.5) * Math.Pow((s - b) , 0.5) * Math.Pow((s - c), 0.5) * Math.Pow((s - a), 0.5);
        // return Math.Pow(s * (s - b) * (s - c) *(s - a), 0.5);
    }
}


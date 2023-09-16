using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShapesLib.Lib;
public class Square : IShape
{
    /// <summary>
    /// Square side
    /// </summary>
    public double A { get; }

    /// <summary>
    /// Square area
    /// </summary>
    public double Area => A * A;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="a">Square side</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown for side values: negative, NaN, Infinity. Thrown for too big shapes</exception>
    public Square(double a)
    {
        if (false
        || double.IsInfinity(a)
        || double.IsNaN(a)
        || double.IsNegative(a)
        || a == double.NegativeZero
        )
        {
            throw new ArgumentOutOfRangeException($"{nameof(a)} = {a}");
        }

        if (!IsAreaCalculatable(a))
        {
            throw new ArgumentOutOfRangeException($"{nameof(a)} = {a} is too big to calculate square's area");
        }

        A = a;
    }


    private static bool IsAreaCalculatable(double a)
    {
        return a < Math.Sqrt(double.MaxValue);
    }
}
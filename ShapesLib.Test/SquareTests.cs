using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ShapesLib.Lib;

namespace ShapesLib.Test;
public class SquareTests
{
    // **************************************************
    // About Square

    [Fact]
    public void Square_with_correct_side_is_created()
    {
        var shape = new Square(a: 10d);
        shape.A.Should().Be(10d);
    }

    [Theory]
    [InlineData(-10d)]
    [InlineData(double.NaN)]
    [InlineData(double.NegativeZero)]
    [InlineData(double.NegativeInfinity)]
    [InlineData(double.PositiveInfinity)]
    public void Creation_of_square_with_incorrect_side_is_rejected(double a)
    {

        FluentActions.Invoking(() => new Square(a: a))
        .Should()
        .Throw<ArgumentOutOfRangeException>();

    }

    [Fact]
    public void Square_area_is_calculated()
    {
        var shape = new Square(a: 10d);
        shape.Area
        .Should()
        .BeApproximately(100d, 0.000000000001d);
    }

    [Fact]
    public void Creation_of_square_with_too_big_side_to_calculate_its_area_is_rejected()
    {
        FluentActions.Invoking(() => new Square(a: Math.Sqrt(double.MaxValue) + 0.0000000000001d))
        .Should()
        .Throw<ArgumentOutOfRangeException>();
    }

}
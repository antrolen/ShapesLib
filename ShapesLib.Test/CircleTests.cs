using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ShapesLib.Lib;

namespace ShapesLib.Test;
public class CircleTests
{
    // **************************************************
    // About Circle
    [Fact]
    public void Circle_with_correct_radius_is_created()
    {
        var shape = new Circle(radius: 10d);
        shape.Radius.Should().Be(10d);

    }



    [Theory]
    [InlineData(-10d)]
    [InlineData(double.NaN)]
    [InlineData(double.NegativeZero)]
    [InlineData(double.NegativeInfinity)]
    [InlineData(double.PositiveInfinity)]
    public void Creation_of_circle_with_incorrect_radius_is_rejected(double radius)
    {

        FluentActions.Invoking(() => new Circle(radius: radius))
        .Should()
        .Throw<ArgumentOutOfRangeException>();

    }

    [Fact]
    public void Circle_area_is_calculated()
    {
        var shape = new Circle(10d);
        shape.Area
        .Should()
        .BeApproximately(314.159265358979d, 0.000000000001d);
    }

    [Fact]
    public void Creation_of_circle_with_too_big_radius_to_calculate_its_area_is_rejected()
    {
        FluentActions.Invoking(() => new Circle(radius: Math.Sqrt(double.MaxValue / double.Pi) + 0.0000000000001d))
        .Should()
        .Throw<ArgumentOutOfRangeException>();
    }


}
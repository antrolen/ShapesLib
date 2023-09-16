using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ShapesLib.Lib;

namespace ShapesLib.Test;
public class TriangleTests
{
   // **************************************************
    // About Triangle

    [Fact]
    public void Triangle_with_correct_sides_is_created()
    {
        var shape = new Triangle(a: 11d, b: 20d, c: 30d);
        shape.A.Should().Be(11d);
        shape.B.Should().Be(20d);
        shape.C.Should().Be(30d);

    }

    [Theory]
    [InlineData(-1d, 2d, 3d)]
    [InlineData(1d, -2d, 3d)]
    [InlineData(1d, 2d, -3d)]
    [InlineData(double.NaN, 2d, 3d)]
    [InlineData(1d, double.NaN, 3d)]
    [InlineData(1d, 2d, double.NaN)]
    [InlineData(double.NegativeInfinity, 2d, 3d)]
    [InlineData(1d, double.NegativeInfinity, 3d)]
    [InlineData(1d, 2d, double.NegativeInfinity)]
    [InlineData(double.PositiveInfinity, 2d, 3d)]
    [InlineData(1d, double.PositiveInfinity, 3d)]
    [InlineData(1d, 2d, double.PositiveInfinity)]
    [InlineData(double.NegativeZero, 2d, 3d)]
    [InlineData(1d, double.NegativeZero, 3d)]
    [InlineData(1d, 2d, double.NegativeZero)]
    public void Creation_of_triangle_with_incorrect_sides_is_rejected(double a, double b, double c)
    {
        FluentActions.Invoking(() => new Triangle(a: a, b: b, c: c))
        .Should()
        .Throw<ArgumentOutOfRangeException>();
    }


    [Theory]
    [InlineData(1d, 2d, 4d)]
    [InlineData(4d, 1d, 2d)]
    [InlineData(1d, 2d, 3d)]
    [InlineData(1d, 2d, 3.5)]
    public void Creation_of_not_existed_triangle_is_rejected(double a, double b, double c)
    {
        FluentActions.Invoking(() => new Triangle(a: a, b: b, c: c))
        .Should()
        .Throw<ArgumentOutOfRangeException>(); // TODO Create exception
    }

    [Theory]
    [InlineData(3d, 4d, 5d, true)]
    [InlineData(2d, 4d, 5d, false)]
    public void Right_and_notRight_triangles_are_recognised(double a, double b, double c, bool isRight)
    {
        var triangle = new Triangle(a: a, b: b, c: c);
        triangle.IsRight.Should().Be(isRight);
    }


    [Fact]
    public void Creation_of_triangle_too_big_to_calculate_its_area_is_rejected()
    {
        var a = Math.Sqrt(double.MaxValue) * Math.Sqrt(2);
        var b = a;
        var c = Math.Sqrt(double.MaxValue) * 2;


        FluentActions.Invoking(() => new Triangle(a: a, b: b, c: c))
        .Should()
        .Throw<ArgumentOutOfRangeException>();
    }

    [Theory]
    [InlineData(3, 4, 5, 6)]
    public void Area_of_a_very_regular_triangle_is_calculated(double a, double b, double c, double area)
    {
        var shape = new Triangle(a, b, c);
        shape.Area
        .Should()
        .BeApproximately(area, 0.000000000001d);
    }


    [Fact]
    public void Area_of_a_big_triangle_is_calculated___If_it_is_not_there_is_a_problem_with_area_formula()
    {
        var a = Math.Sqrt(double.MaxValue / 2) * Math.Sqrt(2);
        var b = a;
        var c = Math.Sqrt(double.MaxValue / 2) * 2;
        double s = (a + b + c) / 2;
        double area = Math.Pow(s, 0.5) * Math.Pow((s - b) , 0.5) * Math.Pow((s - c), 0.5) * Math.Pow((s - a), 0.5);
        var shape = new Triangle(a, b, c);
        shape.Area
        .Should()
        .BeApproximately(area, 0.000000000001d);
    }
}
using ShapesLib.Lib;

namespace ShapesLib.Test;


// TODO rename
public class CommonTest
{
    // ******************************
    // Common for differet figures
    [Fact]
    public void Circle_and_tringle_are_shapes()
    {
        var circle = new Circle(radius: 10d);
        var triangle = new Triangle(a: 10d, b: 21d, c: 30d);
        var square = new Square(a: 10d);

        circle.Should().BeAssignableTo<IShape>();
        triangle.Should().BeAssignableTo<IShape>();
        square.Should().BeAssignableTo<IShape>();

    }

    // ******************************
 
}


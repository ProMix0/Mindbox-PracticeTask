using System;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using ShapesLib;

namespace ShapeLib.Tests;

public class TriangleTests
{
    static Random random = new();
    
    [Theory]
    [MemberData(nameof(GenerateRandom10))]
    public void Accessible_SideA(double side)
    {
        new Triangle(side, 1, 1).SideA.Should().Be(side);
    }
    
    [Theory]
    [MemberData(nameof(GenerateRandom10))]
    public void Accessible_SideB(double side)
    {
        new Triangle(1, side, 1).SideB.Should().Be(side);
    }
    
    [Theory]
    [MemberData(nameof(GenerateRandom10))]
    public void Accessible_SideC(double side)
    {
        new Triangle(1, 1, side).SideC.Should().Be(side);
    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(3,4,5)]
    [InlineData(10,10,10)]
    public void ValidSides(double a, double b, double c)
    {
        new Triangle(a, b, c).IsValid.Should().BeTrue();
    }
    
    [Theory]
    [InlineData(-1, 2, 3)]
    [InlineData(3,0,5)]
    [InlineData(10,10,100)]
    [InlineData(80,0,100)]
    public void InvalidSides(double a, double b, double c)
    {
        new Triangle(a, b, c).IsValid.Should().BeFalse();
    }

    [Theory]
    [InlineData(3, 4, 5)]
    [InlineData(1, 1, 1.414213562)]
    [InlineData(9, 7, 11.401754251)]
    public void Rectangular(double a, double b, double c)
    {
        new Triangle(a, b, c).IsRectangular.Should().BeTrue();
    }

    [Theory]
    [InlineData(3, 4, 5.1)]
    [InlineData(1, 1, 1.4)]
    [InlineData(9, 7, 11.4)]
    public void NotRectangular(double a, double b, double c)
    {
        new Triangle(a, b, c).IsRectangular.Should().BeFalse();
    }

    [Theory]
    [InlineData(6, 8, 10, 24)]
    [InlineData(15, 9, 12, 54)]
    public void Area(double a, double b, double c, double area)
    {
        new Triangle(a, b, c).Area.Should().Be(area);
    }

    
    public static IEnumerable<object[]> GenerateRandom10()
    {
        for (int i = 0; i < 10; i++)
            yield return new object[] { random.Next(-100, 100) };
    }
}
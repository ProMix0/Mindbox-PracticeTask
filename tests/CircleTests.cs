using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using FluentAssertions;
using ShapesLib;
using Xunit;

namespace ShapeLib.Tests;

public class CircleTests
{
    private static Random random = new();

    [Theory]
    [InlineData(0)]
    [InlineData(-5)]
    [InlineData(-0.9)]
    public void Invalid(double radius)
    {
        new Circle(radius).IsValid.Should().BeFalse();
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(3.14)]
    public void Valid(double radius)
    {
        new Circle(radius).IsValid.Should().BeTrue();
    }

    [Theory]
    [MemberData(nameof(GenerateRandom10))]
    public void Accessible_Radius(double radius)
    {
        new Circle(radius).Radius.Should().Be(radius);
    }

    public void Area()
    {
        // No possibility to test
    }
    
    public static IEnumerable<object[]> GenerateRandom10()
    {
        for (int i = 0; i < 10; i++)
            yield return new object[] { random.Next(-100, 100) };
    }
}
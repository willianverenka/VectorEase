﻿using FluentAssertions;
using VectorEase.Model;
using VectorEase.Utility;

namespace vector_lib.Tests
{
    public class VectorOperationsTest
    {
        [Theory]
        [InlineData(0, 0, 0 ,0 ,0, 0)]
        [InlineData(1, 0, 2, 0, 3, 0)]
        [InlineData(0, 1, 1, 4, 1, 5)]
        public void VectorOperations_VectorSum2D_ReturnsCorrectSum(int a, int b, int a2, int b2, int e1, int e2)
        {
            //arrange
            var vector1 = new Vector2D(a, b);
            var vector2 = new Vector2D(a2, b2);
            // act
            var result = VectorOperations.VectorSum(vector1, vector2);
            // assert
            result.Should().BeOfType<Vector2D>();
            (result.A).Should().Be(e1);
            (result.B).Should().Be(e2);
        }
        [Theory]
        [InlineData(0, 0, 0, 0, 0, 0, 0 ,0 ,0)]
        [InlineData(1, 0, 2, 0, 3, 0, 1, 3, 2)]
        [InlineData(0, 1, 1, 4, 1, 5, 4, 2, 6)]
        public void VectorOperations_VectorSum3D_ReturnsCorrectSum(double a, double b, double c, double a2, double b2, double c2, double e1, double e2, double e3)
        {
            //arrange
            var vector1 = new Vector3D(a, b, c);
            var vector2 = new Vector3D(a2, b2, c2);
            // act
            var result = VectorOperations.VectorSum(vector1, vector2);
            // assert
            result.Should().BeOfType<Vector3D>();
            (result.A).Should().Be(e1);
            (result.B).Should().Be(e2);
            (result.C).Should().Be(e3);
        }
        [Theory]
        [InlineData(3, 4, 5)]
        [InlineData(0, 0, 0)]      
        [InlineData(-2, -2, 2.8284)] 
        public void VectorOperations_Magnitude2D_ReturnsCorrectValue(double a, double b, double expected)
        {
            // arrange
            var vector = new Vector2D(a, b);
            // act
            var result = VectorOperations.Magnitude(vector);
            // assert
            result.Should().BeApproximately(expected, 0.0001);
        }
        [Theory]
        [InlineData(3, 4, 0, 5)]
        [InlineData(0, 0, 0, 0)] 
        [InlineData(-2, -2, 1, 3)] 
        public void VectorOperations_Magnitude3D_ReturnsCorrectValue(double a, double b, double c, double expected)
        {
            // Arrange
            var vector = new Vector3D(a, b, c);

            // Act
            var result = VectorOperations.Magnitude(vector);

            // Assert
            result.Should().BeApproximately(expected, 0.0001);
        }
    }
}
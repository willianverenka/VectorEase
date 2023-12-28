using FluentAssertions;
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
        [Theory]
        [InlineData(1, 1, 1, 1, 2)]
        [InlineData(2, 0, 3, -10, 6)]
        [InlineData(-5, 1, -2, -10, 0)]
        public void VectorOperations_DotProduct2D_ReturnsCorrectValue(double a, double b, double a2, double b2, double expected)
        {
            // Arrange
            var v1 = new Vector2D(a, b);
            var v2 = new Vector2D(a2, b2);
            // Act
            var result = VectorOperations.DotProduct(v1, v2);

            // Assert
            result.Should().BeApproximately(expected, 0.0001);
        }
        [Theory]
        [InlineData(1, 1, 1, 1, 4, 1, 6)]
        [InlineData(2, 0, 3, -10, 6, -3, -29)]
        [InlineData(-5, 1, -2, -10, 0, 3, 44)]
        public void VectorOperations_DotProduct3D_ReturnsCorrectValue(double a, double b, double c, double a2, double b2, double c2, double expected)
        {
            // Arrange
            var v1 = new Vector3D(a, b, c);
            var v2 = new Vector3D(a2, b2, c2);
            // Act
            var result = VectorOperations.DotProduct(v1, v2);

            // Assert
            result.Should().BeApproximately(expected, 0.0001);
        }
        [Theory]
        [InlineData(1, 2, 1, 2, 3, 2, 1, 0, -1)]
        [InlineData(5, 4, 3,1,0,1,4,-2,-4)]
        public void VectorOperations_CrossProduct_ReturnsCorrectValue(double a, double b, double c, double a2,
            double b2, double c2, double iExpected, double jExpected, double kExpected)
        {
            //Arrange

            var v1 = new Vector3D(a, b, c);
            var v2 = new Vector3D(a2, b2, c2);

            // Act

            var result = VectorOperations.CrossProduct(v1, v2).ToList();

            // Assert

            result[0].Should().Be(iExpected);
            result[1].Should().Be(jExpected);
            result[2].Should().Be(kExpected);
        }
        [Fact]
        public void VectorOperations_Multiply2DVectors_ReturnsCorrectValue()
        {
            // Arrange
            var v1 = new Vector2D(-2, -2);
            // Act
            var result = VectorOperations.MultiplyVector(3, v1).ToList();
            //Assert

            result[0].Should().Be(-6);
            result[1].Should().Be(-6);
        }
        [Fact]
        public void VectorOperations_Multiply3DVectors_ReturnsCorrectValue()
        {
            // Arrange
            var v1 = new Vector2D(0, -20);
            // Act
            var result = VectorOperations.MultiplyVector(5, v1).ToList();
            // Assert

            result[0].Should().Be(0);
            result[1].Should().Be(-100);
        }

        [Fact]
        public void VectorOperations_OrthographicProjection_ReturnsCorrectValue()
        {
            // Arrange
            var v1 = new Vector3D(1, 2, -2);
            var vDirection = new Vector3D(3, 2, 1);
            // Act
            var result = VectorOperations.OrthographicProjection(v1, vDirection).ToList();
            // Assert
            result[0].Should().BeApproximately(0.3571 * 3, 0.1);
            result[1].Should().BeApproximately(0.3571 * 2, 0.1);
            result[2].Should().BeApproximately(0.3571 * 1, 0.1);
        }

        [Fact]
        public void VectorOperations_Distance2D_ReturnsCorrectValue()
        {
            // Arrange
            var v1 = new Vector2D(1, 3);
            var v2 = new Vector2D(5, 2);
            // Act
            var result = VectorOperations.Distance(v1, v2);
            // Assert
            result.Should().BeApproximately(Math.Sqrt(17), 0.01);
        }

        [Fact]
        public void VectorOperations_Distance3D_ReturnsCorrectValue()
        {
            // Arrange
            var v1 = new Vector3D(1, 0, 5);
            var v2 = new Vector3D(0, 2, 4);

            // Act
            var result = VectorOperations.Distance(v1, v2);

            // Assert
            result.Should().BeApproximately(Math.Sqrt(6), 0.01);
        }
    }
}

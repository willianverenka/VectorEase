using System.Security.Cryptography.X509Certificates;
using FluentAssertions;
using VectorEase.Utility;

namespace vector_lib.Tests
{
    public class VectorUtilityTests
    {
        [Theory]
        [InlineData(1, 0, 0, 1, 1)]
        [InlineData(0, 0, 0, 0, 0)]
        public void VectorUtility_SendValidMatrix_ReturnCorrectValue(int a, int b, int c, int d, int expected)
        {
            // arrange
            double[,] matrix = new double[,] { {a, b}, {c,d} };
            // act
            var result = VectorUtility.CalculateDeterminant(matrix);
            // assert
            result.Should().BeOfType(typeof(double));
            result.Should().Be(expected);
        }
        [Theory]
        [InlineData(1, 2)]
        [InlineData(0,0)]
        [InlineData(4,4)]
        public void VectorUtility_SendInvalidMatrix_ThrowArgumentException(int a, int b)
        {
            //arrange
            double[,] invalidMatrix = new double[a, b];
            // act
            Action act = () => VectorUtility.CalculateDeterminant(invalidMatrix);
            // assert
            act.Should().Throw<ArgumentException>();
        }
    }
}

using FluentAssertions;
using VectorEase.Utility;

namespace VectorEase.Tests
{
    public class MatrixUtilityTests
    {
        [Theory]
        [InlineData(1, 0, 0, 1, 1)]
        [InlineData(0, 0, 0, 0, 0)]
        public void MatrixUtility_SendValidMatrix_ReturnCorrectValue(int a, int b, int c, int d, int expected)
        {
            // arrange
            double[,] matrix = new double[,] { {a, b}, {c,d} };
            // act
            var result = MatrixUtility.CalculateDeterminant(matrix);
            // assert
            result.Should().BeOfType(typeof(double));
            result.Should().Be(expected);
        }
        [Theory]
        [InlineData(1, 2)]
        [InlineData(0,0)]
        [InlineData(4,4)]
        public void MatrixUtility_SendInvalidMatrix_ThrowArgumentException(int a, int b)
        {
            //arrange
            double[,] invalidMatrix = new double[a, b];
            // act
            Action act = () => MatrixUtility.CalculateDeterminant(invalidMatrix);
            // assert
            act.Should().Throw<ArgumentException>();
        }
    }
}

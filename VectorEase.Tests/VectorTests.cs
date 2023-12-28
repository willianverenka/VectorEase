using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using VectorEase.Model;

namespace vector_lib.Tests
{
    public class VectorTests
    {
        private Vector2D _v2d;
        private Vector3D _v3d;
        public VectorTests()
        {
            _v2d = new Vector2D(5, 2);
            _v3d = new Vector3D(-10, 3, 19);
        }

        [Theory]
        [InlineData(0, 5)]
        [InlineData(1, 2)]
        public void VectorTests_GetComponent2D_ReturnCorrectComponent(int input, double expected)
        {
            // Act

            var result = _v2d.GetComponent(input);

            // Assert

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(0, -10)]
        [InlineData(1, 3)]
        [InlineData(2, 19)]
        public void VectorTests_GetComponent3D_ReturnCorrectComponent(int input, double expected)
        {
            // Act
            
            var result = _v3d.GetComponent(input);

            // Assert

            result.Should().Be(expected);
        }
        [Theory]
        [InlineData(-10)]
        [InlineData(3)]
        [InlineData(8)]
        public void VectorTests_GetInvalidComponent_ThrowArgumentException(int input)
        {
            // Act

            Action act2d = () => _v2d.GetComponent(input);
            Action act3d = () => _v3d.GetComponent(input);

            // Assert

            act2d.Should().Throw<ArgumentException>();
            act3d.Should().Throw<ArgumentException>();
        }
    }
}

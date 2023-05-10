using UnitTesting;

namespace ConsoleApp.Tests
{
    public class MathUtilsTest
    {
        [Fact]
        public void Degree_2Degree8_Return256()
        {
            // Arrange
            int num = 2;
            int degree = 8;

            // Act
            int result = MathUtils.Degree(num, degree);

            // Assert
            Assert.Equal(256, result);
        }

        [Theory]
        [InlineData(2, 2, 4)]
        [InlineData(5, 0, 1)]
        [InlineData(2, 10, 1024)]
        public void Degree_OnSuccess_ReturnDegree(int num, int degree, int expected)
        {
            // Arrange
            // Act
            int result = MathUtils.Degree(num, degree);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Degree_OnFailure_ThrowException()
        {
            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => MathUtils.Degree(2, -16));
        }

        [Fact]
        public void RuinTest()
        {
            Assert.True(false);
        }
    }
}
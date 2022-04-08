using System;
using Xunit;

namespace Calculator.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Addition_Sums_Two_Numbers()
        {
            // Arrange
            float inputA = 30;
            float inputB = 10;
            float expectedSum = 40; // 30 + 10 = 40

            // Act
            var sut = Calculator.Sum(inputA, inputB);

            // Assert
            Assert.Equal<float>(expectedSum, sut);
        }

        [Fact]
        public void Addition_Sums_Multiple_Elements()
        {
            // Arrange
            float[] input = new float[] { 1, 2, 3, 4, 5 }; 
            float expectedSum = 15; // 1 + 2 + 3 + 4 + 5 = 15

            // Act
            var sut = Calculator.Sum(input);

            // Assert
            Assert.Equal<float>(expectedSum, sut);
        }

        [Fact]
        public void Addition_With_No_Numbers_Returns_Zero()
        {
            // Arrange 
            float[] input = new float[0];
            float expectedSum = 0;

            // Act
            var sut = Calculator.Sum(input);

            // Assert
            Assert.Equal<float>(expectedSum, sut);
        }

        [Fact]
        public void Addition_With_One_Number_Returns_That_Number()
        {
            // Arrange 
            float[] input = new float[1] {13};
            float expectedSum = 13;

            // Act
            var sut = Calculator.Sum(input);

            // Assert
            Assert.Equal<float>(expectedSum, sut);
        }

        [Fact]
        public void Subtraction_Returns_Difference_Of_First_Number_And_All_Subsequent()
        {
            // Arrange
            float[] input = new float[] { 100, 50, 30, 2 };
            float expectedDiff = 18; // 100 - 50 - 30 - 2 = 18

            // Act
            var sut = Calculator.Subtract(input);

            // Assert
            Assert.Equal<float>(expectedDiff, sut);
        }

        [Fact]
        public void Subtraction_Returns_Difference_Of_First_And_Second_Number()
        {
            // Arrange
            float inputA = 30;
            float inputB = 10;
            float expectedDiff = 20; // 30 - 10 = 20

            // Act
            var sut = Calculator.Subtract(inputA, inputB);

            // Assert
            Assert.Equal<float>(expectedDiff, sut);
        }

        [Fact]
        public void Subtraction_With_No_Numbers_Returns_Zero()
        {
            // Arrange 
            float[] input = new float[0];
            float expectedDiff = 0;

            // Act
            var sut = Calculator.Subtract(input);

            // Assert
            Assert.Equal<float>(expectedDiff, sut);
        }

        [Fact]
        public void Subtraction_With_One_Number_Returns_That_Number()
        {
            // Arrange 
            float[] input = new float[1] { 13 };
            float expectedDiff = 13;

            // Act
            var sut = Calculator.Subtract(input);

            // Assert
            Assert.Equal<float>(expectedDiff, sut);
        }

        [Fact]
        public void Multiplication_Returns_Product_of_Multiple_Elements()
        {
            // Arrange
            float[] input = new float[] { 1, 2, 3, 4, 5 };
            float expectedSum = 120; // 5! = 120

            // Act
            var sut = Calculator.Multiply(input);

            // Assert
            Assert.Equal<float>(expectedSum, sut);
        }

        [Fact]
        public void Multiplication_With_No_Numbers_Returns_Zero()
        {
            // Arrange 
            float[] input = new float[0];
            float expectedFactor = 0;

            // Act
            var sut = Calculator.Multiply(input);

            // Assert
            Assert.Equal<float>(expectedFactor, sut);
        }

        [Fact]
        public void Multiplication_With_One_Number_Returns_That_Number()
        {
            // Arrange 
            float[] input = new float[1] { 13 };
            float expectedFactor = 13;

            // Act
            var sut = Calculator.Multiply(input);

            // Assert
            Assert.Equal<float>(expectedFactor, sut);
        }

        [Fact]
        public void Divsion_Returns_Quotient_Of_First_Number_And_Second_Number()
        {
            // Arrange
            float dividend = 10;
            float divisor = 3;
            float expectedQuotient = 3.333333333f;

            // Act
            // Does division return the quotient with a reasonable amount of accuracry?
            var sut = Calculator.Divide(dividend, divisor);

            // Assert
            Assert.Equal(expectedQuotient, sut, 4);
        }

        [Fact]
        public void Divsion_By_Zero_Retuns_Infinity()
        {
            // Arrange
            float dividend = -20;
            float divisor = 0;

            // Act
            // Does division by 0 return infinity without crashing or throwing errors?
            bool sut = float.IsPositiveInfinity(Calculator.Divide(dividend, divisor));

            // Asset
            Assert.True(sut);
        }
    }
}

using System;
using Xunit;

namespace Calculator.Tests
{
    public class ValidatorTests
    {
        [Fact]
        public void Does_Not_Validate_Non_Numerical_Strings()
        {
            // Arrange
            string illeagalInput = "eight";

            // Act
            var sut = Validator.ConfirmLegalInputs(illeagalInput, out var numbers, out var errors);

            // Assert
            Assert.False(sut);
        }

        [Fact]
        public void Does_Not_Validate_Decimals_With_Dots()
        {

            // Arrange
            string illeagalInput = "85.1";

            // Act
            var sut = Validator.ConfirmLegalInputs(illeagalInput, out var numbers, out var errors);

            // Assert
            Assert.False(sut);
        }

        [Fact]
        public void Validates_Decimals_With_Commas()
        {

            // Arrange
            string legalInput = "85,1";

            // Act
            var sut = Validator.ConfirmLegalInputs(legalInput, out var numbers, out var errors);

            // Assert
            Assert.True(sut);
        }

        [Fact]
        public void Validates_Multiple_Correctly_Formated_Numbers()
        {

            // Arrange
            string legalInput = "1 2 3 4,5 5,326";

            // Act
            var sut = Validator.ConfirmLegalInputs(legalInput, out var numbers, out var errors);

            // Assert
            Assert.True(sut);
        }

        [Fact]
        public void Uses_Space_As_Seperator()
        {

            // Arrange
            string legalInput = "0 1,5 3";
            int expectedLength = 3;

            // Act
            bool confirmed = Validator.ConfirmLegalInputs(legalInput, out var sut, out var errors);

            // Assert
            Assert.Equal<float>(expectedLength, sut.Length);
        }

        [Fact]
        public void Does_Not_Validate_Too_Few_Inputs()
        {

            // Arrange
            string illegalInput = "1 2";

            // Act
            // Request at least 3 inputs but enter only 2
            var sut = Validator.ConfirmLegalInputs(illegalInput, out var numbers, 3);

            // Assert
            Assert.False(sut);
        }

        [Fact]
        public void Does_Not_Validate_Missing_Inputs()
        {

            // Arrange
            string illegalInput = "";

            // Act
            var sut = Validator.ConfirmLegalInputs(illegalInput, out var numbers);

            // Assert
            Assert.False(sut);
        }

        [Fact]
        public void Does_Not_Validate_Division_With_Zero()
        {

            // Arrange
            string illegalInput = "1 0";

            // Act
            var sut = Validator.ConfirmLegalDivsionInput(illegalInput, out var numbers, out var errors);

            // Assert
            Assert.False(sut);
        }

        [Fact]
        public void Does_Not_Validate_Infinity()
        {

            // Arrange
            string illegalInput = "9999999999999999999999999999999999999999"; // Bigger than float.MaxValue

            // Act
            var sut = Validator.ConfirmLegalInputs(illegalInput, out var numbers);

            // Assert
            Assert.False(sut);
        }
    }
}

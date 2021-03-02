using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TestingAssignment2;
namespace TestingAssignment2Tests
{
    public class TestMethods
    {
        [Fact]
        public void Test_ChangeCase()
        {
            // Arrange
            var inputString = "Hetvi";
            var outputString = "hetvi";
            // Act
            var newString = inputString.CreateUpperCase();
            // Assert
            Assert.Equal(newString, outputString);
        }
        [Fact]
        public void Test_ChangeToTitleCase()
        {
            // Arrange
            var inputString = "hello world, what's up ?";
            var outputString = "Hello World, What's Up ?";
            // Act
            var newString = inputString.TitleCase();
            // Assert
            Assert.Equal(newString, outputString);
        }
        [Fact]
        public void Test_IsLowerCaseString()
        {
            // Arrange
            var inputString = "hetvishah";
            // Act
            var newString = inputString.LowerCase();
            // Assert
            Assert.True(newString);
        }
        [Fact]
        public void Test_IsUpperCaseString()
        {
            // Arrange
            var inputString = "HETVI";
            // Act
            var newString = inputString.IsUpperCaseString();
            // Assert
            Assert.True(newString);
        }
        [Fact]
        public void Test_DoCapitalize()
        {
            // Arrange
            var inputString = "hetvi";
            var outputString = "HETVI";
            // Act
            var newString = inputString.Capitalize();
            // Assert
            Assert.Equal(newString, outputString);
        }
        [Theory]
        [InlineData("56", true)]
        [InlineData("12d", false)]
        public void Test_IsValidNumericValue(string inputString, bool result)
        {
            // Arrange

            // Act
            var newString = inputString.IsValidNumericValue();
            // Assert
            Assert.Equal(newString, result);
        }
        [Fact]
        public void Test_RemoveLastCharacter()
        {
            // Arrange
            var inputString = "HetviShah";
            var outputString = "HetviSha";
            // Act
            var newString = inputString.RemoveLastCharacter();
            // Assert
            Assert.Equal(newString, outputString);
        }
        [Fact]
        public void Test_WordCount()
        {
            // Arrange
            var inputString = "Hello World";
            var count = 2;
            // Act
            var newString = inputString.WordCount();
            // Assert
            Assert.Equal(newString, count);
        }
        [Fact]
        public void Test_StringToInteger()
        {
            // Arrange
            var inputString = "78765";
            var output = 123;
            // Act
            var newString = inputString.StringToInteger();
            // Assert
            Assert.Equal(newString, output);
        }
    }
}

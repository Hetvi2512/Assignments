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
            var input = "Hetvi";
            var outputString = "hetvi";
            // Act
            var newString = input.CreateUpperCase();
            // Assert
            Assert.Equal(newString, outputString);
        }
        [Fact]
        public void Test_ChangeToTitleCase()
        {
            // Arrange
            var input = "hello world, what's up ?";
            var outputString = "Hello World, What's Up ?";
            // Act
            var newString = input.TitleCase();
            // Assert
            Assert.Equal(newString, outputString);
        }
        [Fact]
        public void Test_IsLowerCaseString()
        { //Arrange
            var input = "MEET";
            var expectedValue = "meet";
            // Act
            var result = input.LowerCase();
            //Assert
            Assert.Equal(expectedValue, result);
        
        }
        [Fact]
        public void Test_IsUpperCaseString()
        {
            // Arrange
            var input = "HETVI";
            // Act
            var newString = input.IsUpperCaseString();
            // Assert
            Assert.True(newString);
        }
        [Fact]
      
        public void Test_AddUpperCase()
        {
            //Arrange
            var input = "hetvi";
            var expectedValue = "HETVI";
            // Act
            var result = input.AddUpperCase();
            //Assert
            Assert.Equal(expectedValue, result);
        }
       
        [Fact]
        public void Test_RemoveLastCharacter()
        {
            // Arrange
            var input = "HetviShah";
            var outputString = "HetviSha";
            // Act
            var newString = input.RemoveLastCharacter();
            // Assert
            Assert.Equal(newString, outputString);
        }
        [Fact]
        public void Test_WordCount()
        {
            // Arrange
            var input = "Hello World";
            var count = 2;
            // Act
            var newString = input.WordCount();
            // Assert
            Assert.Equal(newString, count);
        }
        [Fact]
        public void Test_StringToInteger()
        {
            // Arrange
            var input = "78765";
            var output = 123;
            // Act
            var newString = input.StringToInteger();
            // Assert
            Assert.Equal(newString, output);
        }
    }
}

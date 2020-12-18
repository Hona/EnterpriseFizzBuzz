using System;
using System.Linq;
using FizzBuzz.Core.Helpers;
using FizzBuzz.Core.Models;
using FizzBuzz.Core.Services;
using Xunit;

namespace FizzBuzz.Core.Tests
{
    public class FizzBuzzServiceTests
    {
        private readonly IFizzBuzzService _fizzBuzzService;

        public FizzBuzzServiceTests()
        {
            _fizzBuzzService = new FizzBuzzService();
        }

        [Fact]
        public void GetFizzBuzz_With0_Returns0()
        {
            // Act
            var result = _fizzBuzzService.GetFizzBuzzResult(0);
            
            // Assert
            Assert.Equal(FizzBuzzResultFlags.None, result.ResultFlags);
        }
        
        [Fact]
        public void GetFizzBuzz_With3_ReturnsBuzz()
        {
            // Act
            var result = _fizzBuzzService.GetFizzBuzzResult(3);
            
            // Assert
            Assert.Equal(FizzBuzzResultFlags.Fizz, result.ResultFlags);
        }
        
        [Fact]
        public void GetFizzBuzz_With5_ReturnsBuzz()
        {
            // Act
            var result = _fizzBuzzService.GetFizzBuzzResult(5);
            
            // Assert
            Assert.Equal(FizzBuzzResultFlags.Buzz, result.ResultFlags);
        }
        
        [Fact]
        public void GetFizzBuzz_With15_ReturnsFizzBuzz()
        {
            // Act
            var result = _fizzBuzzService.GetFizzBuzzResult(15);
            
            // Assert
            Assert.Equal(FizzBuzzResultFlags.FizzBuzz, result.ResultFlags);
        }
        
        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        [InlineData(45)]
        [InlineData(60)]
        [InlineData(315)]
        [InlineData(870)]
        public void GetFizzBuzz_WithData_ReturnsFizzBuzz(int value)
        {
            // Act
            var result = _fizzBuzzService.GetFizzBuzzResult(value);
            
            // Assert
            Assert.Equal(FizzBuzzResultFlags.FizzBuzz, result.ResultFlags);
        }
        
        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(9)]
        [InlineData(12)]
        [InlineData(18)]
        [InlineData(3000003)]
        public void GetFizzBuzz_WithData_ReturnsFizz(int value)
        {
            // Act
            var result = _fizzBuzzService.GetFizzBuzzResult(value);
            
            // Assert
            Assert.Equal(FizzBuzzResultFlags.Fizz, result.ResultFlags);
        }
        
        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(50)]
        [InlineData(1025)]
        [InlineData(2050)]
        [InlineData(100000010)]
        public void GetFizzBuzz_WithData_ReturnsBuzz(int value)
        {
            // Act
            var result = _fizzBuzzService.GetFizzBuzzResult(value);
            
            // Assert
            Assert.Equal(FizzBuzzResultFlags.Buzz, result.ResultFlags);
        }

        [Fact]
        public void GetFizzBuzz_WithMultiplesOf3_ContainsFizz()
        {
            // Arrange
            var range = Enumerable.Range(1, 1000);
            var values = range.Select(x => x * 3);
            
            // Act
            var results = values.Select(x => _fizzBuzzService.GetFizzBuzzResult(x));
            
            // Assert
            Assert.All(results, result => result.ResultFlags.HasFlagFast(FizzBuzzResultFlags.Fizz));
        }
        
        [Fact]
        public void GetFizzBuzz_WithMultiplesOf3_ContainsBuzz()
        {
            // Arrange
            var range = Enumerable.Range(1, 1000);
            var values = range.Select(x => x * 5);
            
            // Act
            var results = values.Select(x => _fizzBuzzService.GetFizzBuzzResult(x));
            
            // Assert
            Assert.All(results, result => result.ResultFlags.HasFlagFast(FizzBuzzResultFlags.Buzz));
        }
    }
}
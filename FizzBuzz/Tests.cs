using System;
using System.Collections.Generic;
using Xunit;

namespace FizzBuzz
{
    /// <summary>
    /// Write a program that prints the numbers from 1 to 100. 
    /// But for multiples of three print “Fizz” instead of the number and for the multiples of five print “Buzz”. 
    /// For numbers which are multiples of both three and five print “FizzBuzz “.
    /// </summary>
    public class Tests
    {
        [Theory]
        [InlineData(9)]
        public void Number_Nine_Should_Be_Fizz(int Number)
        {
            var task = new FizzBuzzGenerator();

            var expectedWord = "Fizz";

            Assert.Equal(expectedWord, task.WordList()[Number - 1]);
        }

        [Theory]
        [InlineData(5)]
        public void Number_Five_Should_Be_Buzz(int Number)
        {
            var task = new FizzBuzzGenerator();

            var expectedWord = "Buzz";

            Assert.Equal(expectedWord, task.WordList()[Number - 1]);
        }


        [Theory]
        [InlineData(15)]
        public void Number_Fifteen_Should_Be_FizzBuzz(int Number)
        {
            var task = new FizzBuzzGenerator();

            var expectedWord = "FizzBuzz";

            Assert.Equal(expectedWord, task.WordList()[Number - 1]);
        }
    }
}

using Xunit;

namespace StringCalculator
{
    public class Tests
    {
        [Theory]
        [InlineData("1")]
        public void One_Number_Sum(string numbers)
        {
            var task = new StringCalculatorGenerator();
            char[] delimeters = { ',' };
            var expectedSum = 1;

            Assert.Equal(expectedSum, task.AddNumbers(numbers, delimeters));
        }
        [Theory]
        [InlineData("1,5")]
        public void Two_Numbers_Sum(string numbers)
        {
            var task = new StringCalculatorGenerator();
            char[] delimeters = { ',' };
            var expectedSum = 6;

            Assert.Equal(expectedSum, task.AddNumbers(numbers, delimeters));
        }
        [Theory]
        [InlineData("1,5,5")]
        public void Three_Numbers_Sum(string numbers)
        {
            var task = new StringCalculatorGenerator();
            char[] delimeters = { ',' };

            var expectedSum = 11;

            Assert.Equal(expectedSum, task.AddNumbers(numbers, delimeters));
        }
        [Theory]
        [InlineData("1,1,1,1,1,1")]
        public void Multiple_Numbers_Sum(string numbers)
        {
            var task = new StringCalculatorGenerator();
            char[] delimeters = { ',' };

            var expectedSum = 6;

            Assert.Equal(expectedSum, task.AddNumbers(numbers, delimeters));
        }

        [Theory]
        [InlineData("10/1*1-1,1,1")]
        public void MultipleDelimeters_Numbers_Sum(string numbers)
        {
            var task = new StringCalculatorGenerator();
            char[] delimeters = { '/', '*' ,'-',',' };
            var expectedSum = 15;

            Assert.Equal(expectedSum, task.AddNumbers(numbers, delimeters));
        }
    }
}

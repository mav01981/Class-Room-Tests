using PrimeFactors;
using System.Collections.Generic;
using Xunit;

public class Tests
{
    [Theory]
    [InlineData(1)]
    public void Prime_Factors_of_One(int number)
    {
        var primeFactorGenerator = new PrimeFactorGenerator();
        Assert.Empty(primeFactorGenerator.GetPrimeFactors(number));
    }

    [Theory]
    [InlineData(2)]
    public void Prime_Factors_of_Two(int number)
    {
        var primeFactorGenerator = new PrimeFactorGenerator();

        var expectedPrimeFactors = new List<int> { 2 };

        Assert.Equal(expectedPrimeFactors, primeFactorGenerator.GetPrimeFactors(number));
    }

    [Theory]
    [InlineData(3)]
    public void Prime_Factors_of_Three(int number)
    {
        var primeFactorGenerator = new PrimeFactorGenerator();

        var expectedPrimeFactors = new List<int> { 3 };

        Assert.Equal(expectedPrimeFactors, primeFactorGenerator.GetPrimeFactors(number));
    }
    [Theory]
    [InlineData(4)]
    public void Prime_Factors_of_four(int number)
    {
        var primeFactorGenerator = new PrimeFactorGenerator();

        var expectedPrimeFactors = new List<int> { 2, 2 };

        Assert.Equal(expectedPrimeFactors, primeFactorGenerator.GetPrimeFactors(number));
    }
    [Theory]
    [InlineData(5)]
    public void Prime_Factors_of_five(int number)
    {
        var primeFactorGenerator = new PrimeFactorGenerator();

        var expectedPrimeFactors = new List<int> { 5 };

        Assert.Equal(expectedPrimeFactors, primeFactorGenerator.GetPrimeFactors(number));
    }
    [Theory]
    [InlineData(8)]
    public void Prime_Factors_of_eight(int number)
    {
        var primeFactorGenerator = new PrimeFactorGenerator();

        var expectedPrimeFactors = new List<int> { 2, 2, 2 };

        Assert.Equal(expectedPrimeFactors, primeFactorGenerator.GetPrimeFactors(number));
    }
    [Theory]
    [InlineData(10)]
    public void Prime_Factors_of_ten(int number)
    {
        var primeFactorGenerator = new PrimeFactorGenerator();

        var expectedPrimeFactors = new List<int> { 2, 5 };

        Assert.Equal(expectedPrimeFactors, primeFactorGenerator.GetPrimeFactors(number));
    }
    [Theory]
    [InlineData(12)]
    public void Prime_Factors_of_twelve(int number)
    {
        var primeFactorGenerator = new PrimeFactorGenerator();

        var expectedPrimeFactors = new List<int> { 2, 2, 3 };

        Assert.Equal(expectedPrimeFactors, primeFactorGenerator.GetPrimeFactors(number));
    }

    [Theory]
    [InlineData(100)]
    public void Prime_Factors_of_100(int number)
    {
        var primeFactorGenerator = new PrimeFactorGenerator();

        var expectedPrimeFactors = new List<int> { 2, 2, 5, 5 };

        Assert.Equal(expectedPrimeFactors, primeFactorGenerator.GetPrimeFactors(number));
    }

    [Theory]
    [InlineData(234)]
    public void Prime_Factors_of_234(int number)
    {
        var primeFactorGenerator = new PrimeFactorGenerator();

        var expectedPrimeFactors = new List<int> { 2, 3, 3, 13 };

        Assert.Equal(expectedPrimeFactors, primeFactorGenerator.GetPrimeFactors(number));
    }
}


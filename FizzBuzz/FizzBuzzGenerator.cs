using System.Collections.Generic;

namespace FizzBuzz
{
    /// <summary>
    /// Step 1
    /// Write a program that prints the numbers from 1 to 100. 
    /// But for multiples of three print “Fizz” instead of the number and for the multiples of five print “Buzz”. 
    /// For numbers which are multiples of both three and five print “FizzBuzz “.
    /// </summary>
    public class FizzBuzzGenerator
    {
        private List<string> output;

        public FizzBuzzGenerator()
        {
            output = new List<string>();
        }

        public List<string> WordList()
        {
            for (int i = 1; i <= 100; i++)
            {
                output.Add(((i % 3 == 0) && (i % 5 == 0)) ? "FizzBuzz"
                                         : (i % 3 == 0) ? "Fizz"
                                                : (i % 5 == 0) ? "Buzz"
                                                        : i.ToString());
            }

            return output;
        }
    }
}

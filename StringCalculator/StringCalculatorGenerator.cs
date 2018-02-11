using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculatorGenerator
    {
        public int AddNumbers(string numbers, char[] format)
        {
            return FormatNumbers(numbers, format);
        }

        int FormatNumbers(string numbers, char[] format)
        {
            List<int> numberCollection = new List<int>();

            var collection = numbers.Split(format);

            foreach (var item in collection)
            {
                int Output = 0;
                int.TryParse(item, out Output);

                if (Output > 0)
                    numberCollection.Add(Output);
            }
            return numberCollection.Take(numberCollection.Count).Sum();
        }
    }
}

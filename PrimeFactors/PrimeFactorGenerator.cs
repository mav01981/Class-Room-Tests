using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PrimeFactors
{
    public class PrimeFactorGenerator
    {
        public List<int> PrimeFactors = new List<int>();
        /// <summary>
        /// If number is greater than 1 and divisble by itself
        /// </summary>
        /// <param name="number"> Number value</param>
        /// <returns></returns>
        private bool IsPrimeNumber(int number)
        {
            int count = 0;
            for (int i = 1; i <= number; i++)
            {
                if (number > 1 && number % i == 0)
                    count++;
            }
            return count == 2 ? true : false;
        }

        public List<int> GetPrimeFactors(int number)
        {
            List<int> PrimeFactors = new List<int>();

            for (int i = 1; i <= number; i++)
            {
                if (IsPrimeNumber(i))
                {
                    int total = number;
                    bool check = false;
                    while (total % i == 0)
                    {
                        PrimeFactors.Add(i);
                        total /= i;
                        check = true;
                    }

                    if (check)
                    {
                        int sum = 1;

                        foreach (int value in PrimeFactors)
                        {
                            sum = sum * value;
                        }

                        if (sum == number) break;
                    }
                }
            }
            return PrimeFactors;
        }
    }
}

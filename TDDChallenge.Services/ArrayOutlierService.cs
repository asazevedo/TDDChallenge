using System;
using System.Linq;

namespace TDDChallenge.Services
{
    /// <summary>Array outlier service</summary>
    public class ArrayOutlierService
    {
        /// <summary>Array input with even or odd numbers. Can be mixed</summary>
        protected readonly int[] EvenOrOddArray;

        /// <summary>Returns the even count. Initialized inside the constructor</summary>
        public readonly int EvenCount;

        /// <summary>Returns the Odd count. Initialized inside the constructor</summary>
        public readonly int OddCount;

        /// <summary>Service constructor. Accepts an array input with odd or even numbers. Can be mixed</summary>
        /// <param name="evenOrOddArray">Array input with odd or even numbers. Can be mixed</param>
        public ArrayOutlierService(int[] evenOrOddArray)
        {
            EvenOrOddArray = evenOrOddArray;

            EvenCount = EvenOrOddArray?.Count(number => number % 2 == 0) ?? 0;
            OddCount = EvenOrOddArray?.Count(number => number % 2 != 0) ?? 0;
        }

        /// <summary>Method used to find an outlier number inside of the mixed array input</summary>
        /// <summary>If the input array is "mostly" with odd numbers. Returns the first even number</summary>
        /// <summary>If the input array is "mostly" with even numbers. Returns the first odd number</summary>
        public int FindOutlier()
        {
            ValidateArray();

            var outlier = 0;

            var arrayIsEven = (EvenCount == OddCount) ? EvenOrOddArray[0] % 2 == 0 : EvenCount > OddCount;
            var arrayIsOdd = (EvenCount == OddCount) ? EvenOrOddArray[0] % 2 != 0 : OddCount > EvenCount;

            foreach (var number in EvenOrOddArray)
            {
                var numberIsOdd = number % 2 != 0;
                var numberIsEven = number % 2 == 0;

                if (arrayIsOdd != numberIsOdd)
                {
                    outlier = number;
                    break;
                }

                if (arrayIsEven != numberIsEven)
                {
                    outlier = number;
                    break;
                }
            }

            return outlier;
        }

        /// <summary>Validates the input array</summary>
        protected void ValidateArray()
        {
            if (EvenOrOddArray == null)
                throw new ArgumentNullException("Input array cannot be null");

            if (!EvenOrOddArray.Any())
                throw new ArgumentException("Input array cannot be empty");
        }
    }
}

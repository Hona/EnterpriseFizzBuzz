using System.Collections.Generic;
using System.Linq;
using FizzBuzz.Core.Helpers;
using FizzBuzz.Core.Models;

namespace FizzBuzz.Core.Services
{
    public class FizzBuzzService : IFizzBuzzService
    {
        public IEnumerable<FizzBuzzResult> GetFizzBuzzResults(int upper) => GetFizzBuzzResults(0, upper);

        public IEnumerable<FizzBuzzResult> GetFizzBuzzResults(int lower, int upper)
        {
            for (var i = lower; i <= upper; i++)
            {
                yield return GetFizzBuzzResult(i);
            }
        }

        public FizzBuzzResult GetFizzBuzzResult(int number)
        {
            var resultFlags = FizzBuzzResultFlags.None;

            if (number % 3 == 0)
            {
                resultFlags |= FizzBuzzResultFlags.Fizz;
            }

            if (number % 5 == 0)
            {
                resultFlags |= FizzBuzzResultFlags.Buzz;
            }

            // Zero needs to return none, even though it will get FizzBuzz from above
            if (number == 0)
            {
                resultFlags = FizzBuzzResultFlags.None;
            }

            return new FizzBuzzResult
            {
                Number = number,
                ResultFlags = resultFlags
            };
        }

        public IEnumerable<int> GetNumbersFromFlag(IEnumerable<FizzBuzzResult> fizzBuzzResults, FizzBuzzResultFlags resultFlags)
        {
            return fizzBuzzResults.Where(x => x.ResultFlags.HasFlagFast(resultFlags))
                .Select(x => x.Number);
        }
    }
}
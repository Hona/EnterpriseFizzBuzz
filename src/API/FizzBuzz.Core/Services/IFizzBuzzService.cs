using System.Collections.Generic;
using FizzBuzz.Core.Models;

namespace FizzBuzz.Core.Services
{
    public interface IFizzBuzzService
    {
        /// <summary>
        /// Returns FizzBuzz results from 0 to `upper`
        /// </summary>
        /// <param name="upper">The upper bound of the results, inclusive</param>
        /// <returns></returns>
        IEnumerable<FizzBuzzResult> GetFizzBuzzResults(int upper);
        
        /// <summary>
        /// Returns FizzBuzz results from `lower` to `upper`
        /// </summary>
        /// <param name="lower">The lower bound of the results, inclusive</param>
        /// <param name="upper">The upper bound of the results, inclusive</param>
        /// <returns></returns>
        IEnumerable<FizzBuzzResult> GetFizzBuzzResults(int lower, int upper);

        /// <summary>
        /// Gets the FizzBuzz result from a `number`
        /// </summary>
        /// <param name="number">The `number` to get the FizzBuzz result from</param>
        /// <returns></returns>
        FizzBuzzResult GetFizzBuzzResult(int number);

        /// <summary>
        /// Returns the numbers that satisfy the result flags
        /// </summary>
        /// <param name="fizzBuzzResults">The input FizzBuzz results</param>
        /// <param name="resultFlags">The result flag/s that are being searched for</param>
        /// <returns></returns>
        IEnumerable<int> GetNumbersFromFlag(IEnumerable<FizzBuzzResult> fizzBuzzResults, FizzBuzzResultFlags resultFlags);

    }
}
using FizzBuzz.Core.Models;

namespace FizzBuzz.Core.Helpers
{
    public static class FizzBuzzResultExtensions
    {
        public static bool HasFlagFast(this FizzBuzzResultFlags value, FizzBuzzResultFlags flag)
        {
            return (value & flag) != 0;
        }
    }
}
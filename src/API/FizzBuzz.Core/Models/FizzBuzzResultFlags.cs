using System;

namespace FizzBuzz.Core.Models
{
    [Flags]
    public enum FizzBuzzResultFlags
    {
        None = 0,
        Fizz = 1,
        Buzz = 1 << 1,
        FizzBuzz = Fizz | Buzz
    }
}
using System;

namespace FizzBuzz.Application.DTOs
{
    [Flags]
    public enum FizzBuzzResultFlagsDto
    {
        None = 0,
        Fizz = 1,
        Buzz = 1 << 1,
        FizzBuzz = Fizz | Buzz
    }
}
using AutoMapper;
using FizzBuzz.Application.DTOs;
using FizzBuzz.Core.Models;

namespace FizzBuzz.Application
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<FizzBuzzResult, FizzBuzzResultDto>();
            CreateMap<FizzBuzzResultFlags, FizzBuzzResultFlagsDto>();
        }
    }
}
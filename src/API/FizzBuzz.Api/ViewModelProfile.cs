using AutoMapper;
using FizzBuzz.Api.ViewModels;
using FizzBuzz.Application.DTOs;

namespace FizzBuzz.Api
{
    public class ViewModelProfile : Profile
    {
        public ViewModelProfile()
        {
            CreateMap<FizzBuzzResultDto, FizzBuzzResultViewModel>()
                .ForMember(x => x.Result, prop => prop.MapFrom(x => x.ResultFlags == FizzBuzzResultFlagsDto.None ? x.Number.ToString() : x.ResultFlags.ToString()));
        }
    }
}
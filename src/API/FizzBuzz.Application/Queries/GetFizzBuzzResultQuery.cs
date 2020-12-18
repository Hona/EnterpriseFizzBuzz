using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FizzBuzz.Application.DTOs;
using FizzBuzz.Core.Services;
using MediatR;

namespace FizzBuzz.Application.Queries
{
    public class GetFizzBuzzResultQuery : IRequest<FizzBuzzResultDto>
    {
        public int Number { get; set; }
    }
    
    public class GetFizzBuzzResultQueryHandler : IRequestHandler<GetFizzBuzzResultQuery, FizzBuzzResultDto>
    {
        private readonly IMapper _mapper;
        private readonly IFizzBuzzService _fizzBuzzService;

        public GetFizzBuzzResultQueryHandler(IMapper mapper, IFizzBuzzService fizzBuzzService)
        {
            _mapper = mapper;
            _fizzBuzzService = fizzBuzzService;
        }

        public Task<FizzBuzzResultDto> Handle(GetFizzBuzzResultQuery request, CancellationToken cancellationToken)
        {
            var fizzBuzzResults = _fizzBuzzService.GetFizzBuzzResult(request.Number);

            var output = _mapper.Map<FizzBuzzResultDto>(fizzBuzzResults);
            return Task.FromResult(output);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FizzBuzz.Application.DTOs;
using FizzBuzz.Core.Models;
using FizzBuzz.Core.Services;
using MediatR;

namespace FizzBuzz.Application.Queries
{
    public class GetFizzBuzzResultsQuery : IRequest<IEnumerable<FizzBuzzResultDto>>
    {
        public int? Lower { get; set; }
        public int? Upper { get; set; }
    }
    
    public class GetFizzBuzzResultsQueryHandler : IRequestHandler<GetFizzBuzzResultsQuery, IEnumerable<FizzBuzzResultDto>>
    {
        private readonly IMapper _mapper;
        private readonly IFizzBuzzService _fizzBuzzService;

        public GetFizzBuzzResultsQueryHandler(IMapper mapper, IFizzBuzzService fizzBuzzService)
        {
            _mapper = mapper;
            _fizzBuzzService = fizzBuzzService;
        }

        public Task<IEnumerable<FizzBuzzResultDto>> Handle(GetFizzBuzzResultsQuery request, CancellationToken cancellationToken)
        {
            if (!request.Lower.HasValue && !request.Upper.HasValue)
            {
                throw new Exception("You must specify at least the upper limit argument");
            }
            
            if (!request.Upper.HasValue)
            {
                throw new Exception("You must specify an upper limit");
            }

            var fizzBuzzResults = _fizzBuzzService.GetFizzBuzzResults(request.Lower ?? 0, request.Upper.Value);

            var output = _mapper.Map<IEnumerable<FizzBuzzResultDto>>(fizzBuzzResults);
            return Task.FromResult(output);
        }
    }
}
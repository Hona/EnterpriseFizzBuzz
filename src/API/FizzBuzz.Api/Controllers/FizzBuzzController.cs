using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FizzBuzz.Api.ViewModels;
using FizzBuzz.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FizzBuzz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FizzBuzzController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public FizzBuzzController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetFizzBuzzResults([FromQuery] int? lower = null, [FromQuery] int? upper = null)
        {
            var query = new GetFizzBuzzResultsQuery
            {
                Lower = lower,
                Upper = upper
            };

            var resultDtos = await _mediator.Send(query);

            var result = _mapper.Map<IEnumerable<FizzBuzzResultViewModel>>(resultDtos);
            return Ok(result);
        }
        
        [HttpGet("{number}")]
        public async Task<IActionResult> GetFizzBuzzResult(int number)
        {
            var query = new GetFizzBuzzResultQuery
            {
                Number = number
            };

            var resultDto = await _mediator.Send(query);

            var result = _mapper.Map<FizzBuzzResultViewModel>(resultDto);
            return Ok(result);
        }
    }
}
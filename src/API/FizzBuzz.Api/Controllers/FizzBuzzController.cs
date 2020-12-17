using System.Threading.Tasks;
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

        public FizzBuzzController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> GetFizzBuzzResults([FromQuery] int? lower = null, [FromQuery] int? upper = null)
        {
            var query = new GetFizzBuzzResultsQuery
            {
                Lower = lower,
                Upper = upper
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
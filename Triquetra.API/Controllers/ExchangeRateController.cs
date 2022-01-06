using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Triquetra.Core.Exceptions;
using Triquetra.Core.Handlers.Commands;
using Triquetra.Core.Handlers.Queries;
using Triquetra.Core.Handlers.Queries.ExchangeRates;
using Triquetra.Domain.DTO;
using Triquetra.Domain.DTO.ExchangeRates;

namespace Triquetra.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeRateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExchangeRateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<ExchangeRateDTO>> Get()
        {
            var query = new GetAllExchangeRatesQuery();
            var response = await _mediator.Send(query);
            return response;
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int) HttpStatusCode.Created)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        public async Task<IActionResult> Post([FromBody] CreateExchangeRateDTO model)
        {
            try
            {
                var command = new CreateExchangeRateCommand(model);
                var response = await _mediator.Send(command);
                return StatusCode((int) HttpStatusCode.Created, response);
            }
            catch (InvalidRequestBodyException ex)
            {
                return BadRequest(new BaseResponseDTO
                {
                    IsSuccess = false,
                    Errors = ex.Errors
                });
            }
        }
    }
}
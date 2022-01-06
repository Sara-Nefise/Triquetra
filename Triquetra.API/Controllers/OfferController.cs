using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Triquetra.Core.Exceptions;
using Triquetra.Core.Handlers.Commands;
using Triquetra.Core.Handlers.Queries;
using Triquetra.Core.Handlers.Queries.Offers;
using Triquetra.Domain.DTO;
using Triquetra.Domain.DTO.Offers;
using Triquetra.Providers.Handlers.Queries;

namespace Triquetra.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OfferController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<OfferDTO>> Get()
        {
            var query = new GetAllOffersQuery();
            var response = await _mediator.Send(query);
            return response;
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int) HttpStatusCode.Created)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        public async Task<IActionResult> Post([FromBody] CreateOfferDTO model)
        {
            try
            {
                var command = new CreateOfferCommand(model);
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

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(OfferDTO), (int) HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var query = new GetOfferByIdQuery(id);
                var response = await _mediator.Send(query);
                return Ok(response);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new BaseResponseDTO
                {
                    IsSuccess = false,
                    Errors = new string[] {ex.Message}
                });
            }
        }
    }
}
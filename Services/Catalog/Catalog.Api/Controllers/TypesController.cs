using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using Catalog.Application.Features.Types.Queries.GetAllTypes;
using Catalog.Application.Features.Types.Queries.GetTypeById;
using Catalog.Application.Features.Types.Commands.CreateType;
using Catalog.Application.Features.Types.Commands.UpdateType;
using Catalog.Application.Features.Types.Commands.DeleteType;

namespace Catalog.Api.Controllers
{
    public class TypesController : BaseApiController
    {
        private readonly IMediator _mediator;

        public TypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<GetAllTypesQueryResponse>> GetAllTypes()
        {
            var query = new GetAllTypesQueryRequest();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetTypeByIdQueryResponse>> GetTypeById(string id)
        {
            var query = new GetTypeByIdQueryRequest(id);
            var result = await _mediator.Send(query);
            if (result == null || result.Type == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateType([FromBody] CreateTypeCommand command)
        {
            var type = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetTypeById), new { id = type.Id }, null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateType(string id, [FromBody] UpdateTypeCommand command)
        {
            if (id != command.Id) return BadRequest("Id mismatch");
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteType(string id)
        {
            var command = new DeleteTypeCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}

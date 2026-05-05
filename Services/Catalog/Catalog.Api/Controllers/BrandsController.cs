using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using Catalog.Application.Features.Brands.Queries.GetAllBrands;
using Catalog.Application.Features.Brands.Queries.GetBrandById;
using Catalog.Application.Features.Brands.Commands.CreateBrand;
using Catalog.Application.Features.Brands.Commands.UpdateBrand;
using Catalog.Application.Features.Brands.Commands.DeleteBrand;

namespace Catalog.Api.Controllers
{
    public class BrandsController : BaseApiController
    {
        private readonly IMediator _mediator;

        public BrandsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<GetAllBarndsQueryResponse>> GetAllBrands()
        {
            var query = new GetAllBarndsQueryRequest();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetBrandByIdQueryResponse>> GetBrandById(string id)
        {
            var query = new GetBrandByIdQueryRequest(id);
            var result = await _mediator.Send(query);
            if (result == null || result.Brand == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateBrand([FromBody] CreateBrandCommand command)
        {
            var brand = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetBrandById), new { id = brand.Id }, null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBrand(string id, [FromBody] UpdateBrandCommand command)
        {
            if (id != command.Id) return BadRequest("Id mismatch");
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBrand(string id)
        {
            var command = new DeleteBrandCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}

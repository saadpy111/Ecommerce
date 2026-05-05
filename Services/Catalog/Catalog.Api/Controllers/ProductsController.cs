using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using Catalog.Application.Features.Products.Queries.GetAllProducts;
using Catalog.Application.Features.Products.Queries.GetProductById;
using Catalog.Application.Features.Products.Queries.GetAllProductsByBrand;
using Catalog.Application.Features.Products.Queries.GetAllProductsByName;
using Catalog.Application.Features.Products.Commands.CreateProduct;
using Catalog.Application.Features.Products.Commands.UpdateProduct;
using Catalog.Application.Features.Products.Commands.DeleteProduct;

namespace Catalog.Api.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<GetAllProductsQueryResponse>> GetAllProducts()
        {
            var query = new GetAllProductsQueryRequest();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetProductByIdQueryResponse>> GetProductById(string id)
        {
            var query = new GetProductByIdQueryRequest(id);
            var result = await _mediator.Send(query);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("brand/{brandName}")]
        public async Task<ActionResult<GetAllProductsByBrandQueryResponse>> GetProductsByBrand(string brandName)
        {
            var query = new GetAllProductsByBrandQueryRequest(brandName);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<GetAllProductsByNameQueryResponse>> GetProductsByName(string name)
        {
            var query = new GetAllProductsByNameQueryRequest(name);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            var product = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(string id, [FromBody] UpdateProductCommand command)
        {
            if (id != command.Id) return BadRequest("Id mismatch");
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(string id)
        {
            var command = new DeleteProductCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}

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
    public class CatalogController : BaseApiController
    {
        private readonly IMediator _mediator;

        public CatalogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/catalog/products
        [HttpGet("products")]
        public async Task<ActionResult<GetAllProductsQueryResponse>> GetAllProducts()
        {
            var query = new GetAllProductsQueryRequest();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET: api/catalog/products/{id}
        [HttpGet("products/{id}")]
        public async Task<ActionResult<GetProductByIdQueryResponse>> GetProductById(string id)
        {
            var query = new GetProductByIdQueryRequest(id);
            var result = await _mediator.Send(query);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // GET: api/catalog/products/brand/{brandName}
        [HttpGet("products/brand/{brandName}")]
        public async Task<ActionResult<GetAllProductsByBrandQueryResponse>> GetProductsByBrand(string brandName)
        {
            var query = new GetAllProductsByBrandQueryRequest(brandName);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET: api/catalog/products/name/{name}
        [HttpGet("products/name/{name}")]
        public async Task<ActionResult<GetAllProductsByNameQueryResponse>> GetProductsByName(string name)
        {
            var query = new GetAllProductsByNameQueryRequest(name);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // POST: api/catalog/products
        [HttpPost("products")]
        public async Task<ActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
              var product =  await _mediator.Send(command);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, null);
        }

        // PUT: api/catalog/products/{id}
        [HttpPut("products/{id}")]
        public async Task<ActionResult> UpdateProduct(string id, [FromBody] UpdateProductCommand command)
        {
            if (id != command.Id) return BadRequest("Id mismatch");
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE: api/catalog/products/{id}
        [HttpDelete("products/{id}")]
        public async Task<ActionResult> DeleteProduct(string id)
        {
            var command = new DeleteProductCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}

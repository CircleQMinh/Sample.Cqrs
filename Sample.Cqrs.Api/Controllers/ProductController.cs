using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Cqrs.Application.Features.Product.DeleteProduct;
using Sample.Cqrs.Application.Features.Product.CreateProduct;
using Sample.Cqrs.Application.Features.Product.UpdateProduct;
using Sample.Cqrs.Application.Features.Product.GetProducts;
using Sample.Cqrs.Application.Abstractions.Mediator;

namespace Sample.Cqrs.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
          CreateProductRequest request)
        {
            var response = await _mediator.Send(request);

            return CreatedAtAction(
               nameof(Create),
               new { id = response.Result!.Id },
               response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            UpdateProductRequest request)
        {

            request.Id = id;

            var response = await _mediator.Send(request);

            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(
                new DeleteProductRequest(id));

            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts(
        [FromQuery] GetProductsRequest query)
        {
            var response = await _mediator.Send(query);

            return Ok(response);
        }

    }
}

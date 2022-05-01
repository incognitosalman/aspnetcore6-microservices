using Catalog.Application.Features.Products.Queries.GetProductsList;
using Catalog.Domain.Models.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ProductResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ProductResponse>>> Get()
        {
            var query = new GetProductsListQuery(1);
            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}

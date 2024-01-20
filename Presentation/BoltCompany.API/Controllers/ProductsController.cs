using BoltCompany.Application.Features.Commands.About.CreateAboutCommand;
using BoltCompany.Application.Features.Commands.About.DeleteAboutCommand;
using BoltCompany.Application.Features.Commands.About.UpdateAboutCommand;
using BoltCompany.Application.Features.Commands.Product.CreateProductCommand;
using BoltCompany.Application.Features.Commands.Product.DeleteProductCommand;
using BoltCompany.Application.Features.Commands.Product.UpdateProductCommand;
using BoltCompany.Application.Features.Queries.About.GetAboutByIdQuery;
using BoltCompany.Application.Features.Queries.About.GetAboutsQuery;
using BoltCompany.Application.Features.Queries.Product.GetProductByIdQuery;
using BoltCompany.Application.Features.Queries.Product.GetProductsQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoltCompany.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseApiController
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _mediator.Send(new GetProductsQueryRequest());
            return CreateActionResultInstance<GetProductsQueryResponse>(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetProductByIdQueryRequest { Id = id });
            return CreateActionResultInstance<GetProductByIdQueryResponse>(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateProductCommandRequest createProduct)
        {
            var result = await _mediator.Send(createProduct);
            return CreateActionResultInstance<CreateProductCommandResponse>(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCommandRequest updateProduct)
        {
            var result = await _mediator.Send(updateProduct);
            return CreateActionResultInstance<UpdateProductCommandResponse>(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteProductCommandRequest deleteProduct)
        {
            var result = await _mediator.Send(deleteProduct);
            return CreateActionResultInstance<DeleteProductCommandResponse>(result);
        }
    }
}

using BoltCompany.Application.Features.Commands.Product.CreateProductCommand;
using BoltCompany.Application.Features.Commands.Product.DeleteProductCommand;
using BoltCompany.Application.Features.Commands.Product.UpdateProductCommand;
using BoltCompany.Application.Features.Commands.ProductImage.CreateProductImageCommand;
using BoltCompany.Application.Features.Commands.ProductImage.DeleteProductImageCommand;
using BoltCompany.Application.Features.Commands.ProductImage.UpdateProductImageCommand;
using BoltCompany.Application.Features.Queries.Product.GetProductByIdQuery;
using BoltCompany.Application.Features.Queries.Product.GetProductsQuery;
using BoltCompany.Application.Features.Queries.ProductImage.GetProductImageByIdQuery;
using BoltCompany.Application.Features.Queries.ProductImage.GetProductImagesQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoltCompany.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : BaseApiController
    {
        private readonly IMediator _mediator;

        public ProductImagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _mediator.Send(new GetProductImagesQueryRequest());
            return CreateActionResultInstance<GetProductImagesQueryResponse>(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetProductImageByIdQueryRequest { Id = id });
            return CreateActionResultInstance<GetProductImageByIdQueryResponse>(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateProductImageCommandRequest createProductImage)
        {
            var result = await _mediator.Send(createProductImage);
            return CreateActionResultInstance<CreateProductImageCommandResponse>(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductImageCommandRequest updateProductImage)
        {
            var result = await _mediator.Send(updateProductImage);
            return CreateActionResultInstance<UpdateProductImageCommandResponse>(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteProductImageCommandRequest deleteProductImage)
        {
            var result = await _mediator.Send(deleteProductImage);
            return CreateActionResultInstance<DeleteProductImageCommandResponse>(result);
        }
    }
}

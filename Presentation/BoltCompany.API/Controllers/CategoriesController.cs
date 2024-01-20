using BoltCompany.Application.Features.Commands.About.CreateAboutCommand;
using BoltCompany.Application.Features.Commands.About.DeleteAboutCommand;
using BoltCompany.Application.Features.Commands.About.UpdateAboutCommand;
using BoltCompany.Application.Features.Commands.Category.CreateCategoryCommand;
using BoltCompany.Application.Features.Commands.Category.DeleteCategoryCommand;
using BoltCompany.Application.Features.Commands.Category.UpdateCategoryCommand;
using BoltCompany.Application.Features.Queries.About.GetAboutByIdQuery;
using BoltCompany.Application.Features.Queries.About.GetAboutsQuery;
using BoltCompany.Application.Features.Queries.Category.GetCategoriesQuery;
using BoltCompany.Application.Features.Queries.Category.GetCategoryByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoltCompany.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class CategoriesController : BaseApiController
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _mediator.Send(new GetCategoriesQueryRequest());
            return CreateActionResultInstance<GetCategoriesQueryResponse>(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetCategoryByIdQueryRequest { Id = id });
            return CreateActionResultInstance<GetCategoryByIdQueryResponse>(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateCategoryCommandRequest createCategory)
        {
            var result = await _mediator.Send(createCategory);
            return CreateActionResultInstance<CreateCategoryCommandResponse>(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryCommandRequest updateCategory)
        {
            var result = await _mediator.Send(updateCategory);
            return CreateActionResultInstance<UpdateCategoryCommandResponse>(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteCategoryCommandRequest deleteCategory)
        {
            var result = await _mediator.Send(deleteCategory);
            return CreateActionResultInstance<DeleteCategoryCommandResponse>(result);
        }
    }
}

using BoltCompany.Application.Features.Commands.PageDetail.CreatePageDetailCommand;
using BoltCompany.Application.Features.Commands.PageDetail.DeletePageDetailCommand;
using BoltCompany.Application.Features.Commands.PageDetail.UpdatePageDetailCommand;
using BoltCompany.Application.Features.Queries.PageDetail.GetPageDetailByIdQuery;
using BoltCompany.Application.Features.Queries.PageDetail.GetPageDetailsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BoltCompany.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageDetailsController : BaseApiController
    {
        private readonly IMediator _mediator;

        public PageDetailsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _mediator.Send(new GetPageDetailsQueryRequest());
            return CreateActionResultInstance<GetPageDetailsQueryResponse>(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetPageDetailByIdQueryRequest { Id = id });
            return CreateActionResultInstance<GetPageDetailByIdQueryResponse>(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreatePageDetailCommandRequest createPageDetail)
        {
            var result = await _mediator.Send(createPageDetail);
            return CreateActionResultInstance<CreatePageDetailCommandResponse>(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatePageDetailCommandRequest updatePageDetail)
        {
            var result = await _mediator.Send(updatePageDetail);
            return CreateActionResultInstance<UpdatePageDetailCommandResponse>(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeletePageDetailCommandRequest deletePageDetail)
        {
            var result = await _mediator.Send(deletePageDetail);
            return CreateActionResultInstance<DeletePageDetailCommandResponse>(result);
        }
    }
}


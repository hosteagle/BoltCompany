using BoltCompany.Application.Features.Commands.ExtraPage.CreateExtraPageCommand;
using BoltCompany.Application.Features.Commands.ExtraPage.DeleteExtraPageCommand;
using BoltCompany.Application.Features.Commands.ExtraPage.UpdateExtraPageCommand;
using BoltCompany.Application.Features.Queries.ExtraPage.GetExtraPageByIdQuery;
using BoltCompany.Application.Features.Queries.ExtraPage.GetExtraPagesQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BoltCompany.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtraPagesController : BaseApiController
    {
        private readonly IMediator _mediator;

        public ExtraPagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _mediator.Send(new GetExtraPagesQueryRequest());
            return CreateActionResultInstance<GetExtraPagesQueryResponse>(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetExtraPageByIdQueryRequest { Id = id });
            return CreateActionResultInstance<GetExtraPageByIdQueryResponse>(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateExtraPageCommandRequest createExtraPage)
        {
            var result = await _mediator.Send(createExtraPage);
            return CreateActionResultInstance<CreateExtraPageCommandResponse>(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateExtraPageCommandRequest updateExtraPage)
        {
            var result = await _mediator.Send(updateExtraPage);
            return CreateActionResultInstance<UpdateExtraPageCommandResponse>(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteExtraPageCommandRequest deleteExtraPage)
        {
            var result = await _mediator.Send(deleteExtraPage);
            return CreateActionResultInstance<DeleteExtraPageCommandResponse>(result);
        }
    }
}
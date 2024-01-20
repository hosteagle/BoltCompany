using BoltCompany.Application.Features.Commands.About.CreateAboutCommand;
using BoltCompany.Application.Features.Commands.About.DeleteAboutCommand;
using BoltCompany.Application.Features.Commands.About.UpdateAboutCommand;
using BoltCompany.Application.Features.Queries.About.GetAboutByIdQuery;
using BoltCompany.Application.Features.Queries.About.GetAboutsQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoltCompany.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class AboutsController : BaseApiController
    {
        private readonly IMediator _mediator;

        public AboutsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _mediator.Send(new GetAboutsQueryRequest());
            return CreateActionResultInstance<GetAboutsQueryResponse>(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetAboutByIdQueryRequest { Id = id });
            return CreateActionResultInstance<GetAboutByIdQueryResponse>(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateAboutCommandRequest createAbout)
        {
            var result = await _mediator.Send(createAbout);
            return CreateActionResultInstance<CreateAboutCommandResponse>(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAboutCommandRequest updateAbout)
        {
            var result = await _mediator.Send(updateAbout);
            return CreateActionResultInstance<UpdateAboutCommandResponse>(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteAboutCommandRequest deleteAbout)
        {
            var result = await _mediator.Send(deleteAbout);
            return CreateActionResultInstance<DeleteAboutCommandResponse>(result);
        }
    }
}

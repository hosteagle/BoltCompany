using BoltCompany.Application.Features.Commands.Logo.CreateLogoCommand;
using BoltCompany.Application.Features.Commands.Logo.DeleteLogoCommand;
using BoltCompany.Application.Features.Commands.Logo.UpdateLogoCommand;
using BoltCompany.Application.Features.Queries.Logo.GetLogoByIdQuery;
using BoltCompany.Application.Features.Queries.Logo.GetLogosQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoltCompany.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogosController : BaseApiController
    {
        private readonly IMediator _mediator;

        public LogosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _mediator.Send(new GetLogosQueryRequest());
            return CreateActionResultInstance<GetLogosQueryResponse>(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetLogoByIdQueryRequest { Id = id });
            return CreateActionResultInstance<GetLogoByIdQueryResponse>(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateLogoCommandRequest createLogo)
        {
            var result = await _mediator.Send(createLogo);
            return CreateActionResultInstance<CreateLogoCommandResponse>(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateLogoCommandRequest updateLogo)
        {
            var result = await _mediator.Send(updateLogo);
            return CreateActionResultInstance<UpdateLogoCommandResponse>(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteLogoCommandRequest deleteLogo)
        {
            var result = await _mediator.Send(deleteLogo);
            return CreateActionResultInstance<DeleteLogoCommandResponse>(result);
        }
    }
}

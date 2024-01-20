using BoltCompany.Application.Features.Commands.About.CreateAboutCommand;
using BoltCompany.Application.Features.Commands.AppUser.CreateUserCommand;
using BoltCompany.Application.Features.Commands.AppUser.LoginUserCommand;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoltCompany.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseApiController
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateUserCommandRequest createUser)
        {
            var result = await _mediator.Send(createUser);
            return CreateActionResultInstance<CreateUserCommandResponse>(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginUserCommandRequest loginUser)
        {
            var result = await _mediator.Send(loginUser);
            return CreateActionResultInstance<LoginUserCommandResponse>(result);
        }
    }
}

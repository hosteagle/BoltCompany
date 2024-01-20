using BoltCompany.Application.Abstractions.Token;
using BoltCompany.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace BoltCompany.Application.Features.Commands.AppUser.LoginUserCommand
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
        private readonly SignInManager<Domain.Entities.Identity.AppUser> _signInManager;
        private readonly ITokenHandler _tokenHandler;

        public LoginUserCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager, SignInManager<Domain.Entities.Identity.AppUser> signInManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Identity.AppUser user = await _userManager.FindByNameAsync(request.UsernameOrEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(request.UsernameOrEmail);

            if (user == null)
                return new LoginUserCommandResponse { Message = "Kullanıcı Adı veya şifre hatalı", StatusCode = HttpStatusCode.NotFound };

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, true);
            if (result.Succeeded)
            {
                Token token = _tokenHandler.CreateAccessToken(15);
                return new LoginUserCommandResponse { Token = token, Message = "Kullanıcı girişi başarılı.", StatusCode = HttpStatusCode.OK };
            } else
            {
                return new LoginUserCommandResponse { Message = "Kullanıcı girişi yapılamadı. Lütfen tekrar deneyiniz.", StatusCode = HttpStatusCode.BadRequest };

            }
        }
    }
}

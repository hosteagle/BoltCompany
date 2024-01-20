using BoltCompany.Application.DTOs;
using BoltCompany.Application.Features.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltCompany.Application.Features.Commands.AppUser.LoginUserCommand
{
    public class LoginUserCommandResponse : BaseResponse
    {
        public Token Token { get; set; }
    }
}

using BoltCompany.Application.Features.Base;
using Microsoft.AspNetCore.Mvc;

namespace BoltCompany.API.Controllers
{
    public class BaseApiController : ControllerBase
    {
        public IActionResult CreateActionResultInstance<T>(BaseResponse response) where T : BaseResponse
        {
            return new ObjectResult(response)
            {
                StatusCode = (int?)response.StatusCode,
            };
        }
    }
}

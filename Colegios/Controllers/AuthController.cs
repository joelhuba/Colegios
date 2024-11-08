using Colegio.Helpers;
using Colegios.Core.DTOs;
using Colegios.Core.Interfaces;
using Colegios.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Colegio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthBLL authBLL,IlogService logService) : ControllerBase
    {
        private readonly IAuthBLL _authBLL = authBLL;
        private readonly IlogService _logService = logService;
        [HttpPost("/Auth")]
        public async Task<IActionResult> Auth(AuthDTO auth)
        => await HandleResponses.HandleResponse(()=>_authBLL.Auth(auth),_logService,MethodBase.GetCurrentMethod().Name);
    }
}

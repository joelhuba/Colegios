using Colegio.Helpers;
using Colegios.Core.DTOs;
using Colegios.Core.DTOs.Commons;
using Colegios.Core.Interfaces.BLL;
using Colegios.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Colegios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RolesController(IRolesBLL rolesBLL,IlogService logService) : ControllerBase
    {
        private readonly IRolesBLL _rolesBLL = rolesBLL;
        private readonly IlogService _logService = logService;

        [HttpPost("/CreateRol")]
        public async Task<IActionResult> CreateRol(RolesDTO rolesDTO)
        => await HandleResponses.HandleResponse(() => _rolesBLL.CreateRol(rolesDTO), _logService, MethodBase.GetCurrentMethod().Name);

        [HttpPut("/UpdateRol")]
        public async Task<IActionResult> UpdateRol(RolesDTO rolesDTO)
        => await HandleResponses.HandleResponse(() => _rolesBLL.UpdateRol(rolesDTO), _logService, MethodBase.GetCurrentMethod().Name);
       
        [HttpDelete("/DeleteRol")]
        public async Task<IActionResult> DeleteRol(int idRol)
        => await HandleResponses.HandleResponse(() => _rolesBLL.DeleteRol(idRol), _logService, MethodBase.GetCurrentMethod().Name);

        [HttpGet("/GetListRol")]
        public async Task<IActionResult> GetListRol([FromQuery]PaginatorDTO paginatorDTO, string? description)
        => await HandleResponses.HandleResponse(() => _rolesBLL.GetListRol(paginatorDTO, description), _logService, MethodBase.GetCurrentMethod().Name);
    }
}

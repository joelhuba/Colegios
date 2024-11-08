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
    public class UserController(IUserBLL userBLL,IlogService logService) : ControllerBase
    {
        private readonly IUserBLL _userBLL = userBLL;
        private readonly IlogService _logService = logService;
        [HttpPost("/CreateUser")]
        public async Task<IActionResult> CreateUser(UserDTO userDTO)
        => await HandleResponses.HandleResponse(()=> _userBLL.CreateUser(userDTO),_logService,MethodBase.GetCurrentMethod().Name);

        [HttpPut("/UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserDTO userDTO)
        => await HandleResponses.HandleResponse(() => _userBLL.UpdateUser(userDTO), _logService, MethodBase.GetCurrentMethod().Name);

        [HttpDelete("/DeleteUser")]
        public async Task<IActionResult> DeleteUser(int idUser)
        => await HandleResponses.HandleResponse(() => _userBLL.DeleteUser(idUser), _logService, MethodBase.GetCurrentMethod().Name);

        [HttpGet("/GetListUser")]
        public async Task<IActionResult> GetListUser([FromQuery]PaginatorDTO paginatorDTO, bool? status, string? name, string? description)
        => await HandleResponses.HandleResponse(() => _userBLL.GetListUser(paginatorDTO, status, name, description), _logService, MethodBase.GetCurrentMethod().Name);
    }
}

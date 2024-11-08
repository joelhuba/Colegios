using Colegios.Core.DTOs;
using Colegios.Core.DTOs.Commons;
using Colegios.Core.Interfaces;
using Colegios.Core.Interfaces.Repository;
using Colegios.Core.Interfaces.Services;
using Colegios.Infrastructure.Helper;
using Microsoft.Extensions.Configuration;

namespace Colegios.Infrastructure.BLL
{
    public class AuthBLL(IAuthUserRepository authUserRepository,IlogService logService,IConfiguration configuration) : IAuthBLL
    {
        private readonly IAuthUserRepository _authUserRepository = authUserRepository;
        private readonly IlogService _logService = logService;
        private readonly IConfiguration _configuration = configuration;
        public async Task<ResponseDTO> Auth(AuthDTO auth)
        {
            ResponseDTO response = new ResponseDTO { IsSuccess = false };
            try
            {
                response = await _authUserRepository.Auth(auth.UserName);
                AuthUserDTO user = (AuthUserDTO)response.Data;
                if (user.IdUser == null)
                {
                    response.IsSuccess = false;
                    response.Message = "El usuario no existe";
                    response.Data = null;
                    return response;
                }
                byte[] saltPass = Convert.FromBase64String(user.PasswordSalt);
                if (!user.Status)
                {
                    response.IsSuccess = false;
                    response.Message = "El usuario esta inactivo";
                    response.Data = null;
                    return response;
                }
                if (PasswordHashHelper.VerifyPassword(auth.Password, user.Password, saltPass))
                {
                    response.IsSuccess = true;
                    response.Message = "Usuario autenticado con éxito";
                    response.Data = await GenerateTokenHelper.GenerateTokenAsync(user, _configuration["TokenSettings:SecretToken"], Convert.ToInt32(_configuration["TokenSettings:TokenExpirationHours"]), _logService);
                    return response;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Credenciales inválidas";
                    response.Data = null;
                    return response;
                }
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
            
        }
    }
}

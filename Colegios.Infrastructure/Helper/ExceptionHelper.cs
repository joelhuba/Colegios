using Colegios.Core.DTOs.Commons;
using Colegios.Core.Interfaces.Services;

namespace Colegios.Infrastructure.Helper
{
    public static class ExceptionHelper
    {
        public static ResponseDTO HandleException(IlogService logService, string methodName, Exception ex)
        {
            logService.message($"Se ha producido un error al ejecutar BLL: {methodName}: {ex.Message}");
            var response = new ResponseDTO
            {
                IsSuccess = false,
                Message = ex.ToString()
            };
            return response;
        }
    }
}

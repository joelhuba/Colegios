using Colegios.Core.DTOs;
using Colegios.Core.DTOs.Commons;
using Colegios.Core.Interfaces.Repository;
using Colegios.Core.Interfaces.Services;
using Colegios.Infrastructure.Helper;


namespace Colegios.Infrastructure.Repository
{
    public class AuthRepository(IExecuteStoredProcedureService executeStoredProcedure) : IAuthUserRepository
    {
        private readonly IExecuteStoredProcedureService _executeStoredProcedureService = executeStoredProcedure;
        public async Task<ResponseDTO> Auth(string username)
        {
            object obj = new
            {
                Username = username
            };
            return await _executeStoredProcedureService.ExecuteSingleObjectStoredProcedure("Auth", obj, MapToObjHelper.MapToObj<AuthUserDTO>);
        }
    }
}

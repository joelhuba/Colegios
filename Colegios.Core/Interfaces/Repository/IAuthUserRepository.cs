using Colegios.Core.DTOs.Commons;

namespace Colegios.Core.Interfaces.Repository
{
    public interface IAuthUserRepository
    {
        public Task<ResponseDTO> Auth(string username);
    }
}

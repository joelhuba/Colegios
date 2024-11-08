using Colegios.Core.DTOs;
using Colegios.Core.DTOs.Commons;

namespace Colegios.Core.Interfaces
{
    public interface IAuthBLL
    {
        public Task<ResponseDTO> Auth(AuthDTO auth);
    }
}

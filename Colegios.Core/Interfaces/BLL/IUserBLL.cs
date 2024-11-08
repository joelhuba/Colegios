using Colegios.Core.DTOs;
using Colegios.Core.DTOs.Commons;

namespace Colegios.Core.Interfaces.BLL
{
    public interface IUserBLL
    {
        Task<ResponseDTO> CreateUser(UserDTO userDTO);
        Task<ResponseDTO> UpdateUser(UserDTO userDTO);
        Task<ResponseDTO> DeleteUser(int idUser);
        Task<ResponseDTO> GetListUser(PaginatorDTO paginatorDTO, bool? status, string? name, string? description);
    }
}

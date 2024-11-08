using Colegios.Core.DTOs.Commons;
using Colegios.Core.DTOs;

namespace Colegios.Core.Interfaces.BLL
{
    public interface IRolesBLL
    {
        Task<ResponseDTO> CreateRol(RolesDTO rolesDTO);
        Task<ResponseDTO> UpdateRol(RolesDTO rolesDTO);
        Task<ResponseDTO> DeleteRol(int idRol);
        Task<ResponseDTO> GetListRol(PaginatorDTO paginatorDTO, string? description);
    }
}

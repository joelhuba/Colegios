using Colegios.Core.DTOs;
using Colegios.Core.DTOs.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegios.Core.Interfaces.Repository
{
    public interface IRolesRepository
    {
        Task<ResponseDTO> CreateRol(RolesDTO rolesDTO);
        Task<ResponseDTO> UpdateRol(RolesDTO rolesDTO);
        Task<ResponseDTO> DeleteRol(int idRol);
        Task<ResponseDTO> GetListRol(PaginatorDTO paginatorDTO,string? description);

    }
}

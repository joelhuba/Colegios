using Colegios.Core.DTOs;
using Colegios.Core.DTOs.Commons;
using Colegios.Core.Interfaces.Repository;
using Colegios.Core.Interfaces.Services;
using Colegios.Infrastructure.Helper;

namespace Colegios.Infrastructure.Repository
{
    public class RolesRepository(IExecuteStoredProcedureService executeStoredProcedureService) : IRolesRepository
    {
        private readonly IExecuteStoredProcedureService _executeStoredProcedureService = executeStoredProcedureService;
        public async Task<ResponseDTO> CreateRol(RolesDTO rolesDTO)
        {
            object obj = new
            {
                rolesDTO.Description
            };
            return await _executeStoredProcedureService.ExecuteStoredProcedure("CreateRol",obj);
        }

        public async Task<ResponseDTO> DeleteRol(int idRol)
        {
            object obj = new
            {
                IdRol=idRol
            };
            return await _executeStoredProcedureService.ExecuteStoredProcedure("DeleteRol", obj);
        }

        public async Task<ResponseDTO> GetListRol(PaginatorDTO paginatorDTO, string? description)
        {
            object obj = new
            {
                paginatorDTO.PageIndex,
                paginatorDTO.PageSize,
                Description =description
            };
            return await _executeStoredProcedureService.ExecuteTableStoredProcedure("GetListRoles", obj, MapToListHelper.MapToList<RolesDTO>);

        }

        public async Task<ResponseDTO> UpdateRol(RolesDTO rolesDTO)
        {
            object obj = new
            {
                rolesDTO.IdRol,
                rolesDTO.Description
            };
            return await _executeStoredProcedureService.ExecuteStoredProcedure("UpdateRol", obj);
        }
    }
}

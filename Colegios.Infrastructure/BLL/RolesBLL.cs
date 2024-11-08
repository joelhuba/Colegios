using Colegios.Core.DTOs;
using Colegios.Core.DTOs.Commons;
using Colegios.Core.Interfaces.BLL;
using Colegios.Core.Interfaces.Repository;
using Colegios.Core.Interfaces.Services;
using Colegios.Infrastructure.Helper;
using System.Reflection;

namespace Colegios.Infrastructure.BLL
{
    public class RolesBLL(IlogService logService,IRolesRepository rolesRepository) : IRolesBLL
    {
        private readonly IlogService _logService = logService;
        private readonly IRolesRepository _rolesRepository = rolesRepository;
        public async Task<ResponseDTO> CreateRol(RolesDTO rolesDTO)
        {
            try
            {
                return await _rolesRepository.CreateRol(rolesDTO);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService,MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async Task<ResponseDTO> DeleteRol(int idRol)
        {
            try
            {
                return await _rolesRepository.DeleteRol(idRol);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async Task<ResponseDTO> GetListRol(PaginatorDTO paginatorDTO, string? description)
        {
            try
            {
                return await _rolesRepository.GetListRol(paginatorDTO, description);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async Task<ResponseDTO> UpdateRol(RolesDTO rolesDTO)
        {
            try
            {
                return await _rolesRepository.UpdateRol(rolesDTO);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }
    }
}

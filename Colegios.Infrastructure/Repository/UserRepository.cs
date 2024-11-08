using Colegios.Core.DTOs;
using Colegios.Core.DTOs.Commons;
using Colegios.Core.Interfaces.Repository;
using Colegios.Core.Interfaces.Services;
using Colegios.Infrastructure.Helper;

namespace Colegios.Infrastructure.Repository
{
    public class UserRepository(IExecuteStoredProcedureService executeStoredProcedureService) : IUserRepository
    {
        private readonly IExecuteStoredProcedureService _executeStoredProcedureService = executeStoredProcedureService;
        public async Task<ResponseDTO> CreateUser(UserDTO userDTO)
        {
            object obj = new
            {
                userDTO.Names,
                userDTO.LastNames,
                userDTO.birthday,
                userDTO.PhoneNumber,
                userDTO.IdRol,
                userDTO.EntryDate,
                userDTO.Status,
                userDTO.UserName,
                userDTO.Password,
                userDTO.PasswordSalt
            };
            return await _executeStoredProcedureService.ExecuteStoredProcedure("CreateUser", obj);
        }

        public async Task<ResponseDTO> DeleteUser(int idUser)
        {
            object obj = new
            {
                IdUser = idUser
            };
            return await _executeStoredProcedureService.ExecuteStoredProcedure("DeleteUser", obj);
        }

        public async Task<ResponseDTO> GetListUser(PaginatorDTO paginatorDTO, bool? status, string? name, string? description)
        {

            object obj = new
            {
                paginatorDTO.PageIndex,
                paginatorDTO.PageSize,
                Status = status,
                Name = name,
                Description = description
            };
            return await _executeStoredProcedureService.ExecuteTableStoredProcedure("GetListUsers", obj, MapToListHelper.MapToList<ResponseUserDTO>);
        }

        public async Task<ResponseDTO> UpdateUser(UserDTO userDTO)
        {
            object obj = new
            {
                userDTO.IdUser,
                userDTO.Names,
                userDTO.LastNames,
                userDTO.birthday,
                userDTO.PhoneNumber,
                userDTO.IdRol,
                userDTO.EntryDate,
                userDTO.Status,
                userDTO.UserName
            };
            return await _executeStoredProcedureService.ExecuteStoredProcedure("UpdateUser", obj);
        }
    }
}

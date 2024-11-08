using Colegios.Core.DTOs;
using Colegios.Core.DTOs.Commons;
using Colegios.Core.Interfaces.BLL;
using Colegios.Core.Interfaces.Repository;
using Colegios.Core.Interfaces.Services;
using Colegios.Infrastructure.Helper;
using System.Reflection;

namespace Colegios.Infrastructure.BLL
{
    public class UserBLL(IlogService logService,IUserRepository userRepository) : IUserBLL
    {
        private readonly IUserRepository _userRepositoy = userRepository;
        private readonly IlogService _logService = logService;
        public async Task<ResponseDTO> CreateUser(UserDTO userDTO)
        {
            try
            {
                userDTO.birthday = new DateTime(userDTO.birthday.Year, userDTO.birthday.Month, userDTO.birthday.Day);
                userDTO.EntryDate = new DateTime(userDTO.birthday.Year, userDTO.birthday.Month, userDTO.birthday.Day);
                var (passwordHased, salt) = PasswordHashHelper.HashPassword(userDTO.Password);
                userDTO.Password = passwordHased;
                userDTO.PasswordSalt = salt;
                return await _userRepositoy.CreateUser(userDTO);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name,ex);
            }
        }

        public async  Task<ResponseDTO> DeleteUser(int idUser)
        {
            try
            {
                return await _userRepositoy.DeleteUser(idUser);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async Task<ResponseDTO> GetListUser(PaginatorDTO paginatorDTO, bool? status, string? name, string? description)
        {
            try
            {
                return await _userRepositoy.GetListUser(paginatorDTO, status, name, description);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async Task<ResponseDTO> UpdateUser(UserDTO userDTO)
        {
            try
            {
                return await _userRepositoy.UpdateUser(userDTO);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }
    }
}

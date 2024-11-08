﻿using Colegios.Core.DTOs;
using Colegios.Core.Interfaces.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Colegios.Infrastructure.Helper
{

    public static class GenerateTokenHelper
    {
        
        public static async Task<string> GenerateTokenAsync(AuthUserDTO user, string signature, int hours, IlogService logService)
        {
            if (string.IsNullOrWhiteSpace(user.UserName) || string.IsNullOrWhiteSpace(signature))
            {
                string response = "El nombre de usuario y la firma no pueden estar vacíos.";
                logService.message(response);
                throw new ArgumentException(response);
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                new Claim("UserName", user.UserName),
                new Claim("IdUser", user.IdUser.ToString()),
                new Claim("Names",user.Names),
                new Claim("LastNames",user.LastNames),
                new Claim("IdRol",user.IdRol.ToString()),
                new Claim("Status",user.Status.ToString()),
            }),
                Expires = DateTime.UtcNow.AddHours(hours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            try
            {
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                string response = "Error al crear el token JWT. " + ex;
                logService.message(response);
                throw new InvalidOperationException(response);
            }
        }

    }
}

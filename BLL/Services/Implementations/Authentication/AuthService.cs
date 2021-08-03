using BLL.Services.Dtos.Authentication;
using BLL.Services.Interfaces.Authentication;
using DAL;
using DAL.Models.Authentication;
using DAL.Repositories.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Implementations.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepo _authRepo;

        public AuthService(IAuthRepo authRepo)
        {
            _authRepo = authRepo;
        }

        public async Task<AuthResultSet> RegistrationAsync(AuthUserRegistrationCreateDto model)
        {
            AuthResultSet result = new();
            
            AuthUser authUser = new AuthUser
            {
                UserName = model.UserName,
                Email = model.Email
            };

            var resultFromDb = await _authRepo.RegisterAsync(authUser, model.Password);

            if (resultFromDb.Success)
            {
                var user = new AuthUserRegistrationReadDto
                {
                    UserName = model.UserName,
                    Email = model.Email
                };
                result.Token = "Token Generate Later";
                result.Success = true;
            } else
            {
                result.Errors = resultFromDb.Errors;
            }

            return result;
        }

        //private Task<string> GenerateJwtTokenAsync(AuthUser user)
        //{

        //    throw new NotImplementedException();
        //}



    }
}

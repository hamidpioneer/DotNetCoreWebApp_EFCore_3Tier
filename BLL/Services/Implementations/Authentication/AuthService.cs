using BLL.AppConfiguration;
using BLL.Services.Dtos.Authentication;
using BLL.Services.Interfaces.Authentication;
using DAL;
using DAL.Models.Authentication;
using DAL.Repositories.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Implementations.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepo _authRepo;
        private readonly JwtConfig _jwtConfig;

        public AuthService(IAuthRepo authRepo, IOptionsMonitor<JwtConfig> jwtConfig)
        {
            _authRepo = authRepo;
            _jwtConfig = jwtConfig.CurrentValue;
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

                var token = GenerateJwtToken(authUser);

                result.Token = token;
                result.Success = true;
            } else
            {
                result.Errors = resultFromDb.Errors;
            }

            return result;
        }


        public async Task<AuthResultSet> LoginAsync(AuthUserLoginCreateDto model)
        {
            AuthResultSet result = new();

            AuthUser authUser = new AuthUser
            {
                Email = model.Email
            };

            var authenticUser = await _authRepo.LoginAsync(authUser, model.Password);

            if (authenticUser.Success)
            {
                var token = GenerateJwtToken(authUser);

                result.Token = token;
                result.Success = true;
            }
            else
            {
                result.Errors = authenticUser.Errors;
            }

            return result;

        }


        private string GenerateJwtToken(AuthUser user)
        {
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }



    }
}

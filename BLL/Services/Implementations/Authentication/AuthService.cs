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
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var resultFromDb = await _authRepo.RegisterAsync(authUser, model.Password);

            if (resultFromDb.Success)
            {
                var token = await GenerateJwtToken(resultFromDb.Data);

                result.Token = token;
                result.Success = true;
            } else
            {
                result.Errors = resultFromDb.Errors;
            }

            return result;
        }

        public async Task<AuthResultSet> RegistrationAdminAsync(AuthUserRegistrationCreateDto model)
        {
            AuthResultSet result = new();

            AuthUser authUser = new AuthUser
            {
                UserName = model.UserName,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var resultFromDb = await _authRepo.RegisterAdminAsync(authUser, model.Password);

            if (resultFromDb.Success)
            {
                var token = await GenerateJwtToken(resultFromDb.Data);

                result.Token = token;
                result.Success = true;
            }
            else
            {
                result.Errors = resultFromDb.Errors;
            }

            return result;
        }


        public async Task<AuthResultSet> RegistrationManagerAsync(AuthUserRegistrationCreateDto model)
        {
            AuthResultSet result = new();

            AuthUser authUser = new AuthUser
            {
                UserName = model.UserName,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var resultFromDb = await _authRepo.RegisterManagerAsync(authUser, model.Password);

            if (resultFromDb.Success)
            {
                var token = await GenerateJwtToken(resultFromDb.Data);

                result.Token = token;
                result.Success = true;
            }
            else
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
                var token = await GenerateJwtToken(authenticUser.Data);

                result.Token = token;
                result.Success = true;
            }
            else
            {
                result.Errors = authenticUser.Errors;
            }

            return result;

        }


        private async Task<string> GenerateJwtToken(AuthUser user)
        {
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            var jwtTokenHandler = new JwtSecurityTokenHandler();

            // process auth claims
            var userRoles = await GetUserClaimsAsync(user);
            List<Claim> authClaims = new()
            {
                new Claim("Id", user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };            
            foreach(var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            //


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _jwtConfig.ValidAudience,
                Issuer = _jwtConfig.ValidIssuer,
                Subject = new ClaimsIdentity(authClaims),
                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }

        private async Task<IList<string>> GetUserClaimsAsync(AuthUser user)
        {
            var userClaims = await _authRepo.GetUserRolesAsync(user);

            return userClaims;
        }


    }
}

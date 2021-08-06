using DAL.DatabaseContext.Authentication;
using DAL.Models.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Authentication
{
    public class AuthRepo : IAuthRepo
    {
        private readonly UserManager<AuthUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthRepo(UserManager<AuthUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<AuthDbResponse<AuthUser>> RegisterAsync(AuthUser newUserToCreate, string password)
        {
            AuthDbResponse<AuthUser> result = new();

            try
            {
                var userExist = await _userManager.FindByNameAsync(newUserToCreate.UserName);
                if(userExist != null)
                {
                    result.Errors.Add("User already exist");
                    return result;
                }

                var isCreated = await _userManager.CreateAsync(newUserToCreate, password);
                if (isCreated.Succeeded)
                {
                    // Role
                    if (!await _roleManager.RoleExistsAsync(AuthUserRoles.User))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(AuthUserRoles.User));
                    }

                    var userRoles = new List<string> { AuthUserRoles.User };

                    var addRoles = await _userManager.AddToRolesAsync(newUserToCreate, userRoles);
                    //

                    result.Data = newUserToCreate;
                    result.Success = true;
                } else
                {
                    result.Errors = isCreated.Errors.Select(err => $"{err.Description} - {err.Code}").ToList();
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }


        public async Task<AuthDbResponse<AuthUser>> RegisterAdminAsync(AuthUser newUserToCreate, string password)
        {
            AuthDbResponse<AuthUser> result = new();

            try
            {
                var userExist = await _userManager.FindByNameAsync(newUserToCreate.UserName);
                if (userExist != null)
                {
                    result.Errors.Add("User already exist");
                    return result;
                }

                var isCreated = await _userManager.CreateAsync(newUserToCreate, password);
                if (isCreated.Succeeded)
                {
                    // Role
                    if (!await _roleManager.RoleExistsAsync(AuthUserRoles.Admin))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(AuthUserRoles.Admin));
                    }
                    if (!await _roleManager.RoleExistsAsync(AuthUserRoles.Manager))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(AuthUserRoles.Manager));
                    }
                    if (!await _roleManager.RoleExistsAsync(AuthUserRoles.User))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(AuthUserRoles.User));
                    }

                    var userRoles = new List<string> { AuthUserRoles.Admin, AuthUserRoles.Manager, AuthUserRoles.User };

                    var addRoles = await _userManager.AddToRolesAsync(newUserToCreate, userRoles);
                    //

                    result.Data = newUserToCreate;
                    result.Success = true;
                }
                else
                {
                    result.Errors = isCreated.Errors.Select(err => $"{err.Description} - {err.Code}").ToList();
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        
        public async Task<AuthDbResponse<AuthUser>> RegisterManagerAsync(AuthUser newUserToCreate, string password)
        {
            AuthDbResponse<AuthUser> result = new();

            try
            {
                var userExist = await _userManager.FindByNameAsync(newUserToCreate.UserName);
                if (userExist != null)
                {
                    result.Errors.Add("User already exist");
                    return result;
                }

                var isCreated = await _userManager.CreateAsync(newUserToCreate, password);
                if (isCreated.Succeeded)
                {
                    // Role
                    if (!await _roleManager.RoleExistsAsync(AuthUserRoles.Manager))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(AuthUserRoles.Manager));
                    }
                    if (!await _roleManager.RoleExistsAsync(AuthUserRoles.User))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(AuthUserRoles.User));
                    }

                    var userRoles = new List<string> { AuthUserRoles.Manager, AuthUserRoles.User };

                    var addRoles = await _userManager.AddToRolesAsync(newUserToCreate, userRoles);
                    //

                    result.Data = newUserToCreate;
                    result.Success = true;
                }
                else
                {
                    result.Errors = isCreated.Errors.Select(err => $"{err.Description} - {err.Code}").ToList();
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }


        public async Task<AuthDbResponse<AuthUser>> LoginAsync(AuthUser userForLogin, string password)
        {
            AuthDbResponse<AuthUser> result = new();

            try
            {
                var existingUser = await _userManager.FindByEmailAsync(userForLogin.Email);
                if(existingUser == null)
                {
                    result.Errors.Add("Please, try with valid Username");
                    return result;
                }

                var isAuthenticateUser = await _userManager.CheckPasswordAsync(existingUser, password);
                if (isAuthenticateUser)
                {
                    result.Data = existingUser;
                    result.Success = true;
                } else
                {
                    result.Errors.Add("Please, try with correct password");
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }


        public async Task<IList<string>> GetUserRolesAsync(AuthUser user)
        {
            IList<string> userRoles = null;

            try
            {
                userRoles = await _userManager.GetRolesAsync(user);

                return userRoles;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

using BLL.Services.Dtos.Authentication;
using DAL;
using DAL.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces.Authentication
{
    public interface IAuthService
    {
        Task<AuthResultSet> RegistrationAsync(AuthUserRegistrationCreateDto model);
        Task<AuthResultSet> RegistrationAdminAsync(AuthUserRegistrationCreateDto model);
        Task<AuthResultSet> RegistrationManagerAsync(AuthUserRegistrationCreateDto model);
        Task<AuthResultSet> LoginAsync(AuthUserLoginCreateDto model);
    }
}

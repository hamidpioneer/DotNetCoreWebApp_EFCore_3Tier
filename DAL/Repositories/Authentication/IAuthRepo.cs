using DAL.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Authentication
{
    public interface IAuthRepo
    {
        Task<AuthDbResponse<AuthUser>> RegisterAsync(AuthUser newUserToCreate, string password);
        Task<AuthDbResponse<AuthUser>> LoginAsync(AuthUser userForLogin, string password);

        Task<IList<string>> GetUserRolesAsync(AuthUser user);
    }
}

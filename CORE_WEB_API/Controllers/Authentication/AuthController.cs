using BLL.Services.Dtos.Authentication;
using BLL.Services.Interfaces.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE_WEB_API.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        

        [HttpPost]
        public async Task<IActionResult> RegisterAsync([FromBody] AuthUserRegistrationCreateDto userToCreate)
        {
            try
            {
                AuthResultSet result = await _authService.RegistrationAsync(userToCreate);
                if (result != null)
                {
                    return Ok(result);
                }
                return BadRequest("Try again later. Bad Request");
            }
            catch (Exception exception)
            {
                throw new Exception("ERROR: ", exception);
            }
        }
    }
}

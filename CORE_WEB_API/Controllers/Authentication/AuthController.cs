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
        

        [Route("Register")]
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

        [Route("RegisterAdmin")]
        [HttpPost]
        public async Task<IActionResult> RegisterAdminAsync([FromBody] AuthUserRegistrationCreateDto userToCreate)
        {
            try
            {
                AuthResultSet result = await _authService.RegistrationAdminAsync(userToCreate);
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


        [Route("RegisterManager")]
        [HttpPost]
        public async Task<IActionResult> RegisterManagerAsync([FromBody] AuthUserRegistrationCreateDto userToCreate)
        {
            try
            {
                AuthResultSet result = await _authService.RegistrationManagerAsync(userToCreate);
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


        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] AuthUserLoginCreateDto model)
        {
            try
            {
                AuthResultSet result = await _authService.LoginAsync(model);
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

using BLL.Services.Dtos;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantService _actionService;

        public ApplicantController(IApplicantService actionService)
        {
            _actionService = actionService;
        }

        public IActionResult CreateApplicant(ApplicantCreateDto obj)
        {
            try
            {
                var result = _actionService.InsertData(obj);
                if(result != null)
                {
                    return Ok(result);
                }
                return BadRequest("Try again later. Bad Request from Controller");
            }
            catch (Exception exception)
            {
                throw new Exception("ERROR: Controller - ApplicantController - CreateApplicant() - Failed", exception);
            }
        }
    }
}

using BLL.Services.Dtos;
using BLL.Services.Interfaces;
using DAL.Models;
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
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }


        [HttpPost("[Action]")]
        public async Task<IActionResult> CreateApplicationWithApplicant(ApplicantApplicationCreateDto obj)
        {
            try
            {
                var result = await _applicationService.AddApplicationWithApplicantAsync(obj.applicantCreateDto, obj.applicationCreateDto);
                if(result != null)
                {
                    return Ok(result);
                }
                return BadRequest("Try again later. Bad Request from ApplicationController");
            }
            catch (Exception exception)
            {
                throw new Exception("ERROR: Controller - ApplicationController - CreateApplicationWithApplicant() - Failed", exception);
            }
        }
        
        [HttpGet("[Action]")]
        public async Task<IActionResult> GetAllApplications()
        {
            try
            {
                var result = await _applicationService.GetAllApplicationsAsync();
                if(result != null)
                {
                    return Ok(result);
                }
                return BadRequest("Try again later. Bad Request from ApplicationController");
            }
            catch (Exception exception)
            {
                throw new Exception("ERROR: Controller - ApplicationController - GetAllApplications() - Failed", exception);
            }
        }
    }
}

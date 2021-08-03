using BLL.Services.Dtos;
using BLL.Services.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
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
    public class SampleGenericController : ControllerBase
    {
        private readonly ICrudService _crudService;

        public SampleGenericController(ICrudService crudService)
        {
            _crudService = crudService;
        }



        [Authorize]
        [HttpGet]
        public IActionResult GetAllSamples()
        {
            try
            {
                var result = _crudService.GetAllData();
                return Ok(result);
            }
            catch (Exception exception)
            {

                throw new Exception("ERROR: CoreAPI - SampleGenericController - GetAllSamples() - Failed", exception);
            }
        }

    }
}

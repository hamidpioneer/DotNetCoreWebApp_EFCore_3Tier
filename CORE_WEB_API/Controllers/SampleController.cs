using BLL.Services.Dtos;
using BLL.Services.Implementations;
using BLL.Services.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace CORE_WEB_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SampleController : ControllerBase
    {
        private readonly Sample_Service _sample_Service;
        private readonly ILogger<SampleController> _logger;

        public SampleController(Sample_Service sample_Service, ILogger<SampleController> logger)
        {
            _sample_Service = sample_Service;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var data = _sample_Service.GetAllSamples();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest($"Sorry! Exception: {ex.Message}");
            }

        }
    }
}

using BLL.Services.Dtos;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IApplicationService
    {
        //Task<ResultSet<Application>> GetApplicationById(int id);
        Task<ResultSet<Application>> AddApplicationWithApplicantAsync(ApplicantCreateDto applicantCreateDto, ApplicationCreateDto applicationCreateDto);
        Task<ResultSet<IList<Application>>> GetAllApplicationsAsync();
    }
}

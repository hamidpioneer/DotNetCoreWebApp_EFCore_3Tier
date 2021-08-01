using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IApplicationRepo
    {
        Task<Application> AddApplicationWithApplicantAsync(Applicant applicant, Application application);
        Task<IList<Application>> GetAllApplicationsAsync();
        Task<Application> GetApplicationByIdAsync(int id);
    }
}

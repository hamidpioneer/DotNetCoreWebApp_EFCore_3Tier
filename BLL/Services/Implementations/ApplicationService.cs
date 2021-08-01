using AutoMapper;
using BLL.Services.Dtos;
using BLL.Services.Interfaces;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Implementations
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepo _applicationRepo;
        private readonly IMapper _mapper;

        public ApplicationService(IApplicationRepo applicationRepo, IMapper mapper)
        {
            _applicationRepo = applicationRepo;
            _mapper = mapper;
        }

        public async Task<ResultSet<Application>> AddApplicationWithApplicantAsync(ApplicantCreateDto applicantCreateDto, ApplicationCreateDto applicationCreateDto)
        {
            ResultSet<Application> result = new();

            try
            {
                Applicant applicant = _mapper.Map<Applicant>(applicantCreateDto);
                Application application = _mapper.Map<Application>(applicationCreateDto);




                Application savedApplication = await _applicationRepo.AddApplicationWithApplicantAsync(applicant, application);

                result.result_set = savedApplication;
                result.userMessage = "BLL - ApplicationService - AddApplicationWithApplicantAsync() - Successful";
                result.internalMessage = "LOG-Internal: BLL - ApplicationService - AddApplicationWithApplicantAsync() - Successful";
                result.success = true;
            }
            catch (Exception exception)
            {
                result.userMessage = "ERROR: BLL - ApplicationService - AddApplicationWithApplicantAsync() - Failed";
                result.internalMessage = "ERROR-Internal: BLL - ApplicationService - AddApplicationWithApplicantAsync() - Failed";
                result.exception = exception;
            }
            return result;
        }

        public async Task<ResultSet<IList<Application>>> GetAllApplicationsAsync()
        {
            ResultSet<IList<Application>> result = new();

            try
            {
                IList<Application> applications = await _applicationRepo.GetAllApplicationsAsync();

                result.result_set = applications;
                result.userMessage = "BLL - ApplicationService - GetAllApplicationsAsync() - Successful";
                result.internalMessage = "LOG-Internal: BLL - ApplicationService - GetAllApplicationsAsync() - Successful";
                result.success = true;
            }
            catch (Exception exception)
            {
                result.userMessage = "ERROR: BLL - ApplicationService - GetAllApplicationsAsync() - Failed";
                result.internalMessage = "ERROR-Internal: BLL - ApplicationService - GetAllApplicationsAsync() - Failed";
                result.exception = exception;
            }
            return result;
            throw new NotImplementedException();
        }
    }
}

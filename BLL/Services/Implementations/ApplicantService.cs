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
    public class ApplicantService : IApplicantService
    {
        private readonly IGenericRepo<Applicant> _applicantGenericRepo;
        private readonly IMapper _mapper;

        public ApplicantService(IGenericRepo<Applicant> applicantGenericRepo, IMapper mapper)
        {
            _applicantGenericRepo = applicantGenericRepo;
            _mapper = mapper;
        }
        public ResultSet<ApplicantReadDto> InsertData(ApplicantCreateDto applicantCreateDto)
        {
            ResultSet<ApplicantReadDto> result = new();

            try
            {
                Applicant applicant = _mapper.Map<Applicant>(applicantCreateDto);

                Applicant savedData = _applicantGenericRepo.Insert(applicant);

                ApplicantReadDto mappedData = _mapper.Map<ApplicantReadDto>(savedData);

                result.result_set = mappedData;
                result.userMessage = "BLL - ApplicantService - InsertData() - Successful";
                result.internalMessage = "LOG-Internal: BLL - ApplicantService - InsertData() - Successful";
                result.success = true;
            }
            catch (Exception exception)
            {
                result.userMessage = "ERROR: BLL - ApplicantService - InsertData() - Failed";
                result.internalMessage = "ERROR-Internal: BLL - ApplicantService - InsertData() - Failed";
                result.exception = exception;
            }
            return result;
        }
    }
}

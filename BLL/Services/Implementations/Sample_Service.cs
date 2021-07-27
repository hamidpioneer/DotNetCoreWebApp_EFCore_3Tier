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
    public class Sample_Service : ISample_Service
    {
        private readonly ISampleRepo _repo;
        private readonly IMapper _mapper;

        public Sample_Service(ISampleRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public ResultSet<IList<SampleReadDto>> GetAllSamples()
        {
            ResultSet<IList<SampleReadDto>> result = new();

            try
            {
                IList<Sample> samplesFromDb = _repo.GetAll().ToList();
                IList<SampleReadDto> samples = _mapper.Map<IList<SampleReadDto>>(samplesFromDb);

                result.userMessage = "SampleReadDto Data: Successfully Retrived.";
                result.internalMessage = "BLL.Services.Implementation.Sample_Service: GetAllSamples() method executed successfully.";
                result.result_set = samples;
                result.success = true;
            }
            catch(Exception exception)
            {
                result.exception = exception;
                result.userMessage = "SampleReadDto Data: Failed to Retrive.";
                result.internalMessage = $"ERROR: BLL.Services.Implementation.Sample_Service: GetAllSamples(): {exception.Message}";
            }
            return result;
        }
    }
}

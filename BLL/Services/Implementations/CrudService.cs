using AutoMapper;
using BLL.Services.Dtos;
using BLL.Services.Interfaces;
using DAL.DatabaseContext;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Implementations
{
    public class CrudService : ICrudService
    {
        private readonly IGenericRepo<Sample> _genericRepo = null;
        private readonly IMapper _mapper;

        public CrudService(IGenericRepo<Sample> genericRepo, IMapper mapper)
        {
            _genericRepo = genericRepo;
            _mapper = mapper;
        }

        public ResultSet<IList<SampleReadDto>> GetAllData()
        {
            ResultSet<IList<SampleReadDto>> result = new();

            try
            {
                IEnumerable<Sample> data = _genericRepo.GetAll();
                IList<SampleReadDto> mappedData = _mapper.Map<IList<SampleReadDto>>(data);

                result.result_set = mappedData;
                result.userMessage = "BLL - CrudService - GetAll() - Successful";
                result.internalMessage = "LOG: BLL - CrudService - GetAll() - Successful";
                result.success = true;
            }
            catch (Exception exception)
            {
                result.userMessage = "ERROR: BLL - CrudService - GetAll() - Failed";
                result.internalMessage = "ERROR-Internal: BLL - CrudService - GetAll() - Failed";
                result.exception = exception;
            }
            return result;
        }

        public ResultSet<SampleReadDto> InsertData(Sample sample)
        {
            ResultSet<SampleReadDto> result = new();

            try
            {
                Sample savedData = _genericRepo.Insert(sample);
                SampleReadDto mappedData = _mapper.Map<SampleReadDto>(savedData);
                
                result.result_set = mappedData;
                result.userMessage = "BLL - CrudService - InsertData() - Successful";
                result.internalMessage = "LOG: BLL - CrudService - InsertData() - Successful";
                result.success = true;
            }
            catch (Exception exception)
            {
                result.userMessage = "ERROR: BLL - CrudService - InsertData() - Failed";
                result.internalMessage = "ERROR-Internal: BLL - CrudService - InsertData() - Failed";
                result.exception = exception;
            }
            return result;
        }
    }
}

using BLL.Services.Dtos;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface ICrudService
    {
        ResultSet<SampleReadDto> InsertData(Sample sample);
        ResultSet<IList<SampleReadDto>> GetAllData();
    }
}

using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Dtos
{
    public class ApplicantApplicationCreateDto
    {
        public ApplicantCreateDto applicantCreateDto { get; set; }
        public ApplicationCreateDto applicationCreateDto { get; set; }
    }
}

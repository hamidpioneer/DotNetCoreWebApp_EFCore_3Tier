using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Dtos
{
    public class ApplicantCreateDto : ElementarySchoolBaseCreateDto
    {
        public string SurName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }
    }
}

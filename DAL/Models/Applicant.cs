using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Applicant : ElementarySchoolBase
    {
        public string SurName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }

        public ICollection<Application> Applications { get; set; }
    }
}

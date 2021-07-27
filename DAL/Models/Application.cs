using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Application : ElementarySchoolBase
    {
        public int Applicant_Id { get; set; }
        public int ApplicationStatus_Id { get; set; }
        public int Grade_Id { get; set; }
        public int SchoolYear { get; set; }

        public Applicant Applicant { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }
        public Grade Grade { get; set; }

    }
}

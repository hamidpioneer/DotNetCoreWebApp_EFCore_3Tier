using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Applicant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public ICollection<Application> Applications { get; set; }
    }
}

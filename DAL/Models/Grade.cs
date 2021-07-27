using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Grade : ElementarySchoolBase
    {
        public int Number { get; set; }
        public int Capacity { get; set; }

        public ICollection<Application> Applications { get; set; }
    }
}

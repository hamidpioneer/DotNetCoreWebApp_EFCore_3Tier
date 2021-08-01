using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public ICollection<Application> Applications { get; set; }
    }
}

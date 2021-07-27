using DAL.DatabaseContext;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class SampleRepo : ISampleRepo
    {
        public SampleRepo(AppDbContext context)
        {
            _context = context;
        }

        private readonly AppDbContext _context;

        public IList<Sample> GetAll()
        {
            IList<Sample> samples = _context.Samples.ToList();

            return samples;
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}

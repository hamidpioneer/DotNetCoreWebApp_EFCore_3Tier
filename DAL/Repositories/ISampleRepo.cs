using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface ISampleRepo
    {
        void SaveChange();
        IList<Sample> GetAll();
    }
}

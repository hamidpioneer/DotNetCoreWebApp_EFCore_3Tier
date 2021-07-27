using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Dtos
{
    public class ResultSet<T> : ResultSetBase
    {
        public T result_set { get; set; }
    }
}

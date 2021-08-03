using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AuthDbResponse<T> where T : class
    {
        public AuthDbResponse()
        {
            Data = null;
            Errors = new List<string>();
            Success = false;
        }

        public T Data { get; set; }
        public List<string> Errors { get; set; }
        public bool Success { get; set; }
    }
}

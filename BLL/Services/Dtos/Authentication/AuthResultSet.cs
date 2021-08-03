using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Dtos.Authentication
{
    public class AuthResultSet
    {
        public AuthResultSet()
        {
            Token = "";
            Success = false;
            Errors = new List<string>();
        }
        public string Token { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}

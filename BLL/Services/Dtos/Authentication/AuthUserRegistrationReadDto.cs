using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Dtos.Authentication
{
    public class AuthUserRegistrationReadDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }

    }
}

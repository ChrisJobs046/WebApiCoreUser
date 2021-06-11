using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAuth.DTO
{
    public class UserDTO
    {
        public int AuthId { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? EnrollmentDate { get; set; }
    }
}

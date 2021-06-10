using System;
using System.Collections.Generic;


namespace WebApiAuth.Models
{
    public partial class User
    {
        public int AuthId { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? EnrollmentDate { get; set; }
    }
}
